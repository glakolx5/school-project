using csharp_mongo_webapi.Models;

namespace csharp_mongo_webapi.Data;

public interface IInfoRepository
{
    //
    //This is interface for Info repository
    //

    //Get all info in async
    Task<List<Info>> GetInfosAsync();

    //Get one info using id 
    Task<Info> GetInfoAsync(string id);

    //Creates info
    Task CreateInfoAsync(Info newInfo);

    //Updates info using id
    Task UpdateInfoAsync(string id, Info updateInfo);

    //Removes info using id
    Task RemoveInfoAsync(string id);
}

