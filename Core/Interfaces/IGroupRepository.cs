using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGroupRepository: IGenericRepository<Group>
    {
        Task<Group> GetGroupByIdAsync(int id);
        Task<IReadOnlyList<Group>> GetGroupsAsync();
        Task<IReadOnlyList<Group>> GetGroupsByTeacherIdAsync(int teacherId);
    }
}