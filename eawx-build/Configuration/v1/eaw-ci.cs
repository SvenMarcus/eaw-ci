﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 
namespace EawXBuild.Configuration.v1 {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    [System.Xml.Serialization.XmlRootAttribute("BuildConfiguration", Namespace="eaw-ci", IsNullable=false)]
    public partial class BuildConfigurationType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private AbstractTaskType[] globalTasksField;
        
        private JobDefinitionType[] globalJobsField;
        
        private ProjectType[] projectsField;
        
        private string configVersionField;
        
        public BuildConfigurationType() {
            this.configVersionField = "1.0.0";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TaskDefinition", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public AbstractTaskType[] GlobalTasks {
            get {
                return this.globalTasksField;
            }
            set {
                this.globalTasksField = value;
                this.RaisePropertyChanged("GlobalTasks");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("JobDefinition", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public JobDefinitionType[] GlobalJobs {
            get {
                return this.globalJobsField;
            }
            set {
                this.globalJobsField = value;
                this.RaisePropertyChanged("GlobalJobs");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Project", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ProjectType[] Projects {
            get {
                return this.projectsField;
            }
            set {
                this.projectsField = value;
                this.RaisePropertyChanged("Projects");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ConfigVersion {
            get {
                return this.configVersionField;
            }
            set {
                this.configVersionField = value;
                this.RaisePropertyChanged("ConfigVersion");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Clean))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RunProgram))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Copy))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SoftCopy))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public abstract partial class AbstractTaskType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nameField;
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class JobType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private object itemField;
        
        private string nameField;
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("JobReference", typeof(JobReferenceType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("Tasks", typeof(TasksType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
                this.RaisePropertyChanged("Item");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class JobReferenceType : AbstractReferenceType {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(JobReferenceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TaskReferenceType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public abstract partial class AbstractReferenceType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string referenceIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="IDREF")]
        public string ReferenceId {
            get {
                return this.referenceIdField;
            }
            set {
                this.referenceIdField = value;
                this.RaisePropertyChanged("ReferenceId");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class TaskReferenceType : AbstractReferenceType {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class TasksType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private object[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Task", typeof(AbstractTaskType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("TaskReference", typeof(TaskReferenceType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
                this.RaisePropertyChanged("Items");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class ProjectType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private JobType[] jobsField;
        
        private string[] textField;
        
        private string nameField;
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Job", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public JobType[] Jobs {
            get {
                return this.jobsField;
            }
            set {
                this.jobsField = value;
                this.RaisePropertyChanged("Jobs");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
                this.RaisePropertyChanged("Text");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class JobDefinitionType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private object[] tasksField;
        
        private string nameField;
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Task", typeof(AbstractTaskType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TaskReference", typeof(TaskReferenceType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public object[] Tasks {
            get {
                return this.tasksField;
            }
            set {
                this.tasksField = value;
                this.RaisePropertyChanged("Tasks");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class Clean : AbstractTaskType {
        
        private string pathField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
                this.RaisePropertyChanged("Path");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class RunProgram : AbstractTaskType {
        
        private string executablePathField;
        
        private string argumentsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string ExecutablePath {
            get {
                return this.executablePathField;
            }
            set {
                this.executablePathField = value;
                this.RaisePropertyChanged("ExecutablePath");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string Arguments {
            get {
                return this.argumentsField;
            }
            set {
                this.argumentsField = value;
                this.RaisePropertyChanged("Arguments");
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SoftCopy))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class Copy : AbstractTaskType {
        
        private string copyFromPathField;
        
        private string copyToPathField;
        
        private bool copySubfoldersField;
        
        private string copyFileByPatternField;
        
        private bool alwaysOverwriteField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string CopyFromPath {
            get {
                return this.copyFromPathField;
            }
            set {
                this.copyFromPathField = value;
                this.RaisePropertyChanged("CopyFromPath");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string CopyToPath {
            get {
                return this.copyToPathField;
            }
            set {
                this.copyToPathField = value;
                this.RaisePropertyChanged("CopyToPath");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public bool CopySubfolders {
            get {
                return this.copySubfoldersField;
            }
            set {
                this.copySubfoldersField = value;
                this.RaisePropertyChanged("CopySubfolders");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string CopyFileByPattern {
            get {
                return this.copyFileByPatternField;
            }
            set {
                this.copyFileByPatternField = value;
                this.RaisePropertyChanged("CopyFileByPattern");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public bool AlwaysOverwrite {
            get {
                return this.alwaysOverwriteField;
            }
            set {
                this.alwaysOverwriteField = value;
                this.RaisePropertyChanged("AlwaysOverwrite");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="eaw-ci")]
    public partial class SoftCopy : Copy {
    }
}
