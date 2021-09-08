using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ISubjectRepository: IGenericRepository<Subject>
    {
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<IReadOnlyList<Subject>> GetSubjectsAsync();
    }
}