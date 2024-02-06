using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly LeadTrackerContext _context;
        public RoleRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }


        public async Task<string?> GetRoleNameByIdAsync(int? roleId)
        {
            return await _context.Roles
                .Where(r => r.Id == roleId)
                .Select(r => r.Name)
                .FirstOrDefaultAsync();
        }

    }
}