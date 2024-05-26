using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public interface IPaymentRepository
    {
    public IEnumerable<Payment> FindAll();

    }
}