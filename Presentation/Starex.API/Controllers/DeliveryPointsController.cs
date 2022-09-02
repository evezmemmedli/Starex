using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryPointsController : ControllerBase
    {
        private readonly IDeliveryPointService _deliveryPointService;

        public DeliveryPointsController(IDeliveryPointService deliveryPointService)
        {
            _deliveryPointService = deliveryPointService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] DeliveryPointPostDto request)
        {
            await _deliveryPointService.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _deliveryPointService.GetAll();
            return Ok(response);
        }

        [HttpGet("{{Id}}")]
        public async Task<IActionResult> Get(int id)
        {
            
            return Ok(await _deliveryPointService.GetByIdAsync(false, id));
        }
        [HttpDelete("{id}")]
        public  IActionResult Delete(int id)
        {
             _deliveryPointService.Remove(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(DeliveryPointPostDto deliveryPointPostDto, int id)
        {
            return Ok( _deliveryPointService.Update(deliveryPointPostDto, id));
        }
    }
}
