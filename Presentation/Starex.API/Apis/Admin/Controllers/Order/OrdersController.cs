using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Admin.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(int id, OrderPostDto postDto)
        {
            await _orderService.Create(id, postDto);
            return Ok();
        }
        [HttpPost("InForeignStock")]
        public async Task<IActionResult> InForeignStock(int id)
        {
            await _orderService.InforeignStock(id);
            return Ok();
        }
        [HttpPost("InAirport")]
        public async Task<IActionResult> InAirport(int id)
        {
            await _orderService.InAirPort(id);
            return Ok();
        }
        [HttpPost("InInsideStock")]
        public async Task<IActionResult> InInsideStock(int id)
        {
            await _orderService.InInsideStock(id);
            return Ok();
        }
    }
}
