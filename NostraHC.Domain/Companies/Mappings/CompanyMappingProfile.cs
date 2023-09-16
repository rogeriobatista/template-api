using AutoMapper;
using NostraHC.Domain.Companies.Dtos;
using NostraHC.Domain.Companies.Entities;

namespace NostraHC.Domain.Companies.Mappings
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ReverseMap()
                .PreserveReferences()
                .MaxDepth(1);

            CreateMap<Company, CompanyResponseDto>()
                .ForMember(_ => _.Errors, x => x.MapFrom(_ => _.ValidationResult.Errors))
                .PreserveReferences()
                .MaxDepth(1);
        }
    }
}
