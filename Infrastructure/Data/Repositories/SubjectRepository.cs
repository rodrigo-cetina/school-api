using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly SchoolContext _context;
        public SubjectRepository(SchoolContext context): base(context)
        {
            _context = context;
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _context.Subjects
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Subject>> GetSubjectsAsync()
        {
            return await _context.Subjects
                .ToListAsync();
        }
    }
}