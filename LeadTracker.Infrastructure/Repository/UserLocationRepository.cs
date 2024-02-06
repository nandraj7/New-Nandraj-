using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeadTracker.Infrastructure.Repository
{
    public class UserLocationRepository : IUserLocationRepository
    {
        public readonly LeadTrackerContext _context;

        public UserLocationRepository(LeadTrackerContext context)
        {
            this._context = context;
        }

        //public UserLocation GetUserLocation(int userId, int orgId, DateTime todaysDate)
        //{
        //    return _context.UserLocations
        //        .FirstOrDefault(ul => ul.UserId == userId && ul.OrgId == orgId && ul.Date == todaysDate);
        //}

        public UserLocation GetUserLocation(int userId, int orgId, DateTime todaysDate)
        {
            return _context.UserLocations
                .FirstOrDefault(ul => ul.UserId == userId &&
                                       ul.OrgId == orgId &&
                                       EF.Functions.DateDiffDay(ul.Date, todaysDate) == 0);
        }


        public void UpdateUserLocation(UserLocation location)
        {
            _context.UserLocations.Update(location);
            _context.SaveChanges();
        }

        public void CreateUserLocation(UserLocation location)
        {
            _context.UserLocations.Add(location);
            _context.SaveChanges();
        }



        //public async Task<List<UserLocation>> GetUserLocationsAsyncByOrgId(int orgId)
        //{
        //    return await _context.UserLocations
        //        .Where(ul => ul.OrgId == orgId)
        //        .ToListAsync();
        //}

        //public async Task<List<UserLocation>> GetUserLocationsAsyncByOrgId(int orgId)
        //{
        //    var latestUserLocations = await _context.UserLocations
        //        .Where(ul => ul.OrgId == orgId)
        //        .GroupBy(ul => ul.UserId)
        //        .Select(g => g.OrderByDescending(ul => ul.Date).FirstOrDefault())
        //        .ToListAsync();

        //    return latestUserLocations;
        //}

        public async Task<List<UserLocation>> GetUserLocationsAsyncByEmployeeIdsAndOrgId(IEnumerable<int> employeeIds, int orgId)
        {
            var employeeIdsList = employeeIds.ToList();

            var latestUserLocations = await _context.UserLocations
                .Where(ul => employeeIdsList.Contains(ul.UserId ?? 0) && ul.OrgId == orgId)
                .GroupBy(ul => ul.UserId)
                .Select(g => g.OrderByDescending(ul => ul.Date).FirstOrDefault())
                .ToListAsync();

            return latestUserLocations;
        }

        //public async Task<List<UserLocation>> GetUserPathByCredentialsAsync(RoutePathRequestDTO pathRequest, int orgId)
        //{
        //    var userPath = await _context.UserLocations
        //        .Where(ul => ul.UserId == pathRequest.UserId &&
        //                     ul.Date >= pathRequest.StartDate &&
        //                     ul.Date <= pathRequest.EndDate &&
        //                     ul.OrgId == orgId)
        //        .OrderBy(ul => ul.Date)
        //        .ToListAsync();

        //    return userPath;
        //}


        public List<RoutePathResponseDTO> GetUserPathByCredentialsAsync(RoutePathRequestDTO pathRequest)
        {
            try
            {
                var defFromDt = DateTime.Now.Date;
                var defToDt = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                pathRequest.StartDate = pathRequest.StartDate == DateTime.MinValue ? defFromDt : pathRequest.StartDate;
                pathRequest.EndDate = pathRequest.EndDate == DateTime.MinValue ? defToDt : pathRequest.EndDate;
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@UserId", pathRequest.UserId),
                    new SqlParameter("@StartDate", pathRequest.StartDate),
                    new SqlParameter("@EndDate", pathRequest.EndDate)
                };
                var result = _context.Set<RoutePathResponseDTO>()
                    .FromSqlRaw("spGetRoutePathOfUser @UserId, @StartDate, @EndDate", parameters.ToArray())
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




    }
}