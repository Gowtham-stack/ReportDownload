using ReportDownload.Models;
using ReportDownload.Processors;
using ReportDownload.SignalRHubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ReportProcessInServer>();

var reports = new List<Report>()
{
    new Report("Inventory"),
    new Report("Accounts"),
    new Report("Payments")
};
builder.Services.AddSingleton((IServiceProvider arg) => reports);

builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<ReportHub>("/ReportSignal");
app.MapControllers();

app.Run();
