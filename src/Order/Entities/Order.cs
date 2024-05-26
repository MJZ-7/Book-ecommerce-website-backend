namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
        public class Order
        {
                public Guid Id { get; set; }
                public Guid UserId { get; set; }
                public Guid PaymentId { get; set; }
                public DateTime CreatedAt { get; set; } = DateTime.Now;
                public Guid AddressId { get; set; }
                public DateTime DeliveryAt { get; set; }
                public OrderStatus Status { get; set; }
                public double TotalPrice { get; set; }


                public User user { get; set; }
                public IEnumerable<OrderItem> OrderItems { get; set; }



        }
}