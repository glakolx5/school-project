using csharp_mongo_webapi.Data;
using csharp_mongo_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_mongo_webapi.Controllers
{

    //
    //This is a controller responsible for routes for my api using my respository interface
    //


    [ApiController]
    //My route will be ex. http://localhost/api/Info/*******
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IInfoRepository _repository;

        //Constructor that makes dependecy injection using my repository interface
        public InfoController(IInfoRepository repository)
        {
            _repository = repository;
        }

        //Aync explanation : https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/async

        //HTTP GET my all info in async
        [HttpGet]
        public async Task<List<Info>> GetInfosAsync() => await _repository.GetInfosAsync();

        //HTTP GET info using id 
        //if it is null it will return NotFound() with is 404 status code
        [HttpGet("{id:length(24)}")]
        [ActionName(nameof(GetInfoAsync))]
        public async Task<ActionResult<Info>> GetInfoAsync(string id)
        {
            var info = await _repository.GetInfoAsync(id);
            if (info is null)
            {
                return NotFound();
            }
            return info;
        }

        //HTTP POST creates info to the database
        [HttpPost]
        public async Task<IActionResult> CreateInfoAync(Info newInfo)
        {
            await _repository.CreateInfoAsync(newInfo);
            return CreatedAtAction(nameof(GetInfoAsync), new { id = newInfo.Id }, newInfo);
        }

        //HTTP PUT updates data using id
        //if it is null it will return NotFound() which is 404 status code
        //If everything works out, it will return NoContent(), which is 204 status code
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateInfoAsync(string id, Info updateInfo)
        {
            var book = await _repository.GetInfoAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updateInfo.Id = book.Id;

            await _repository.UpdateInfoAsync(id, updateInfo);

            return NoContent();
        }

        //HTTP DELETE using id
        //If id not found it will return 404 status code
        //If everything works out, it will return 204 status code
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> RemoveInfoAsync(string id)
        {
            var book = await _repository.GetInfoAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _repository.RemoveInfoAsync(id);

            return NoContent();
        }

    }
}