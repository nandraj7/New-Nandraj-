using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class ZoneService : IZoneService
    {
        private readonly IZoneRepository _zonerepository;
        private readonly IMapper _mappingProfile;

        public ZoneService(IZoneRepository zonerepository, IMapper mappingProfile)
        {
            _zonerepository = zonerepository;
            _mappingProfile = mappingProfile;
        }

        public async Task CreateZone(ZoneDTO zone)
        {
            var zon = _mappingProfile.Map<Zone>(zone);
            await _zonerepository.CreateAsync(zon).ConfigureAwait(false);
        }

        public async Task<ZoneDTO> GetZoneByIdAsync(int id)
        {
            var zone = await _zonerepository.GetByIdAsync(id);

            var zoneDTO = _mappingProfile.Map<ZoneDTO>(zone);
            return zoneDTO;
        }

        public async Task<IEnumerable<ZoneDTO>> GetAllZoneAsync()
        {
            var zones = await _zonerepository.GetAllAsync();
            var zonesDTO = _mappingProfile.Map<List<ZoneDTO>>(zones);
            return zonesDTO.ToList();
        }

        public async Task UpdateZoneAsync(int id, ZoneDTO zone)
        {
            var existingZone = await _zonerepository.GetByIdAsync(id);
            _mappingProfile.Map(zone, existingZone);
            await _zonerepository.UpdateAsync(existingZone);

            //var zon = _mappingProfile.Map<Zone>(zone);
            //await _zonerepository.UpdateAsync(zon);
        }

        public async Task DeleteZoneAsync(int id)
        {
            var zone = await _zonerepository.GetByIdAsync(id);
            if (zone != null)
            {
                await _zonerepository.DeleteAsync(id);
            }
        }
    }
}
