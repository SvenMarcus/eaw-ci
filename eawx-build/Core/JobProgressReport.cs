namespace EawXBuild.Core {
    public class JobProgressReport {
        public JobProgressReport(object sender, string message) {
            Sender = sender;
            Message = message;
        }

        public object Sender { get; }
        public string Message { get; }
    }
}