using LeadTracker.API;
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

        Task<OrganisationDTO> GetOrganisationByIdAsync(int id);

        Task<IEnumerable<OrganisationDTO>> GetAllOrganisationsAsync();

        Task UpdateOrganisationAsync(int id, Core.DTO.OrganisationDTO organisation);

        Task DeleteOrganisationAsync(int id);

        //Task<EnquiryDTO> GetEnquiriesByUserIdAndWorkflowIdAsync(int userId, int workflowId);
    }
}
