using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Admin.Controllers.Order
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : AdminBaseController
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost(ApiRoutes.OrderAdmin.Create)]
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
        [HttpGet(ApiRoutes.OrderAdmin.Get)]
        public async Task<IActionResult> GetById (int id)
        {
            await _orderService.GetById(id);
            return Ok();
        }
        [HttpGet(ApiRoutes.OrderAdmin.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }
    }
}
