using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class ScoreRecordRepository : GenericRepository<ScoreRecord>, IScoreRecordRepository
    {
        private readonly SchoolContext _context;
        public ScoreRecordRepository(SchoolContext context): base(context)
        {
            _context = context;
        }

        public async Task<ScoreRecord> GetScoreRecordByIdAsync(int id)
        {
            return await _context.ScoreRecords
                .Include(p => p.Student)
                .Include(p => p.Student.Person)
                .Include(p => p.Group)
                .Include(p => p.Group.Career)
                .Include(p => p.Group.Subject)
                .Include(p => p.Group.Teacher)
                .Include(p => p.Group.Teacher.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ScoreRecord> GetScoreRecordAsync(int groupId, int studentId)
        {
            return await _context.ScoreRecords.FirstOrDefaultAsync(p => p.GroupId == groupId && p.StudentId == studentId);
        }

        public async Task<IReadOnlyList<ScoreRecord>> GetScoreRecordsAsync()
        {
            return await _context.ScoreRecords
                .Include(p => p.Student)
                .Include(p => p.Student.Person)
                .Include(p => p.Group)
                .Include(p => p.Group.Career)
                .Include(p => p.Group.Subject)
                .Include(p => p.Group.Teacher)
                .Include(p => p.Group.Teacher.Person)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ScoreRecord>> GetScoreRecordsByStudentIdAsync(int studentId)
        {
            return await _context.ScoreRecords
                .Include(p => p.Student)
                .Include(p => p.Student.Person)
                .Include(p => p.Group)
                .Include(p => p.Group.Career)
                .Include(p => p.Group.Subject)
                .Include(p => p.Group.Teacher)
                .Include(p => p.Group.Teacher.Person)
                .Where(p => p.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ScoreRecord>> GetScoreRecordsByGroupIdAsync(int groupId)
        {
            return await _context.ScoreRecords
                .Include(p => p.Student)
                .Include(p => p.Student.Person)
                .Include(p => p.Group)
                .Include(p => p.Group.Career)
                .Include(p => p.Group.Subject)
                .Include(p => p.Group.Teacher)
                .Include(p => p.Group.Teacher.Person)
                .Where(p => p.GroupId == groupId)
                .ToListAsync();
        }
    }
}