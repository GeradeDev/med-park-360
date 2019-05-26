using MedPark.CustomersService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> GetAsync(Guid Id);

        Task<Address> GetAsync(Expression<Func<Address, bool>> predicate);

        Task AddAsync(Address customer);

        Task UpdateAsync(Address customer);

        Task DeleteAsync(Guid Id);
    }
}
