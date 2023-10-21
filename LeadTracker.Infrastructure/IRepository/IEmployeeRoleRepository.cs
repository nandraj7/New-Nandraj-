using LeadTracker.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IEmployeeRoleRepository
    {
        Task CreateEmplRoleAsync(EmployeeRole emplRole);

        Task<EmployeeRole> GetEmplRoleByIdAsync(int id);

        Task<IQueryable<EmployeeRole>> GetAllEmplRoleAsync();

        Task UpdateEmplRoleAsync(EmployeeRole emplRole);

        Task DeleteEmplRoleAsync(int id);
    }
}
