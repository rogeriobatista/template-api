using AutoMapper;
using NostraHC.Domain.Companies.Dtos;
using NostraHC.Domain.Companies.Entities;
using NostraHC.Domain.Companies.Interfaces;
using NostraHC.Shared.Services;

namespace NostraHC.Domain.Companies.Services
{
    public class CompanyService : BaseService<long, Company, CompanyDto, CompanyResponseDto>, ICompanyService
    {
        public CompanyService(IMapper mapper, ICompanyRepository companieRepository): base(mapper, companieRepository) {}
    }
}
