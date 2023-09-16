using Microsoft.EntityFrameworkCore;
using NostraHC.Infra.Data.Mappings;
using NostraHC.Shared.Extensions;

namespace NostraHC.Infra.Data.Contexts
{
    public class NostraHCContext : DbContext
    {
        public NostraHCContext(DbContextOptions<NostraHCContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new CompanyMapping());
        }
    }
}
