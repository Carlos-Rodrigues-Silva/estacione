using Core.Entidades.OrdemAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutura.Data.Config
{
    public class VagaAlugadaConfig : IEntityTypeConfiguration<VagaAlugada>
    {
        public void Configure(EntityTypeBuilder<VagaAlugada> builder)
        {
            builder.OwnsOne(v => v.VagaOrdenada, va =>
            {
                va.WithOwner();
            });

            builder.Property(v => v.Preco)
                .HasColumnType("decimal(18,2)");
        }
    }
}
