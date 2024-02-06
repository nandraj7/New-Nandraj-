﻿using LeadTracker.API;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<string?> GetRoleNameByIdAsync(int? roleId);
    }
}
