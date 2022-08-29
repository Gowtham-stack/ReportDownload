namespace ReportDownload.Processors
{
    public class ReportProcessInServer
    {
        public async Task GenerateReport(CancellationToken cancellationToken)
        {
            Console.WriteLine("Report Started Generating");
            await Task.Delay(TimeSpan.FromSeconds(20), cancellationToken);
            Console.WriteLine("Report Completed Generating");
        }

        public async Task GenerateReport( )
        {
            Console.WriteLine("Report Started Generating");
            await Task.Delay(TimeSpan.FromSeconds(20));
            Console.WriteLine("Report Completed Generating");
        }
    }
}
