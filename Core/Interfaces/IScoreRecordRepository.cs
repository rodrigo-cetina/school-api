using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IScoreRecordRepository: IGenericRepository<ScoreRecord>
    {
        Task<ScoreRecord> GetScoreRecordByIdAsync(int id);
        Task<IReadOnlyList<ScoreRecord>> GetScoreRecordsAsync();
    }
}