using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGroupStudentRepository: IGenericRepository<GroupStudent>
    {
        Task<GroupStudent> GetGroupStudentByIdAsync(int id);
        Task<IReadOnlyList<GroupStudent>> GetGroupStudentsAsync();
    }
}