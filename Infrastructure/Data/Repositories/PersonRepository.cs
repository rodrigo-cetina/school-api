using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly SchoolContext _context;
        public PersonRepository(SchoolContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Person> GetPersonByEmailAsync(string email)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<IReadOnlyList<Person>> GetPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }
    }
}