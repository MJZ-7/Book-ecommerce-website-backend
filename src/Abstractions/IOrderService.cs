namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
        public interface IOrderService
        {
          public IEnumerable<OrderReadDto> FindAll();
        public OrderReadDto? FindOne(Guid orderId);
        public OrderReadDto CreateOne(OrderCreateDto order);
        public OrderReadDto Checkout(CheckoutDto checkoutList, string userId);
        public OrderReadDto? UpdateOne(Guid id, Order order);
        public bool DeleteOne(Guid id);

        }
}