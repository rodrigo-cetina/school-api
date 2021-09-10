using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IScoreRecordRepository: IGenericRepository<ScoreRecord>
    {
        Task<ScoreRecord> GetScoreRecordByIdAsync(int id);
        Task<ScoreRecord> GetScoreRecordAsync(int groupId, int studentId);
        Task<IReadOnlyList<ScoreRecord>> GetScoreRecordsAsync();
        Task<IReadOnlyList<ScoreRecord>> GetScoreRecordsByStudentIdAsync(int studentId);
        Task<IReadOnlyList<ScoreRecord>> GetScoreRecordsByGroupIdAsync(int groupId);
    }
}