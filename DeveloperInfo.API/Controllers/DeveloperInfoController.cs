using DeveloperInfo.Models;
using DeveloperInfo.Models.Web;
using DeveloperInfo.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DeveloperInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperInfoController : ControllerBase
    {
        readonly IDeveloperService _developerService;

        public DeveloperInfoController(
            IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _developerService.GetAllAsync());
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _developerService.GetAsync(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(DeveloperData entity)
        {
            return Ok(await _developerService.AddAsync(entity));
        }


        [HttpPost("AddBatch")]
        public async Task<IActionResult> AddBatch(string jsonData)
        {
            List<DeveloperData> Devs = JsonConvert.DeserializeObject<List<DeveloperData>>(jsonData) ?? new List<DeveloperData>();
            foreach (var dev in Devs)
            {
                await _developerService.AddAsync(dev);
            }
            return Ok();
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(Developer entity)
        {
            return Ok(await _developerService.UpdateAsync(entity));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            await _developerService.DeleteAsync(id);
            return Ok();
        }
    }
}
