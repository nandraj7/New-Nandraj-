using AutoMapper;
using LeadTracker.API;
using LeadTracker.Application.IService;
using LeadTracker.Core;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Core.Extension;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Application.Service
{
    public class OrganisationService:IOrgnisationService
    {

        private readonly IOrganisationRepository _organisationrepository; 
        private readonly IMapper _mappingProfile; 

        public OrganisationService(IMapper mappingProfile, IOrganisationRepository orgnisationService) 
        {
            _mappingProfile= mappingProfile;
            _organisationrepository = orgnisationService;

        }
        public async Task CreateOrganisation(Core.DTO.OrganisationDTO organisation)
        {
            var org = _mappingProfile.Map<Organisation>(organisation);
            await _organisationrepository.CreateAsync(org).ConfigureAwait(false); 
        }

        public async Task<OrganisationDTO> GetOrganisationByIdAsync(int id)
        {
            var org = await _organisationrepository.GetByIdAsync(id);

            var orgDTO = _mappingProfile.Map<OrganisationDTO>(org);
            return orgDTO;
        }

        public async Task<IEnumerable<OrganisationDTO>> GetAllOrganisationsAsync()
        {
            var organisations = await _organisationrepository.GetAllAsync();

            var organisationsDTO = _mappingProfile.Map<List<OrganisationDTO>>(organisations);
            return organisationsDTO.ToList();
        }

        public async Task UpdateOrganisationAsync(int id, Core.DTO.OrganisationDTO organisation)
        {
            var existingOrganisation = await _organisationrepository.GetByIdAsync(id);


            _mappingProfile.Map(organisation, existingOrganisation);


            await _organisationrepository.UpdateAsync(existingOrganisation);

        }

        public async Task DeleteOrganisationAsync(int id)
        {
            var organisation = await _organisationrepository.GetByIdAsync(id);
            if (organisation != null)
            {
                await _organisationrepository.DeleteAsync(id);
            }
        }

        //public async Task<EnquiryDTO> GetEnquiriesByUserIdAndWorkflowIdAsync(int userId, int workflowId)
        //{

        //    var leads = await _organisationrepository.GetLeadsByAssignedToAsync(userId, workflowId).ConfigureAwait(false);


        //    var trackers = await _organisationrepository.GetTrackersByAssignedToAsync(userId, workflowId).ConfigureAwait(false);




        //    var enquiryDTO = new EnquiryDTO
        //    {

        //        Leads = _mappingProfile.Map<List<LeadDTO>>(leads).ToList()
        //        //Trackers = _mappingProfile.Map<List<TrackerDTO>>(trackers).ToList(),

        //    };

        //    return enquiryDTO;
        //    }


        }
}
