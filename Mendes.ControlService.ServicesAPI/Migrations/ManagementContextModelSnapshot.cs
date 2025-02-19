﻿// <auto-generated />
using Mendes.ControlService.ManagementAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mendes.ControlService.ManagementAPI.Migrations
{
    [DbContext(typeof(ManagementContext))]
    partial class ManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mendes.ControlService.ManagementAPI.Abstracts.CustomerBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Telephone1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasDiscriminator<string>("Type").HasValue("CustomerBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Mendes.ControlService.ManagementAPI.Models.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("PayingEntityId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PayingEntityId");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("Mendes.ControlService.ManagementAPI.Models.CompanyCustomer", b =>
                {
                    b.HasBaseType("Mendes.ControlService.ManagementAPI.Abstracts.CustomerBase");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunicipalRegistration")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("Mendes.ControlService.ManagementAPI.Models.IndividualCustomer", b =>
                {
                    b.HasBaseType("Mendes.ControlService.ManagementAPI.Abstracts.CustomerBase");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasDiscriminator().HasValue("Individual");
                });

            modelBuilder.Entity("Mendes.ControlService.ManagementAPI.Models.Proposal", b =>
                {
                    b.HasOne("Mendes.ControlService.ManagementAPI.Abstracts.CustomerBase", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Mendes.ControlService.ManagementAPI.Abstracts.CustomerBase", "PayingEntity")
                        .WithMany()
                        .HasForeignKey("PayingEntityId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Customer");

                    b.Navigation("PayingEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
