using System;
using System.Runtime.Serialization;

namespace EawXBuild.Exceptions
{
    [Serializable]
    public class ReportAlreadyFinalizedException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ReportAlreadyFinalizedException()
        {
        }

        public ReportAlreadyFinalizedException(string message) : base(message)
        {
        }

        public ReportAlreadyFinalizedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ReportAlreadyFinalizedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}