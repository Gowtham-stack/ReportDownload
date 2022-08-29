using Microsoft.AspNetCore.SignalR;
using ReportDownload.Models;
using ReportDownload.SignalRHubs;

namespace ReportDownload.Processors
{
    public class ReportProcessor
    {
        private readonly List<Report> reports;
        private readonly IHubClients<ReportHub> reportHub;

        public ReportProcessor(List<Report> reports, IHubClients<ReportHub> reportHub)
        {
            this.reports = reports;
            this.reportHub = reportHub;
        }

        public List<Report> GetAllReports()
        {
            return reports;
        }

        public async Task<bool> GenerateReport(string reportName)
        {
            //Change Report Status to Inprogress
            var report = reports.FirstOrDefault(x => x.Name == reportName);
            report.Status = ReportStatus.InProgress;

            Task.Run(async () =>
            {
                while (report.Status == ReportStatus.InProgress)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    reportHub.All.SendDonloadingPercentage();
                }
            });

            //Generating Report
            await Task.Delay(TimeSpan.FromSeconds(120))
                .ContinueWith((t1)=>
                {
                    reportHub.All.SendDonloadingPercentage();

                });

            return true;
        }
    }
}
