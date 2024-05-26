namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public interface IOrderItemRepository
    {


        public IEnumerable<OrderItem> FindAll();

        public OrderItem? UpdateOne(Guid orderItemId, int newQuantity, double newTotalPrice);



        public void DeleteAll();

        public OrderItem? FindOne(Guid foundOrderItem);

        public OrderItem CreateOne(OrderItem orderitem);


    }
}