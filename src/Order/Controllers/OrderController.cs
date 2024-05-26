using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{

    public class OrderController : ControllerTemplate
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<OrderReadDto> FindAll()
        {
            return _orderService.FindAll();
        }
        [HttpGet("{id}")]
        public Order? FindOneById(Guid id)
        {
            return _orderService.FindOneById(id);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<OrderReadDto> CreateOne([FromBody] List<OrderCreateDto> orderCheckout)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //creating order
            if (orderCheckout is not null && userId is not null)
            {
                _orderService.CreateOne(orderCheckout, userId);
                return Ok();
            }
            return BadRequest();

        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<OrderReadDto> UpdateOne(Guid id, [FromBody] Order.OrderStatus status)
        {
            var updateStatusOrder = _orderService.UpdateOne(id, status);
            return CreatedAtAction(nameof(UpdateOne), updateStatusOrder);

        }

    }
}