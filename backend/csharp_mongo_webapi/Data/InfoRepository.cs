using csharp_mongo_webapi.Models;
using MongoDB.Driver;
namespace csharp_mongo_webapi.Data;

public class InfoRepository : IInfoRepository
{
    //
    //Info repository is responsible for actual computations to make CRUD operations to the database 
    //

    private readonly IInfoContext _context;

    //InfoRepository constructor that makes dependency injection from interface
    public InfoRepository(IInfoContext context)
    {
        _context = context;
    }

    //Linq explanation
    //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/

    //Lambda-expressions explanation
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions

    //Will return All Info
    public async Task<List<Info>> GetInfosAsync()
    {
        return await _context.Infos.Find(_ => true).ToListAsync();
    }

    //Will return one info using id
    public async Task<Info> GetInfoAsync(string id)
    {
        return await _context.Infos.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    //will create info
    public async Task CreateInfoAsync(Info newInfo)
    {
        await _context.Infos.InsertOneAsync(newInfo);
    }

    //will update info using id
    public async Task UpdateInfoAsync(string id, Info updateInfo)
    {
        await _context.Infos.ReplaceOneAsync(x => x.Id == id, updateInfo);
    }

    //will remove info using id
    public async Task RemoveInfoAsync(string id)
    {
        await _context.Infos.DeleteOneAsync(x => x.Id == id);
    }
}

