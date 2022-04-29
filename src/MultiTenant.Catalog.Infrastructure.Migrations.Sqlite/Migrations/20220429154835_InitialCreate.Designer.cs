﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiTenant.Catalog.Infrastructure.Migrations.Sqlite;

#nullable disable

namespace MultiTenant.Catalog.Infrastructure.Migrations.Sqlite.Migrations
{
    [DbContext(typeof(SqliteCatalogContext))]
    [Migration("20220429154835_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Business", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Business", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BusinessId1")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VatNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("BusinessId1");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("VatNumber")
                        .IsUnique();

                    b.ToTable("Organizations", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Expiry")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDemoPlan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxDatabaseSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxStorageSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1);

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("DatabaseProvider")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResourceType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServerAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ServerPort")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServerType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServerUserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Resources", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Expiry")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PlanId");

                    b.ToTable("Subscriptions", (string)null);
                });

            modelBuilder.Entity("MultiTenant.Catalog.Domain.Entities.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("DatabaseProvider")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("TEXT");

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
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("OrganizationId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("State")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .HasColumnType("TEXT");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("OrganizationId");

                            b1.ToTable("Address");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationId");
                        });

                    b.OwnsOne("MultiTenant.Catalog.Domain.ValueObjects.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("OrganizationId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Email")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Phone")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Website")
                                .HasColumnType("TEXT");

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