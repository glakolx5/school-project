using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_mongo_webapi.Infrastructure;

public class MongoConfig
{
    //
    //This code is responsible for credential to the Mongo database
    //

    //Database name ex. my is InfoDatabase
    public string Database { get; set; } = null!;

    //Host ex. localhost
    public string Host { get; set; } = null!;

    //Port ex. 3000
    public int Port { get; set; }

    //User ex. mine is root
    public string User { get; set; } = null!;

    //Password ex. Password123
    public string Password { get; set; } = null!;


    public string ConnectionString
    {
        //will return from appsettings.json something like this : mongodb://root:example@localhost:27017
        get
        {
            if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password)) return $@"mongodb://{Host}:{Port}";
            else
            {
                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
            }

        }
    }
}

