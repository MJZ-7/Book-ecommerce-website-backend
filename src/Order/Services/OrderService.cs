using AutoMapper;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IOrderItemService _orderItemService;
        private IConfiguration _config;
        private IMapper _Mapper;

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository, IMapper mapper, IConfiguration configuration, IOrderItemService orderItemService)
        {
            _orderRepository = orderRepository;
            _config = configuration;
            _Mapper = mapper;
            _orderItemService = orderItemService;
            _productRepository = productRepository;
        }

        public IEnumerable<OrderReadDto> FindAll()
        {
            var orders = _orderRepository.FindAll();
            var ordersRead = orders.Select(_Mapper.Map<OrderReadDto>);
            return ordersRead;
        }
        public void CreateOne(List<OrderCreateDto> orderCheckout, string userId)
        {
            Console.WriteLine($"{userId}");

            Order order = new()
            {
                CreatedAt = DateTime.Now,
                DeliveryAt = DateTime.Now,
                UserId = new Guid(userId),
                PaymentId = Guid.NewGuid(),
                TotalPrice = 0,
            };
            _orderRepository.CreateOne(order);
            Console.WriteLine($"{order.Id}");


            foreach (var item in orderCheckout)
            {
                Product? product = _productRepository.FindOne(item.ProductId);
                if (product is not null)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        TotalPrice = product.Price * item.Quantity
                    };

                    order.TotalPrice += orderItem.TotalPrice;
                    product.Stock -= item.Quantity;

                    _productRepository.UpdateOne(product);
                    _orderItemService.CreateOne(orderItem);
                }
            }

            Console.WriteLine($"ORDER {order.TotalPrice}");

            _orderRepository.UpdateOne(order);

        }
        public Order? FindOneById(Guid id)
        {
            return _orderRepository.FindOneById(id);
        }

        public Order? UpdateOne(Guid id, Order.OrderStatus status)
        {
            Order? userOrder = _orderRepository.FindOneById(id);
            if (userOrder is not null)
            {
                userOrder.Status = status;
                return _orderRepository.UpdateOne(userOrder);

            }
            return null;
        }
    }
}