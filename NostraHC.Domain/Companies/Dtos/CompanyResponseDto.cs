using NostraHC.Domain.Companies.Enums;
using NostraHC.Shared.Dtos;

namespace NostraHC.Domain.Companies.Dtos
{
    public class CompanyResponseDto : BaseResponseDto<long>
    {
        public string Name { get; set; }
        public CompanyStatus Status { get; set; }
    }
}
