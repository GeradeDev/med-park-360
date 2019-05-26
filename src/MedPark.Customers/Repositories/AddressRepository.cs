using MedPark.CustomersService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public CustomersDbContext _DbContext { get; }

        public AddressRepository(CustomersDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task AddAsync(Address address)
        {
            await _DbContext.Address.AddAsync(address);
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> GetAsync(Guid Id)
        {
            return _DbContext.Address.Where(x => x.Id == Id).FirstOrDefault();
        }

        public async Task<Address> GetAsync(Expression<Func<Address, bool>> predicate)
        {
            return _DbContext.Address.Where(predicate).FirstOrDefault();
        }

        public Task UpdateAsync(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
