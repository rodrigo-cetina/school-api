using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                .Include(p => p.StudentId)
                .Include(p => p.GroupId)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ScoreRecord>> GetScoreRecordsAsync()
        {
            return await _context.ScoreRecords
                .Include(p => p.StudentId)
                .Include(p => p.GroupId)
                .ToListAsync();
        }
    }
}