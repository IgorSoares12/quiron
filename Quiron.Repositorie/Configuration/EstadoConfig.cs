﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiron.Domain.Entities;

namespace Quiron.Data.Configuration
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Uf).IsRequired();
            builder.Property(e => e.Descricao).IsRequired();
        }
    }
}