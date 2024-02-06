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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
         private readonly LeadTrackerContext _context;
        public ProjectRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task RegisterNewProjectAsync(Project[] projects)
        {
            foreach (var entity in projects)
            {
                entity.IsActive = true;
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
                entity.IsDeleted = false;

                await (_context as LeadTrackerContext).Projects.AddAsync(entity).ConfigureAwait(false);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

    }
}
