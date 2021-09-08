using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITeacherRepository: IGenericRepository<Teacher>
    {
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<IReadOnlyList<Teacher>> GetTeachersAsync();
    }
}