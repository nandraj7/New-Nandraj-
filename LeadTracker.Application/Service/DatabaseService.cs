using LeadTracker.API.Entities;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class DatabaseService : IDatabaseService
    {
        private readonly LeadTrackerContext _context;

        public DatabaseService(LeadTrackerContext context)
        {
            _context = context;
        }

        public SystemConfiguration GetWeekendConfig()
        {
            return _context.SystemConfigurations
                .FirstOrDefault(config => config.KeyDetail == "Weekend" && config.OrgId == 1);
        }

        public Holiday GetHoliday()
        {
            return _context.Holidays.FirstOrDefault(h => h.Date == DateTime.Today && h.OrgId == 1);
        }
    }

}
