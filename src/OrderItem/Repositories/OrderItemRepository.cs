using Microsoft.EntityFrameworkCore;


namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private DatabaseContext _dbContext;

        private DbSet<OrderItem> _orderitems;


        public OrderItemRepository(DatabaseContext databaseContext)
        {
            _orderitems = databaseContext.OrderItem;
            _dbContext = databaseContext;

        }

        public IEnumerable<OrderItem> FindAll()
        {
            return _orderitems;
        }


        public OrderItem? UpdateOne(Guid orderItemId, int newQuantity, double newTotalPrice)
        {

            OrderItem? itemToUpdate = _orderitems.FirstOrDefault(item => item.Id == orderItemId);
            if (itemToUpdate != null)
            {
                // Update properties of the found item
                itemToUpdate.Quantity = newQuantity;
                itemToUpdate.TotalPrice = newTotalPrice;
                return itemToUpdate;
            }
            else
            {
                throw new ArgumentException("Order item not found");
            }


        }


        public void DeleteAll()
        {
            _dbContext.OrderItem.RemoveRange(_orderitems);
            _dbContext.SaveChanges();
        }







        public OrderItem? FindOne(Guid foundOrderItem)
        {
            OrderItem? order = _orderitems.FirstOrDefault(o => o.Id == foundOrderItem);
            return order;
        }

        public OrderItem CreateOne(OrderItem orderitem)
        {
            _orderitems.Add(orderitem);
            _dbContext.SaveChanges();
            return orderitem;
        }

    }
}