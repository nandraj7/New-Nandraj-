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
        public EmployeeRepository(LeadTrackerContext context) : base(context)
        {

        }
    }
}
