﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiTenant.Catalog.Infrastructure.Migrations.SqlServer;

#nullable disable

namespace MultiTenant.Catalog.Infrastructure.Migrations.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerCatalogContext))]
    [Migration("20220429154810_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Business", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Business", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BusinessId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VatNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("BusinessId1");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("VatNumber")
                        .IsUnique()
                        .HasFilter("[VatNumber] IS NOT NULL");

                    b.ToTable("Organizations", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Expiry")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDemoPlan")
                        .HasColumnType("bit");

                    b.Property<int>("MaxDatabaseSize")
                        .HasColumnType("int");

                    b.Property<int>("MaxStorageSize")
                        .HasColumnType("int");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DatabaseProvider")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int");

                    b.Property<string>("ServerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServerPort")
                        .HasColumnType("int");

                    b.Property<int>("ServerType")
                        .HasColumnType("int");

                    b.Property<string>("ServerUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Resources", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Expiry")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PlanId");

                    b.ToTable("Subscriptions", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DatabaseProvider")
                        .HasColumnType("int");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConnectionString")
                        .IsUnique();

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ResourceId");

                    b.ToTable("Tenants", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Organization", b =>
                {
                    b.HasOne("MultiTenant.Catalog.Domain.Entities.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenant.Catalog.Domain.Entities.Business", null)
                        .WithMany("Organizations")
                        .HasForeignKey("BusinessId1");

                    b.OwnsMany("MultiTenant.Catalog.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("OrganizationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("OrganizationId");

                            b1.ToTable("Address");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationId");
                        });

                    b.OwnsOne("MultiTenant.Catalog.Domain.ValueObjects.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("OrganizationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Website")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrganizationId");

                            b1.ToTable("Organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Business");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Subscription", b =>
                {
                    b.HasOne("MultiTenant.Catalog.Domain.Entities.Organization", "Organization")
                        .WithMany("Subscriptions")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenant.Catalog.Domain.Entities.Plan", "Plan")
                        .WithMany("Subscriptions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Tenant", b =>
                {
                    b.HasOne("MultiTenant.Catalog.Domain.Entities.Organization", "Organization")
                        .WithOne("Tenant")
                        .HasForeignKey("MultiTenant.Catalog.Domain.Entities.Tenant", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenant.Catalog.Domain.Entities.Resource", "Resource")
                        .WithMany("Tenants")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Business", b =>
                {
                    b.Navigation("Organizations");
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Organization", b =>
                {
                    b.Navigation("Subscriptions");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Plan", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Resource", b =>
                {
                    b.Navigation("Tenants");
                });
#pragma warning restore 612, 618
        }
    }
}
