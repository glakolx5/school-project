using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace csharp_mongo_webapi.Models;

public class Info
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    //This is Id
    public string? Id { get; set; }

    //Name - ex Brugsen
    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    //Time from - ex 07:00
    public string TimeFrom { get; set; } = null!;

    //Time to - ex 16:00
    public string TimeTo { get; set; } = null!;

    //CVR number - ex 12345678
    public string CvrNR { get; set; } = null!;

    //Address - ex CE Jansensvej 11
    public string Address { get; set; } = null!;
}

