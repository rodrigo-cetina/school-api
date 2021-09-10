using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        private readonly SchoolContext _context;
        public GroupRepository(SchoolContext context): base(context)
        {
            _context = context;
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _context.Groups
                .Include(p => p.Career)
                .Include(p => p.Subject)
                .Include(p => p.Teacher)
                .Include(p => p.Teacher.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Group>> GetGroupsAsync()
        {
            return await _context.Groups
                .Include(p => p.Career)
                .Include(p => p.Subject)
                .Include(p => p.Teacher)
                .Include(p => p.Teacher.Person)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Group>> GetGroupsByTeacherIdAsync(int teacherId)
        {
            return await _context.Groups
                .Include(p => p.Career)
                .Include(p => p.Subject)
                .Include(p => p.Teacher)
                .Include(p => p.Teacher.Person)
                .Where(p => p.TeacherId == teacherId)
                .ToListAsync();
        }
    }
}