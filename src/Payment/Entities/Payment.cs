using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class Payment
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public Guid AddressId { get; set; }
        public Method PayMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ReceivedAt { get; set; }
        public PaymentStatus Status { get; set; }
    }

    public enum Method
    {
        Cash
        ,
        Credit
    }
    public enum PaymentStatus
    {
        Paid,
        Unpaid
    }
}