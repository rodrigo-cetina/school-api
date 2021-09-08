using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly SchoolContext _context;
        public StudentRepository(SchoolContext context): base(context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .Include(p => p.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Student>> GetStudentsAsync()
        {
            return await _context.Students
                .Include(p => p.Person)
                .ToListAsync();
        }
    }
}