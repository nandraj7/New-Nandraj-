using LeadTracker.API.Entities;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IHolidayService
    {
        Task CreateNewHoliday(HolidayDTO holiday, int orgId, int userId);
        Task<IEnumerable<HolidayDTO>> GetAllHolidayAsync();
        Task<HolidayDTO> GetHodidayByIdAsync(int id);
        Task<Holiday> UpdateHolidayAsync(int id, NewHolidayDTO holiday);

        Task DeleteHolidayAsync(int id);
    }
}
