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

        public Task AddAsync(Address address)
        {
            return Task.Run(() =>
            {
                _DbContext.Address.AddAsync(address);
                _DbContext.SaveChanges();
            });
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAsync(Guid Id)
        {
            return Task.Run(() =>
            {
                return _DbContext.Address.Where(x => x.Id == Id).FirstOrDefault();
            });
        }

        public Task<Address> GetAsync(Expression<Func<Address, bool>> predicate)
        {
            return Task.Run(() =>
            {
                return _DbContext.Address.Where(predicate).FirstOrDefault();
            });
        }

        public Task UpdateAsync(Address address)
        {
            return Task.Run(() =>
            {
                _DbContext.Address.Add(address);
                _DbContext.SaveChanges();
            });
        }

        public Task<List<Address>> GetAllAsync(Expression<Func<Address, bool>> predicate)
        {
            return Task.Run(() =>
            {
                return _DbContext.Address.Where(predicate).ToList();
            });
        }
    }
}
