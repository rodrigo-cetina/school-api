using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                .Include(p => p.Group)
                .Include(p => p.Group.Career)
                .Include(p => p.Group.Subject)
                .Include(p => p.Group.Teacher)
                .Include(p => p.Group.Teacher.Person)
                .Include(p => p.Student)
                .Include(p => p.Student.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> ExistsGroupStudentAsync(int groupId, int studentId)
        {
            return await _context.GroupStudents.AnyAsync(p => p.GroupId == groupId && p.StudentId == studentId);
        }

        public async Task<IReadOnlyList<GroupStudent>> GetGroupStudentsAsync()
        {
            return await _context.GroupStudents
                .Include(p => p.Group)
                .Include(p => p.Group.Career)
                .Include(p => p.Group.Subject)
                .Include(p => p.Group.Teacher)
                .Include(p => p.Group.Teacher.Person)
                .Include(p => p.Student)
                .Include(p => p.Student.Person)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<GroupStudent>> GetGroupStudentsByGroupIdAsync(int groupId)
        {
            return await _context.GroupStudents
                .Include(p => p.Group)
                .Include(p => p.Group.Career)
                .Include(p => p.Group.Subject)
                .Include(p => p.Group.Teacher)
                .Include(p => p.Group.Teacher.Person)
                .Include(p => p.Student)
                .Include(p => p.Student.Person)
                .Where(p => p.GroupId == groupId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<GroupStudent>> GetGroupStudentsByStudentIdAsync(int studentId)
        {
            return await _context.GroupStudents
                .Include(p => p.Group)
                .Include(p => p.Group.Career)
                .Include(p => p.Group.Subject)
                .Include(p => p.Group.Teacher)
                .Include(p => p.Group.Teacher.Person)
                .Include(p => p.Student)
                .Include(p => p.Student.Person)
                .Where(p => p.StudentId == studentId)
                .ToListAsync();
        }
    }
}