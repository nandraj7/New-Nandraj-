using LeadTracker.API;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(LeadTrackerContext context) : base(context)
        {

        }

    }
}
