using csharp_mongo_webapi.Models;

namespace csharp_mongo_webapi.Data;

public interface IInfoRepository
{
    //will get all info in async
    Task<List<Info>> GetInfosAsync();

    //will get 1 info
    Task<Info> GetInfoAsync(string id);

    //will create info
    Task CreateInfoAsync(Info newInfo);

    //will update info
    Task UpdateInfoAsync(string id, Info updateInfo);

    //will remove info
    Task RemoveInfoAsync(string id);
}

