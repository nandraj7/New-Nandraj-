using AutoMapper;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.Extension
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrganisationDTO, Organisation>().ReverseMap();

            CreateMap<DTO.AddressDTO, Entities.Address>().ReverseMap();

            CreateMap<DTO.BranchDTO, Entities.Branch>().ReverseMap();

            CreateMap<CodeDTO, Code>().ReverseMap();

            CreateMap<EmployeeDTO, Employee>().ReverseMap();

            CreateMap<PermissionDTO, Permission>().ReverseMap();

            CreateMap<RolePermissionDTO, RolePermission>().ReverseMap();

            CreateMap<RoleDTO, Role>().ReverseMap();
        }

    }
}
