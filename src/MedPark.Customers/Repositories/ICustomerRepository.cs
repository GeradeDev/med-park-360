using MedPark.CustomersService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(Guid Id);

        Task<Customer> GetAsync(Expression<Func<Customer, bool>> predicate);

        Task AddAsync(Customer customer);

        Task UpdateAsync(Customer customer);

        Task DeleteAsync(Guid Id);
    }
}
