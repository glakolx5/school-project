using MongoDB.Driver;
using csharp_mongo_webapi.Infrastructure;
namespace csharp_mongo_webapi.Models;

public class InfoContext : IInfoContext
{
    //Represents a database in MongoDB. 
    //https://mongodb.github.io/mongo-csharp-driver/2.8/apidocs/html/T_MongoDB_Driver_IMongoDatabase.htm
    private readonly IMongoDatabase _db;

    //This constructor makes dependency injection for my database and creates a client object
    public InfoContext(MongoConfig config)
    {
        //creates a client using MongoClient and MongoConfig then gets database
        //link to MongoClient : https://mongodb.github.io/mongo-csharp-driver/2.8/apidocs/html/T_MongoDB_Driver_MongoClient.htm
        var client = new MongoClient(config.ConnectionString);

        //GetDatabase came from MongoClient
        _db = client.GetDatabase(config.Database);
    }

    //Gets collection from database
    public IMongoCollection<Info> Infos => _db.GetCollection<Info>("infoCollection");
}

