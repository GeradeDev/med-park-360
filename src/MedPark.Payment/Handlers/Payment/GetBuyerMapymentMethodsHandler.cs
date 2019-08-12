using MedPark.Payment.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common.Handlers;
using MedPark.Payment.Dto;
using MedPark.Common;
using MedPark.Payment.Domain;

namespace MedPark.Payment.Handlers.Payment
{
    public class GetBuyerMapymentMethodsHandler : IQueryHandler<GetBuyerPaymentMethods, IEnumerable<PaymentMethodDto>>
    {
        private IMedParkRepository<CustomerPaymentMethod> _methodsRepo { get; }

        public GetBuyerMapymentMethodsHandler(IMedParkRepository<CustomerPaymentMethod> methodsRepo)
        {
            _methodsRepo = methodsRepo;
        }

        public async Task<IEnumerable<PaymentMethodDto>> HandleAsync(GetBuyerPaymentMethods query)
        {
            var methods = await _methodsRepo.FindAsync(x => x.CustomerId == query.CustomerId);

            var customerMethods = new List<PaymentMethodDto>();

            methods.ToList().ForEach(m =>
            {
                customerMethods.Add(new PaymentMethodDto { PaymentTypeId = m.PaymentTypeId, PaymentCardExpiry = m.PaymentCardExpiry, PaymentCardNumber = m.PaymentCardNumber, PaymentCardType = m.PaymentCardType, PaymentMethodId = m.Id });
            });

            return customerMethods;
        }
    }
}
