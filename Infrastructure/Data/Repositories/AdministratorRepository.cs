using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class AdministratorRepository : GenericRepository<Administrator>, IAdministratorRepository
    {
        private readonly SchoolContext _context;
        public AdministratorRepository(SchoolContext context): base(context)
        {
            _context = context;
        }

        public async Task<Administrator> GetAdministratorByIdAsync(int id)
        {
            return await _context.Administrators
                .Include(p => p.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Administrator>> GetAdministratorsAsync()
        {
            return await _context.Administrators
                .Include(p => p.Person)
                .ToListAsync();
        }
    }
}