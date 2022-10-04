using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Client.Controllers.Order
{
    
    public class OrdersController : ClientBaseController
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet(ApiRoutes.OrderUser.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }
    }
}
