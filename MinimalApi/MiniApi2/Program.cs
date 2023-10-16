using System.Net;
using MiniApi2;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString = Environment.GetEnvironmentVariable("db_connection_string");
var client = new MongoClient(connectionString);
var collection = client.GetDatabase("my-database").GetCollection<User>("Users");

app.MapGet("/users/", async () =>
{
  return await (await collection.FindAsync(u => true)).ToListAsync();
});

app.MapGet("/users/{id}", async (string id) =>
{
  return await (await collection.FindAsync(u => u.Id == id)).FirstOrDefaultAsync();
});

app.MapPut("/users/{id}", async (string id, User user) =>
{
  user.Id = id;
  await collection.ReplaceOneAsync(u => u.Id == id, user);
});

app.MapPost("/users/",  (User user) =>collection.InsertOneAsync(user));

app.MapDelete("/users/{id}",  (string id) =>collection.DeleteOneAsync(u =>u.Id == id));

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
