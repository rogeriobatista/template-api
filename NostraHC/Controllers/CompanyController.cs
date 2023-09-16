using Microsoft.AspNetCore.Mvc;
using NostraHC.Controllers;
using NostraHC.Domain.Companies.Dtos;
using NostraHC.Domain.Companies.Entities;
using NostraHC.Domain.Companies.Interfaces;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : BaseApiController<long, Company, CompanyDto, CompanyResponseDto>
    {
        public CompanyController(ICompanyService companieService): base(companieService)
        {
        }
    }
}
