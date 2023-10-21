using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationrepository;
        private readonly IMapper _mappingProfile;

        public LocationService(IMapper mappingProfile, ILocationRepository locationService)
        {
            _mappingProfile = mappingProfile;
            _locationrepository = locationService;
        }
        public async Task CreateLocation(LocationDTO location)
        {
            var locat = _mappingProfile.Map<Location>(location);
            await _locationrepository.CreateAsync(locat).ConfigureAwait(false);
        }
        public async Task<LocationDTO> GetLocationByIdAsync(int id)
        {
            var location = await _locationrepository.GetByIdAsync(id);

            var locationDTO = _mappingProfile.Map<LocationDTO>(location);
            return locationDTO;
        }
        public async Task<IEnumerable<LocationDTO>> GetAllLocationAsync()
        {
            var locations = await _locationrepository.GetAllAsync();
            var locationsDTO = _mappingProfile.Map<List<LocationDTO>>(locations);
            return locationsDTO.ToList();
        }

        public async Task UpdateLocationAsync(int id, LocationDTO location)
        {
            var existingLocation = await _locationrepository.GetByIdAsync(id);
            _mappingProfile.Map(location, existingLocation);
            await _locationrepository.UpdateAsync(existingLocation);

            //var locat = _mappingProfile.Map<Location>(location);
            //await _locationrepository.UpdateAsync(locat);
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = await _locationrepository.GetByIdAsync(id);
            if (location != null)
            {
                await _locationrepository.DeleteAsync(id);
            }

        }
    }
}
