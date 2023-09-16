using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NostraHC.Shared.Configurations
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
