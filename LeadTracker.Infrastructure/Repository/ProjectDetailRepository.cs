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
    public class ProjectDetailRepository : Repository<ProjectDetail>, IProjectDetailRepository
    {
        public ProjectDetailRepository(LeadTrackerContext context) : base(context)
        {

        }
    }
}
