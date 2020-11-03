﻿// <auto-generated />
using System;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestrutura.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Core.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .HasColumnType("TEXT");

                    b.Property<int>("EstacionamentoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeLogradouro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EstacionamentoId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Core.Entidades.Estacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Avaliacao")
                        .HasColumnType("REAL");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeEstacionamento")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroVagas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumeroVagasDisponiveis")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PrecoHora")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("Core.Entidades.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FormattedAddress")
                        .HasColumnType("TEXT");

                    b.Property<float>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<float>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("NomeEstacionamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeLogradouro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .HasColumnType("TEXT");

                    b.Property<double>("PrecoHora")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Core.Entidades.Logradouro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoLogradouro")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Logradouros");
                });

            modelBuilder.Entity("Core.Entidades.OrdemAggregate.Ordem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("DataOrdem")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailComprador")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatusOrdem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ordens");
                });

            modelBuilder.Entity("Core.Entidades.OrdemAggregate.VagaAlugada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrdemId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrdemId");

                    b.ToTable("VagaAlugadas");
                });

            modelBuilder.Entity("Core.Entidades.Endereco", b =>
                {
                    b.HasOne("Core.Entidades.Estacionamento", "Estacionamento")
                        .WithOne("Endereco")
                        .HasForeignKey("Core.Entidades.Endereco", "EstacionamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entidades.Logradouro", b =>
                {
                    b.HasOne("Core.Entidades.Endereco", "Endereco")
                        .WithOne("Logradouro")
                        .HasForeignKey("Core.Entidades.Logradouro", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entidades.OrdemAggregate.VagaAlugada", b =>
                {
                    b.HasOne("Core.Entidades.OrdemAggregate.Ordem", null)
                        .WithMany("VagaAlugadas")
                        .HasForeignKey("OrdemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Core.Entidades.OrdemAggregate.VagaOrdenada", "VagaOrdenada", b1 =>
                        {
                            b1.Property<int>("VagaAlugadaId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Bairro")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Cep")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Cidade")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Estado")
                                .HasColumnType("TEXT");

                            b1.Property<string>("NomeEstacionamento")
                                .HasColumnType("TEXT");

                            b1.Property<string>("NomeLogradouro")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .HasColumnType("TEXT");

                            b1.HasKey("VagaAlugadaId");

                            b1.ToTable("VagaAlugadas");

                            b1.WithOwner()
                                .HasForeignKey("VagaAlugadaId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
