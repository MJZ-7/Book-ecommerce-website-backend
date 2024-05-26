using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class PaymentRepository : IPaymentRepository
    {
        private DbSet<Payment> _payment;
        private DatabaseContext _dbContext;
        public PaymentRepository(DatabaseContext dbContext)
        {
            _payment = dbContext.Payment;
            _dbContext = dbContext;
        }

        public IEnumerable<Payment> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}