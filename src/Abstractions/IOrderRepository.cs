namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> FindAll();
        public Order? FindOne(Guid orderId);
        public Order CreateOne(Order order);
        public Order UpdateOne(Order updatedOrder);
        public bool DeleteOne(Guid id);
    }
}