using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class CareerRepository : GenericRepository<Career>, ICareerRepository
    {
        private readonly SchoolContext _context;
        public CareerRepository(SchoolContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Career> GetCareerByIdAsync(int id)
        {
            return await _context.Careers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Career>> GetCareersAsync()
        {
            return await _context.Careers.ToListAsync();
        }
    }
}