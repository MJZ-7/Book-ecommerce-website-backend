using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class PaymentController : ControllerTemplate
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IEnumerable<Payment> FindAll(){
            return _paymentService.FindAll();
        }




    }
}