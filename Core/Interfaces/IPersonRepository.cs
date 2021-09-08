using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<Person> GetPersonByIdAsync(int id);
        Task<Person> GetPersonByEmailAsync(string email);
        Task<IReadOnlyList<Person>> GetPersonsAsync();
    }
}