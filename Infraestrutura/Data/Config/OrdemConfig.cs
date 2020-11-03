using Core.Entidades.OrdemAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutura.Data.Config
{
    public class OrdemConfig : IEntityTypeConfiguration<Ordem>
    {
        public void Configure(EntityTypeBuilder<Ordem> builder)
        {
            builder.Property(s => s.StatusOrdem)
                .HasConversion(
                o => o.ToString(),
                o => (StatusOrdem)Enum.Parse(typeof(StatusOrdem), o));

            builder.HasMany(o => o.VagaAlugadas).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
