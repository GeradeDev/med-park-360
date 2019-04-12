using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MedPark.CustomersService.Domain;

namespace MedPark.CustomersService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomersDbContext _DbContext { get; }

        public CustomerRepository(CustomersDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public Task AddAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsync(Guid Id)
        {
            return Task.Run(() =>
            {
                return _DbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
            });
        }

        public Task<List<Customer>> GetAsync(Expression<Func<Customer, bool>> predicate)
        {
            return Task.Run(() =>
            {
                return _DbContext.Customers.Where(predicate).ToList();
            });
        }
    }
}
