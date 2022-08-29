using Microsoft.AspNetCore.SignalR;

namespace ReportDownload.SignalRHubs
{
    public class ReportHub : Hub
    {
        public Task SendDonloadingPercentage()
        {
            return Task.CompletedTask;
        }
    }
}
