using AutoMapper;
using LeadTracker.API.Entities;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Extension;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _holidayRepository;
        private readonly IMapper _mappingProfile;


        public HolidayService(IHolidayRepository holidayRepository, IMapper mappingProfile)
        {
            _holidayRepository = holidayRepository;
            _mappingProfile = mappingProfile;

        }

        public async Task CreateNewHoliday(HolidayDTO holiday, int orgId, int userId)
        {
            var day = new List<Holiday>();
            day.Add(new Holiday()
            {
                Date = holiday.Date,
                Day = holiday.Day,
                HolidayReason = holiday.HolidayReason,
                OrgId = orgId,
                Status = true,
                IsActive = true,
                IsDeleted = false,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                ModifiedBy = userId,
                ModifiedDate = DateTime.Now,
            });
            await _holidayRepository.CreateNewHolidayAsync(day).ConfigureAwait(false);

        }

        public async Task<IEnumerable<HolidayDTO>> GetAllHolidayAsync()
        {
            var holiday = await _holidayRepository.GetAllAsync();
            var filteredHoliday = holiday.Where(e => e.IsActive == true).ToList();
            var holidayDTO = _mappingProfile.Map<List<HolidayDTO>>(filteredHoliday);
            return holidayDTO.ToList();
        }


        public async Task<HolidayDTO> GetHodidayByIdAsync(int id)
        {
            var holiday = await _holidayRepository.GetByIdAsync(id);
            var holidayDTO = _mappingProfile.Map<HolidayDTO>(holiday);
            return holidayDTO;
        }

        public async Task<Holiday> UpdateHolidayAsync(int id, NewHolidayDTO holiday)
        {
            var existingHoliday = await _holidayRepository.GetByIdAsync(id);
            if (existingHoliday != null)
            {
                existingHoliday.Date = holiday.Date;
                existingHoliday.Day = holiday.Day;
                existingHoliday.HolidayReason = holiday.HolidayReason;
                existingHoliday.Status = true;
                
            }
            //var holidays = _mappingProfile.Map(holiday, existingHoliday);

            await _holidayRepository.UpdateAsync(existingHoliday);

            return existingHoliday;
        }

        public async Task DeleteHolidayAsync(int id)
        {
            var holiday = await _holidayRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (holiday != null)
            {
                await _holidayRepository.DeleteAsync(id);
            }
        }


    }
}
