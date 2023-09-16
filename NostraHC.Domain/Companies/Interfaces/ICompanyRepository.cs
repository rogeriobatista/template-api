using NostraHC.Domain.Companies.Entities;
using NostraHC.Shared.Repository;

namespace NostraHC.Domain.Companies.Interfaces
{
    public interface ICompanyRepository : IBaseRepository<long, Company>
    {
    }
}
