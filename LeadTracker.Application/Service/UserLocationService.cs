using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Core.Extension;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class UserLocationService : IUserLocationService
    {
        private readonly IUserLocationRepository _userLocationRepository;
       
        public UserLocationService(IUserLocationRepository userLocationRepository)
        {
            _userLocationRepository = userLocationRepository;
           
        }

        public async Task CreateUserLocation(UserLocationDTO userLocation , int userId, int orgId)
        {


            UserLocation location = new UserLocation
            {
                UserId = userId,
                CurrentLatitude = userLocation.CurrentLatitude,
                CurrentLongitude = userLocation.CurrentLongitude,
                OrgId = orgId,
                Date = DateTime.UtcNow,
                StartLatitude = userLocation.CurrentLatitude,
                StartLongitude = userLocation.CurrentLongitude
            };

            _userLocationRepository.CreateUserLocationAsync(location);
        }

    }
}
