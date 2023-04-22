namespace csharp_mongo_webapi.Infrastructure;

public class ServerConfig
{
    //will create new object of my configuration file
  public MongoConfig mongoDbConfig { get; set; } = new MongoConfig();
}

