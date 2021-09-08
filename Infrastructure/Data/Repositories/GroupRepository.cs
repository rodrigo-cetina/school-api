using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                .Include(p => p.CareerId)
                .Include(p => p.SubjectId)
                .Include(p => p.TeacherId)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Group>> GetGroupsAsync()
        {
            return await _context.Groups
                .Include(p => p.CareerId)
                .Include(p => p.SubjectId)
                .Include(p => p.TeacherId)
                .ToListAsync();
        }
    }
}