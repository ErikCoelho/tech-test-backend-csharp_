﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Infra.Contexts;

#nullable disable

namespace Store.Infra.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Store.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<decimal>("Preco")
                        .HasMaxLength(60)
                        .HasColumnType("DECIMAL")
                        .HasColumnName("Preco");

                    b.Property<int>("QuantidadeEstoque")
                        .HasMaxLength(60)
                        .HasColumnType("INT")
                        .HasColumnName("QuantidadeEstoque");

                    b.Property<decimal>("ValorTotal")
                        .HasMaxLength(60)
                        .HasColumnType("DECIMAL")
                        .HasColumnName("ValorTotal");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
