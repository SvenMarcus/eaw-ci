using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using EawXBuild.Configuration.FrontendAgnostic;
using EawXBuild.Configuration.v1;
using EawXBuild.Core;
using Microsoft.Extensions.Logging;

namespace EawXBuild.Configuration.Xml.v1
{
    internal class XmlBuildConfigParser : IBuildConfigParser
    {
        private const string XSD_RESOURCE_ID = "v1.eaw-ci.xsd";

        private const string DEFAULT_XML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<eaw-ci:BuildConfiguration ConfigVersion=""1.0.0"" xmlns:eaw-ci=""eaw-ci"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""eaw-ci eaw-ci.xsd "">
    <Projects>
        <Project Id=""pid0"" Name=""My-Project"">
            <Jobs>
                <Job Id=""pid0.jid0"" Name=""My-Job"">
                    <Tasks>
                    </Tasks>
                </Job>
            </Jobs>
        </Project>
    </Projects>
</eaw-ci:BuildConfiguration>";

        private const ConfigVersion CONFIG_VERSION = ConfigVersion.V1;
        private const string FILE_EXTENSION = ".xml";

        [NotNull] private readonly IFileSystem _fileSystem;
        [NotNull] private readonly IBuildComponentFactory _factory;
        private readonly ILogger<XmlBuildConfigParser> _logger;

        public XmlBuildConfigParser([NotNull] IFileSystem fileSystem, [NotNull] IBuildComponentFactory factory,
            ILogger<XmlBuildConfigParser> logger = null)
        {
            _fileSystem = fileSystem;
            _factory = factory;
            _logger = logger;
        }

        public IEnumerable<IProject> Parse(string filePath)
        {
            BuildConfigurationType buildConfig = DeserializeBuildConfigInternal(filePath);

            var projects = new IProject[buildConfig.Projects.Length];
            for (var i = 0; i < buildConfig.Projects.Length; i++)
            {
                var buildConfigProject = buildConfig.Projects[i];
                projects[i] = GetProjectFromConfig(buildConfig, buildConfigProject);
            }

            return projects;
        }

        public bool TestIsValidConfiguration(string filePath)
        {
            try
            {
                BuildConfigurationType buildConfig = DeserializeBuildConfigInternal(filePath);
                if (buildConfig == null)
                {
                    _logger?.LogError($"The provided configuration {filePath} is empty.");
                    return false;
                }

                string versionMatch = ConfigurationUtility.IsVersionMatch(buildConfig.ConfigVersion, Version)
                    ? "[MATCH]"
                    : "[MISSMATCH]";
                string msg = $"{versionMatch} The provided configuration {filePath} is a valid configuration file." +
                             $"\n\tConfiguration version:\t{buildConfig.ConfigVersion}" +
                             $"\n\tParser version:       \t{Version}";
                // [gruenwaldlu, 2020-07-14-14:14:39+2]: Required for user feedback. Depending on the configuration, the logger may not print to the console out.
                Console.Out.Write(msg);
                _logger?.LogInformation(msg);
                return true;
            }
            catch (Exception e)
            {
                StringBuilder builder = new StringBuilder();
                string msg = BuildErrorMessage(builder, e);
                // [gruenwaldlu, 2020-07-27-13:45:55+2]: Required for user feedback. Depending on the configuration, the logger may not print to the console out.
                Console.Out.Write(msg);
                _logger?.LogWarning(msg);
                return false;
            }
        }

        private static string BuildErrorMessage(StringBuilder stringBuilder, Exception exception)
        {
            stringBuilder.Append(exception.Message);
            if (exception.InnerException != null)
            {
                BuildErrorMessage(stringBuilder, exception.InnerException);
            }

            return stringBuilder.ToString();
        }

        private BuildConfigurationType DeserializeBuildConfigInternal(string filePath)
        {
            XmlSerializer xmlDataSerializer = new XmlSerializer(typeof(BuildConfigurationType));
            XmlReaderSettings settings = GetXmlReaderSettings();
            using Stream stream = _fileSystem.File.OpenRead(filePath);
            using XmlReader reader = XmlReader.Create(stream, settings);
            BuildConfigurationType buildConfig = (BuildConfigurationType) xmlDataSerializer.Deserialize(reader);
            return buildConfig;
        }

        public ConfigVersion Version => CONFIG_VERSION;
        public string ConfiguredFileExtension => FILE_EXTENSION;
        public string DefaultXml => DEFAULT_XML;

        private IProject GetProjectFromConfig(BuildConfigurationType buildConfig, ProjectType buildConfigProject)
        {
            var project = _factory.MakeProject();
            project.Name = buildConfigProject.Id;
            AddJobsToProject(buildConfig, buildConfigProject, project);

            return project;
        }

        private void AddJobsToProject(BuildConfigurationType buildConfig, ProjectType buildConfigProject,
            IProject project)
        {
            if (buildConfigProject.Jobs.Length == 0) return;
            foreach (JobType buildConfigJob in buildConfigProject.Jobs)
            {
                IJob job = _factory.MakeJob(buildConfigJob.Name);
                AddTasksToJob(buildConfig, job, buildConfigJob);
                project.AddJob(job);
            }
        }

        private void AddTasksToJob(BuildConfigurationType buildConfig, IJob job, JobType buildConfigJob)
        {
            var taskList = (TasksType) buildConfigJob.Item;
            if (taskList.Items == null) return;

            foreach (var taskListItem in taskList.Items)
            {
                object buildConfigTask = GetBuildConfigTaskFromTaskListItem(buildConfig, taskListItem);

                ITask task = MakeTask(buildConfigTask);
                job.AddTask(task);
            }
        }

        private static object GetBuildConfigTaskFromTaskListItem(BuildConfigurationType buildConfig,
            object taskListItem)
        {
            object buildConfigTask = taskListItem;
            if (taskListItem is TaskReferenceType taskRef)
                buildConfigTask = GetMatchingGlobalTask(buildConfig, taskRef);

            return buildConfigTask;
        }

        private static object GetMatchingGlobalTask(BuildConfigurationType buildConfig, TaskReferenceType taskRef)
        {
            object buildConfigTask = null;
            foreach (var globalTask in buildConfig.GlobalTasks)
            {
                if (!globalTask.Id.Equals(taskRef.ReferenceId)) continue;
                buildConfigTask = globalTask;
            }

            return buildConfigTask;
        }

        private ITask MakeTask(object buildConfigTask)
        {
            var taskBuilder = _factory.Task(buildConfigTask.GetType().Name);
            foreach (var prop in buildConfigTask.GetType().GetProperties())
                taskBuilder.With(prop.Name, prop.GetValue(buildConfigTask));

            ITask task = taskBuilder.Build();
            return task;
        }

        private static XmlReaderSettings GetXmlReaderSettings()
        {
            XmlSerializer xsdSchemaSerializer = new XmlSerializer(typeof(XmlSchema));
            XmlSchemaSet schemas = new XmlSchemaSet();
            XmlSchema schema;
            string res = Assembly.GetExecutingAssembly().GetManifestResourceNames()
                .Single(str => str.EndsWith(XSD_RESOURCE_ID));
            using (Stream xsdStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(res))
            {
                schema = xsdSchemaSerializer.Deserialize(xsdStream) as XmlSchema;
            }

            schemas.Add(schema);
            XmlReaderSettings settings = new XmlReaderSettings
            {
                Schemas = schemas,
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ProcessIdentityConstraints |
                                  XmlSchemaValidationFlags.ReportValidationWarnings |
                                  XmlSchemaValidationFlags.ProcessInlineSchema |
                                  XmlSchemaValidationFlags.ProcessSchemaLocation
            };
            settings.ValidationEventHandler += (sender, arguments) =>
                throw new XmlSchemaValidationException(arguments?.Message);
            return settings;
        }
    }
}