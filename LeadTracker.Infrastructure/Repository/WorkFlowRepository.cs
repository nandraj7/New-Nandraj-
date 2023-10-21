using LeadTracker.API;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class WorkFlowRepository : Repository<WorkFlow>, IWorkFlowRepository
    {
        public WorkFlowRepository(LeadTrackerContext context) : base(context)
        {

        }

    }
}
