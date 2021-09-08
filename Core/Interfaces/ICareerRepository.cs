using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICareerRepository
    {
        Task<Career> GetCareerByIdAsync(int id);
        Task<IReadOnlyList<Career>> GetCareersAsync();
    }
}