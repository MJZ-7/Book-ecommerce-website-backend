

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{

    public class Product
    {

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public OrderItem OrderItemsId { get; set; }
        public string? writerName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? Img { get; set; }
        public string? bookName { get; set; }
        public string? Description { get; set; }
    }
}