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
    public interface ILocationService
    {
        Task CreateLocation(LocationDTO location);

        Task<LocationDTO> GetLocationByIdAsync(int id);

        Task<IEnumerable<LocationDTO>> GetAllLocationAsync();

        Task UpdateLocationAsync(int id, LocationDTO location);

        Task DeleteLocationAsync(int id);
    }
}
