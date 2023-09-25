using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class BranchRepository : Repository<Branch> , IBranchRepository
    {
        public BranchRepository(LeadTrackerContext context) : base(context)
        {

        }
    }
}
