using NostraHC.Domain.Companies.Enums;

namespace NostraHC.Domain.Companies.Dtos
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public CompanyStatus Status { get; set; }

    }
}
