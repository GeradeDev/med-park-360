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
            return Task.Run(() =>
            {
                _DbContext.Customers.Add(customer);
                _DbContext.SaveChanges();
            });
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer customer)
        {
            return Task.Run(() =>
            {
                _DbContext.Customers.Add(customer);
                _DbContext.SaveChanges();
            });
        }

        public Task<Customer> GetAsync(Guid Id)
        {
            return Task.Run(() =>
            {
                return _DbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
            });
        }

        public Task<Customer> GetAsync(Expression<Func<Customer, bool>> predicate)
        {
            return Task.Run(() =>
            {
                return _DbContext.Customers.Where(predicate).FirstOrDefault();
            });
        }
    }
}
