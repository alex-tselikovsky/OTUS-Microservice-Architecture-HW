using System.Net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health/", (HttpContext context) =>
{
  var info = $"Time: {DateTime.Now}, Host: {Dns.GetHostName()}, Path: {context.Request.Path}";
  app.Logger.LogInformation(info);
  return new { Status = "OK" };
});


app.MapGet("/info/", (HttpContext context) =>
{
  var info = $"Time: {DateTime.Now}, Host: {Dns.GetHostName()}, Path: {context.Request.Path}";
  app.Logger.LogInformation(info);
  return new { Info = info };
});
app.Run();
