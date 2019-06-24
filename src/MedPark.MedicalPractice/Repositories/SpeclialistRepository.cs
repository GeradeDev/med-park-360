using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MedPark.MedicalPractice.Domain;

namespace MedPark.MedicalPractice.Repositories
{
    public class SpeclialistRepository : ISpeclialistRepository
    {
        private MedicalPracticeDbContext _context;

        public SpeclialistRepository(MedicalPracticeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Specialist specilaist)
        {
            await _context.Specialist.AddAsync(specilaist);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Specialist> GetAsync(Guid Id)
        {
            return Task.Run(() =>
            {
                return _context.Specialist.Where(x => x.Id == Id).FirstOrDefault();
            });
        }

        public Task<Specialist> GetAsync(Expression<Func<Specialist, bool>> predicate)
        {
            return Task.Run(() =>
            {
                return _context.Specialist.Where(predicate).FirstOrDefault();
            });
        }

        public async Task UpdateAsync(Specialist specilaist)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Specialist>> BrowseAsync(Expression<Func<Specialist, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return _context.Specialist.Where(predicate).ToList();
            });
        }
    }
}
