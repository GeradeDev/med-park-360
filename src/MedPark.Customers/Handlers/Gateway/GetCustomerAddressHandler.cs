using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Handlers.Gateway
{
    public class GetCustomerAddressHandler : IQueryHandler<GetCustomerAddress, List<AddressDto>>
    {
        private IMedParkRepository<Address> _addressRepo { get; }

        public GetCustomerAddressHandler(IMedParkRepository<Address> addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public async Task<List<AddressDto>> HandleAsync(GetCustomerAddress query)
        {
            var addresses = await _addressRepo.BrowseAsync(x => x.UserId == query.Id);

            List<AddressDto> allUserAddresses = new List<AddressDto>();

            addresses.ToList().ForEach(a =>
            {
                allUserAddresses.Add(new AddressDto()
                {
                    Id = a.Id,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    AddressLine3 = a.AddressLine3,
                    PostalCode = a.PostalCode,
                    AddressType = a.AddressType
                });
            });

            return allUserAddresses;
        }
    }
}
