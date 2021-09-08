using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly SchoolContext _context;
        public TeacherRepository(SchoolContext context): base(context)
        {
            _context = context;
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _context.Teachers
                .Include(p => p.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Teacher>> GetTeachersAsync()
        {
            return await _context.Teachers
                .Include(p => p.Person)
                .ToListAsync();
        }
    }
}