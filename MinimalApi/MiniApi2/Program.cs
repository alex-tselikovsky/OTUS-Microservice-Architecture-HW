var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health/", () => new { Status = "OK" });

app.Run();
