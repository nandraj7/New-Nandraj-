using LeadTracker.API;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class EmployeeRepository : Repository<Employee> , IEmployeeRepository
    {
        private readonly LeadTrackerContext _context;
        public EmployeeRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> GetUserLoginAsync(string mobile, string password)
        {
            var users = _context.Employees.Where(a => a.Mobile == mobile && a.Password == password).ToList();

            return users.FirstOrDefault();
        }

    }
}
