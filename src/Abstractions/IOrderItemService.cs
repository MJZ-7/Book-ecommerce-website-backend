namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public interface IOrderItemService
    {


        public IEnumerable<OrderItem> FindAll();
        public OrderItem? UpdateOne(Guid orderItemId, int newQuantity, double newTotalPrice);
        public void DeleteAll();
        public OrderItem? FindOne(Guid orderId);
        public OrderItem CreateOne(OrderItem orderItem);

    }
}