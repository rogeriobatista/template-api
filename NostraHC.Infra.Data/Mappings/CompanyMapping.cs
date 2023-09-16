using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NostraHC.Domain.Companies.Entities;
using NostraHC.Shared.Configurations;
using NostraHC.Shared.Resources;

namespace NostraHC.Infra.Data.Mappings
{
    public class CompanyMapping : EntityTypeConfiguration<Company>
    {
        public override void Map(EntityTypeBuilder<Company> builder)
        {
            builder.Property(_ => _.Name).IsRequired();

            builder.Property(_ => _.Status).IsRequired();

            builder.Property(_ => _.CreatedAt).IsRequired();

            builder.Property(_ => _.UpdateAt).IsRequired();

            builder.Ignore(_ => _.CascadeMode);
            builder.Ignore(_ => _.ValidationResult);

            builder.ToTable(StringResource.Companies);
        }
    }
}
