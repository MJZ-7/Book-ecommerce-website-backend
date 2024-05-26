using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class PaymentService : IPaymentService
    {

        private IPaymentRepository _paymentRepository;
        // private IOrderService _orderService;
        private IConfiguration _config;
        // private IMapper _Mapper;
        //  IMapper mapper,
        // , IOrderService orderService
        public PaymentService(IPaymentRepository paymentRepository, IConfiguration configuration)
        {
            _paymentRepository = paymentRepository;
            _config = configuration;
            // _Mapper = mapper;
            // _orderService = orderService;
        }

        public IEnumerable<Payment> FindAll()
        {
            var payment = _paymentRepository.FindAll();
            // var paymentRead = payment.Select(_Mapper.Map<PaymentReadDto>);
            return payment;
        }
    }
}