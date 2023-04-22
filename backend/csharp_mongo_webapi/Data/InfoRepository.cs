using csharp_mongo_webapi.Models;
using MongoDB.Driver;
namespace csharp_mongo_webapi.Data;

public class InfoRepository : IInfoRepository
{
    private readonly IInfoContext _context;

    //dependency injection
    public InfoRepository(IInfoContext context)
    {
        _context = context;
    }

    //will return all info
    public async Task<List<Info>> GetInfosAsync()
    {
        return await _context.Infos.Find(_ => true).ToListAsync();
    }

    // will return 1 info
    public async Task<Info> GetInfoAsync(string id)
    {
        return await _context.Infos.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    //will create info
    public async Task CreateInfoAsync(Info newInfo)
    {
        await _context.Infos.InsertOneAsync(newInfo);
    }

    //will update info
    public async Task UpdateInfoAsync(string id, Info updateInfo)
    {
        await _context.Infos.ReplaceOneAsync(x => x.Id == id, updateInfo);
    }

    //will remove info
    public async Task RemoveInfoAsync(string id)
    {
        await _context.Infos.DeleteOneAsync(x => x.Id == id);
    }
}

