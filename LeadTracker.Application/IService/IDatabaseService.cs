using LeadTracker.API.Entities;
using LeadTracker.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IDatabaseService
    {
        SystemConfiguration GetWeekendConfig();
        Holiday GetHoliday();
    }
}
