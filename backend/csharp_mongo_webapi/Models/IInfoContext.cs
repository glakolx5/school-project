using MongoDB.Driver;
namespace csharp_mongo_webapi.Models;

public interface IInfoContext
{
    //Represent a typed collection in MongoDB
    //https://mongodb.github.io/mongo-csharp-driver/2.8/apidocs/html/T_MongoDB_Driver_IMongoCollection_1.htm
    
    IMongoCollection<Info> Infos { get; }
}

