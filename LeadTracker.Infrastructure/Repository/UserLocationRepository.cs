using LeadTracker.API;
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
    public class UserLocationRepository : IUserLocationRepository
    {
        public readonly LeadTrackerContext _context;

        public UserLocationRepository(LeadTrackerContext context)
        {
            this._context = context;
        }


        public async Task CreateUserLocationAsync(UserLocation location)
        {
            await _context.UserLocations.AddAsync(location).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }


    }
}
