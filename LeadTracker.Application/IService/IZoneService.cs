using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IZoneService
    {
        Task CreateZone(ZoneDTO zone);

        Task<ZoneDTO> GetZoneByIdAsync(int id);

        Task<IEnumerable<ZoneDTO>> GetAllZoneAsync();

        Task UpdateZoneAsync(int id, ZoneDTO zone);

        Task DeleteZoneAsync(int id);
    }
}
