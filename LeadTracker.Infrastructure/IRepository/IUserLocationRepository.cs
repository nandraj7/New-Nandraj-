using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IUserLocationRepository
    {
        UserLocation GetUserLocation(int userId, int orgId, DateTime todaysDate);

        void UpdateUserLocation(UserLocation location);

        void CreateUserLocation(UserLocation location);

        //Task<List<UserLocation>> GetUserLocationsAsyncByOrgId(int orgId);

        Task<List<UserLocation>> GetUserLocationsAsyncByEmployeeIdsAndOrgId(IEnumerable<int> employeeIds, int orgId);

        List<RoutePathResponseDTO> GetUserPathByCredentialsAsync(RoutePathRequestDTO pathRequest);
    }
}