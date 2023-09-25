using AutoMapper;
using LeadTracker.Application.IService;
using LeadTracker.Core;
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
            var org = _mappingProfile.Map<Core.Entities.Organisation>(organisation);
            await _organisationrepository.CreateAsync(org).ConfigureAwait(false); 
        }

        public async Task<Core.Entities.Organisation> GetOrganisationByIdAsync(int id)
        {
            return await _organisationrepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Core.Entities.Organisation>> GetAllOrganisationsAsync()
        {
            var organisations = await _organisationrepository.GetAllAsync();
            return organisations.ToList();
        }

        public async Task UpdateOrganisationAsync(Core.DTO.OrganisationDTO organisation)
        {
            var org = _mappingProfile.Map<Core.Entities.Organisation>(organisation);
            await _organisationrepository.UpdateAsync(org);
        }

        public async Task DeleteOrganisationAsync(int id)
        {
            var organisation = await _organisationrepository.GetByIdAsync(id);
            if (organisation != null)
            {
                await _organisationrepository.DeleteAsync(id);
            }
        }

    }
}
