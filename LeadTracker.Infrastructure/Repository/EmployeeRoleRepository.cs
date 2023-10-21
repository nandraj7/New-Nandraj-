using LeadTracker.API;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class EmployeeRoleRepository : IEmployeeRoleRepository
    {
        private readonly LeadTrackerContext _context;

        public EmployeeRoleRepository(LeadTrackerContext context)
        {
            _context = context;
        }

        public async Task CreateEmplRoleAsync(EmployeeRole emplRole)
        {
            await _context.Set<EmployeeRole>().AddAsync(emplRole).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<EmployeeRole> GetEmplRoleByIdAsync(int id)
        {
            return await _context.Set<EmployeeRole>().FindAsync(id);
        }

        public async Task<IQueryable<EmployeeRole>> GetAllEmplRoleAsync()
        { 
            return await Task.FromResult(_context.Set<EmployeeRole>().AsNoTracking());
        }



        public async Task UpdateEmplRoleAsync(EmployeeRole emplRole)
        {
            _context.Set<EmployeeRole>().Update(emplRole);
            await _context.SaveChangesAsync();

        }
  

       public async Task DeleteEmplRoleAsync(int id)
        {
            var emplRole = await GetEmplRoleByIdAsync(id);
            emplRole.IsActive = false;
            emplRole.IsDeleted = true;
            await UpdateEmplRoleAsync(emplRole);
            await _context.SaveChangesAsync();
        }



       
    }
}
