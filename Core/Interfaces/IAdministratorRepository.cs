using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAdministratorRepository: IGenericRepository<Administrator>
    {
        Task<Administrator> GetAdministratorByIdAsync(int id);
        Task<IReadOnlyList<Administrator>> GetAdministratorsAsync();
    }
}