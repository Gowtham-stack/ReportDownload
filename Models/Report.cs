namespace ReportDownload.Models
{
    public class Report: Dictionary<string, string>
    {
        public ReportStatus Status { get; set; }
        public string Name { get; set; }
        public Report(string reportName)
        {
            Status = ReportStatus.Not_Started;
            Name = reportName;
        }
    }

    public enum ReportStatus
    {
        Not_Started,
        InProgress,
        Completed,
        Cancelled
    }
}
