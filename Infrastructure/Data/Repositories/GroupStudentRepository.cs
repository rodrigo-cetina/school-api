using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class GroupStudentRepository : GenericRepository<GroupStudent>, IGroupStudentRepository
    {
        private readonly SchoolContext _context;
        public GroupStudentRepository(SchoolContext context): base(context)
        {
            _context = context;
        }

        public async Task<GroupStudent> GetGroupStudentByIdAsync(int id)
        {
            return await _context.GroupStudents
                .Include(p => p.GroupId)
                .Include(p => p.StudentId)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<GroupStudent>> GetGroupStudentsAsync()
        {
            return await _context.GroupStudents
                .Include(p => p.GroupId)
                .Include(p => p.StudentId)
                .ToListAsync();
        }
    }
}