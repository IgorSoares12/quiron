using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiron.Domain.Entities;

namespace Quiron.Data.Configuration
{
    public class EspacoConfig : IEntityTypeConfiguration<Espaco>
    {
        public void Configure(EntityTypeBuilder<Espaco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Descricao).IsRequired();
        }
    }
}