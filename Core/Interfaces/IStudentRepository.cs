using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IStudentRepository: IGenericRepository<Student>
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<IReadOnlyList<Student>> GetStudentsAsync();
    }
}