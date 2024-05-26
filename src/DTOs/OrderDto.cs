using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers

{
    public class OrderReadDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveryAt { get; set; }
        public string? Status { get; set; }
        public double TotalPrice { set; get; }

    }
    public class OrderCreateDto
    {
        public Guid AddressId { get; set; }
        public double TotalPrice { set; get; }
    }
    public class CheckoutDto
    {
        public Guid AddressId { get; set; }
        public List<Items>? Items { get; set; }
    }
    public class Items
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }


}