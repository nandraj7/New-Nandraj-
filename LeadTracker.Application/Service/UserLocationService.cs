using AutoMapper;
using DocuSign.eSign.Model;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Core.Extension;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
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
        private readonly IMapper _mappingProfile;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRoleRepository _roleRepository;


        public UserLocationService(IUserLocationRepository userLocationRepository, IMapper mappingProfile, IEmployeeRepository employeeRepository, IRoleRepository roleRepository)
        {
            _userLocationRepository = userLocationRepository;
            _mappingProfile = mappingProfile;
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
        }




        public async Task<UserLocationDTO> UpdateOrCreateUserLocation(UserLocationDTO userLocation, int userId, int orgId)
        {
            var todaysDate = DateTime.Now.Date;

            var existingUserLocation = _userLocationRepository.GetUserLocation(userId, orgId, todaysDate);

            if (existingUserLocation != null && existingUserLocation.Date.Value.Date == DateTime.Now.Date)
            {

                UserLocation newLocation = new UserLocation
                {
                    UserId = userId,
                    CurrentLatitude = userLocation.CurrentLatitude,
                    CurrentLongitude = userLocation.CurrentLongitude,
                    OrgId = orgId,
                    Date = DateTime.Now,
                    StartLatitude = existingUserLocation.StartLatitude,
                    StartLongitude = existingUserLocation.StartLongitude,
                };

                _userLocationRepository.CreateUserLocation(newLocation);
            }
            else
            {

                UserLocation newLocation = new UserLocation
                {
                    UserId = userId,
                    CurrentLatitude = userLocation.CurrentLatitude,
                    CurrentLongitude = userLocation.CurrentLongitude,
                    OrgId = orgId,
                    Date = DateTime.Now,
                    StartLatitude = userLocation.CurrentLatitude,
                    StartLongitude = userLocation.CurrentLongitude,
                };

                _userLocationRepository.CreateUserLocation(newLocation);
            }

            return userLocation;
        }

        public async Task<IEnumerable<UserLocationResponseDTO>> GetAllUserLocationAsync(int orgId, int userId)
        {
            var employees = _employeeRepository.GetEmployeesByUserIdAsync(userId, orgId);
            var employeeIds = employees.Select(e => e.EmployeeId);

            var userLocations = await _userLocationRepository.GetUserLocationsAsyncByEmployeeIdsAndOrgId(employeeIds, orgId);
            var userLocationResponseDTOs = new List<UserLocationResponseDTO>();


            foreach (var userLocation in userLocations)
            {
                var userLocationResponseDTO = _mappingProfile.Map<UserLocationResponseDTO>(userLocation);
                userLocationResponseDTO.Employee = _mappingProfile.Map<EmployeeDTO>(
                    await _employeeRepository.GetByIdAsync(userLocation.UserId ?? 0)
                );

                var roleName = await _roleRepository.GetRoleNameByIdAsync(userLocationResponseDTO.Employee.RoleId ?? 0);
                userLocationResponseDTO.Employee.RoleName = roleName;

                userLocationResponseDTOs.Add(userLocationResponseDTO);
            }

            return userLocationResponseDTOs;
        }

        public async Task<IEnumerable<RoutePathResponseDTO>> GetUserPathAsync(RoutePathRequestDTO pathRequest)
        {
            try
            {
                var userPath = _userLocationRepository.GetUserPathByCredentialsAsync(pathRequest);

                if (userPath == null)
                {
                    return null;
                }

                var userLocationDto = _mappingProfile.Map<List<RoutePathResponseDTO>>(userPath).ToList();

                return userLocationDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }

}
