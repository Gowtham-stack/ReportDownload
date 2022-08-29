using Microsoft.AspNetCore.Mvc;
using ReportDownload.Processors;

namespace ReportDownload.Controllers
{
    public class ReportDownloadController : Controller
    {
        private readonly ReportProcessInServer reportProcessInServer;

        public ReportDownloadController(ReportProcessInServer reportProcessInServer)
        {
            this.reportProcessInServer = reportProcessInServer;
        }

        [HttpGet("GenerateReportWithoutCancellationToken")]
        public async Task<IActionResult> GenerateReportAsyncWithoutToken()
        {
            await reportProcessInServer.GenerateReport();
            return Ok();
        }
        [HttpGet("GenerateReport")]
        public async Task<IActionResult> GenerateReportAsync(CancellationToken cancellationToken)
        {
            await reportProcessInServer.GenerateReport(cancellationToken);
            return Ok();
        }
    }
}
