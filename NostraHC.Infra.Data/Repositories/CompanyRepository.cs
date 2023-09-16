using NostraHC.Domain.Companies.Entities;
using NostraHC.Domain.Companies.Interfaces;
using NostraHC.Infra.Data.Contexts;
using NostraHC.Shared.Repository;

namespace NostraHC.Infra.Data.Repositories
{
    public class CompanyRepository : BaseRepository<long, Company>, ICompanyRepository
    {
        public CompanyRepository(NostraHCContext context) : base(context)
        {
        }
    }
}
