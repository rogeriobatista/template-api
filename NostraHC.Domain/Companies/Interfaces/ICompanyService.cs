using NostraHC.Domain.Companies.Dtos;
using Template.Shared.Services;

namespace NostraHC.Domain.Companies.Interfaces
{
    public interface ICompanyService : IBaseService<long, CompanyDto, CompanyResponseDto>
    {
    }
}
