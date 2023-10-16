using Migration;
using MongoDB.Driver;

var connectionString = Environment.GetEnvironmentVariable("db_connection_string");
var client = new MongoClient(connectionString);
var collection = client.GetDatabase("my-database").GetCollection<User>("Users");
collection.InsertOne(new User(){Name = "Main user"});