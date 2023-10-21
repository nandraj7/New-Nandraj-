using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IOrganisationRepository : IRepository<Organisation>
    {
        //Task<IEnumerable<Lead>> GetLeadsByAssignedToAsync(int employeeId, int workflowId);

        //Task<IEnumerable<Tracker>> GetTrackersByAssignedToAsync(int employeeId, int workflowId);

    }
}
