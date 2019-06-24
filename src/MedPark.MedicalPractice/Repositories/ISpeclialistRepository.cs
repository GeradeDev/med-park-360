using MedPark.MedicalPractice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Repositories
{
    public interface ISpeclialistRepository
    {
        Task<Specialist> GetAsync(Guid Id);

        Task<Specialist> GetAsync(Expression<Func<Specialist, bool>> predicate);

        Task AddAsync(Specialist specilaist);

        Task UpdateAsync(Specialist specilaist);

        Task DeleteAsync(Guid Id);

        Task<List<Specialist>> BrowseAsync(Expression<Func<Specialist, bool>> predicate);
    }
}
