using csharp_mongo_webapi.Data;
using csharp_mongo_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_mongo_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IInfoRepository _repository;
        public InfoController(IInfoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<Info>> GetInfosAsync() => await _repository.GetInfosAsync();

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

        [HttpPost]
        public async Task<IActionResult> CreateInfoAync(Info newInfo)
        {
            await _repository.CreateInfoAsync(newInfo);
            return CreatedAtAction(nameof(GetInfoAsync), new { id = newInfo.Id }, newInfo);
        }

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