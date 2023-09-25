using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Application.IService
{
    public interface IOrgnisationService
    {
        Task CreateOrganisation(Core.DTO.OrganisationDTO organisation);

        Task<Core.Entities.Organisation> GetOrganisationByIdAsync(int id);

        Task<IEnumerable<Core.Entities.Organisation>> GetAllOrganisationsAsync();

        Task UpdateOrganisationAsync(Core.DTO.OrganisationDTO organisation);

        Task DeleteOrganisationAsync(int id);
    }
}
