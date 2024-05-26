using AutoMapper;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class OrderItemService : IOrderItemService
    {
        private IOrderItemRepository _orderItemRepository;

        private IConfiguration _config;

        private IMapper _Mapper;
        public OrderItemService(IOrderItemRepository orderItemRepository, IConfiguration config, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _config = config;
            _Mapper = mapper;
        }

        public IEnumerable<OrderItem> FindAll()
        {

            return _orderItemRepository.FindAll();
        }

        public OrderItem? UpdateOne(Guid orderItemId, int newQuantity, double newTotalPrice)

        {

            return _orderItemRepository.UpdateOne(orderItemId, newQuantity, newTotalPrice);
        }

        public void DeleteAll()
        {
            _orderItemRepository.DeleteAll();
        }


        public OrderItem? FindOne(Guid order)
        {
            var orderId = _orderItemRepository.FindOne(order);

            if (orderId is not null)
            {
                var orderRead = _Mapper.Map<OrderItem>(orderId);
                return orderRead;
            }
            Console.WriteLine("Order Id " + orderId + " is not found ");
            return null;

        }



        public OrderItem CreateOne(OrderItem orderItem)
        {
            OrderItem? foundOrderItem = _orderItemRepository.FindOne(orderItem.Id);

            if (foundOrderItem is not null)
            {
                Console.WriteLine("OrderItem " + orderItem.Id + " already exists");
            }
            return _orderItemRepository.CreateOne(orderItem);
        }

    }
}

