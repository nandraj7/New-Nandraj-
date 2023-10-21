using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeadTracker.Infrastructure.Repository
{
    public class OrganisationRepository : Repository<Organisation> , IOrganisationRepository
    {
        private readonly LeadTrackerContext _context;
        public OrganisationRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Lead>> GetLeadsByAssignedToAsync(int employeeId, int workflowId)
        //{
        //    return await _context.Leads
        //        .Where(lead => lead.TrackerFlowId == workflowId && lead.Trackers.Any(tracker => tracker.AssignedTo == employeeId))
        //        .ToListAsync()
        //        .ConfigureAwait(false);
        //}

        //public async Task<IEnumerable<Tracker>> GetTrackersByAssignedToAsync(int employeeId, int workflowId)
        //{
        //    return await _context.Trackers
        //        .Where(tracker => tracker.Enquiry.TrackerFlowId == workflowId && tracker.AssignedTo == employeeId)
        //        .ToListAsync()
        //        .ConfigureAwait(false);
        //}

    }
}
