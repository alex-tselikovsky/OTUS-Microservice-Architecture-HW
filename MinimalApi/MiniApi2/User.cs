﻿#nullable enable

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MiniApi2;

public class User
{
  public User()
  {
    Id = ObjectId.GenerateNewId().ToString();
  }
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }
  public string? Name { get; set; }
}