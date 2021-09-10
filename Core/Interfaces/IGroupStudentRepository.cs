using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGroupStudentRepository: IGenericRepository<GroupStudent>
    {
        Task<GroupStudent> GetGroupStudentByIdAsync(int id);
        Task<bool> ExistsGroupStudentAsync(int groupId, int studentId);
        Task<IReadOnlyList<GroupStudent>> GetGroupStudentsAsync();
        Task<IReadOnlyList<GroupStudent>> GetGroupStudentsByGroupIdAsync(int groupId);
        Task<IReadOnlyList<GroupStudent>> GetGroupStudentsByStudentIdAsync(int studentId);
    }
}