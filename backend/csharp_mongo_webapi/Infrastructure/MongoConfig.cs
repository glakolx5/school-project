using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_mongo_webapi.Infrastructure;

public class MongoConfig
{
    //Database name e
    public string Database { get; set; } = null!;

    //Host
    public string Host { get; set; } = null!;

    public int Port { get; set; }

    public string User { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ConnectionString
    {
        //will return from appsettings.json something like this : mongodb://root:example@localhost:27017
        get
        {
            if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password)) return $@"mongodb://{Host}:{Port}";
            return $@"mongodb://{User}:{Password}@{Host}:{Port}";

        }
    }
}

