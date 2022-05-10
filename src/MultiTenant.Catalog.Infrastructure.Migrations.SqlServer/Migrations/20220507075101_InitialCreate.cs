using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiTenant.Catalog.Infrastructure.Migrations.SqlServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxUserCount = table.Column<int>(type: "int", nullable: false),
                    MaxDatabaseSize = table.Column<int>(type: "int", nullable: false),
                    MaxStorageSize = table.Column<int>(type: "int", nullable: false),
                    IsDemoPlan = table.Column<bool>(type: "bit", nullable: false),
                    Expiry = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerPort = table.Column<int>(type: "int", nullable: false),
                    ServerUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatabaseProvider = table.Column<int>(type: "int", nullable: false),
                    ResourceType = table.Column<int>(type: "int", nullable: false),
                    ServerType = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizations_Business_BusinessId1",
                        column: x => x.BusinessId1,
                        principalTable: "Business",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiry = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConnectionString = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatabaseProvider = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Organizations_Id",
                        column: x => x.Id,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tenants_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "Section" },
                values: new object[,]
                {
                    { new Guid("05bfd857-f681-4803-956b-3629362f3e15"), "8a511392-4371-4300-b408-37630811fa64", "Business-CanUpdate", "BUSINESS-CANUPDATE", "Business" },
                    { new Guid("06fbccc0-bbec-45fe-81c9-d5a2950e813b"), "ffd246c3-b206-43ee-a800-0106a04aaa83", "Subscription-CanViewDetails", "SUBSCRIPTION-CANVIEWDETAILS", "Subscription" },
                    { new Guid("126dcd1f-3c51-4e77-a12a-41def263dfbf"), "7ba721cc-5e63-4f42-bf98-e08036f72020", "Business-CanViewAll", "BUSINESS-CANVIEWALL", "Business" },
                    { new Guid("1c618c85-561a-4341-9091-06c2d13fc9e9"), "996acdfb-62ed-45fa-b768-f703e269f268", "Plan-CanUpdate", "PLAN-CANUPDATE", "Plan" },
                    { new Guid("3a67f77f-41ab-49f0-a4b2-c147dd0d701c"), "56cb22e3-281c-463d-8f95-96180b4d3461", "Organization-CanViewAll", "ORGANIZATION-CANVIEWALL", "Organization" },
                    { new Guid("3bbc70db-658a-4ce8-9c82-6df573baa8a1"), "b1c6b6e5-ec5a-41b6-8263-85b8f6e82575", "Plan-CanDelete", "PLAN-CANDELETE", "Plan" },
                    { new Guid("3d0826eb-9e93-4656-a2bf-05852f6016ec"), "d552f13d-37c3-41cc-af0e-15ea9d788e62", "User-CanRevokeOthersAccess", "USER-CANREVOKEOTHERSACCESS", "User" },
                    { new Guid("492dbb6f-d131-4bf9-a599-48d942535ade"), "20804c7c-60c7-4d25-840e-d65da84d3762", "Plan-CanAdd", "PLAN-CANADD", "Plan" },
                    { new Guid("4d8ad27e-8645-4c88-9c30-1690e6cfb719"), "535b49ab-45fe-4382-8b24-9c2238974166", "Subscription-CanViewAll", "SUBSCRIPTION-CANVIEWALL", "Subscription" },
                    { new Guid("4f23197d-e165-4dc9-acac-24cccf29a910"), "4e7bfed8-b651-4341-b31c-4ea8ebed5ab3", "Tenant-CanDelete", "TENANT-CANDELETE", "Tenant" },
                    { new Guid("50ae886e-5baf-4ef7-8a8c-ca8954efe88f"), "e0656185-dc8d-4e78-8c78-3e62bb461042", "Subscription-CanDelete", "SUBSCRIPTION-CANDELETE", "Subscription" },
                    { new Guid("511074ad-75fd-4e42-9431-f26bf20f5fd4"), "a9d91894-ace1-4ec8-920b-56be9b3e54c1", "User-CanAdd", "USER-CANADD", "User" },
                    { new Guid("520fdc1b-6284-483a-b649-f745212a1513"), "b1537d4b-1d9f-459f-9822-2f89de73ae19", "Tenant-CanUpdate", "TENANT-CANUPDATE", "Tenant" },
                    { new Guid("5c33c191-11a8-435b-84a1-215a4d0437ee"), "2ab92e19-9d1f-476f-a956-0648597b1ced", "Plan-CanViewAll", "PLAN-CANVIEWALL", "Plan" },
                    { new Guid("5df00ce9-8138-41d0-b628-1edfe6b1a91f"), "7e374f96-33b2-411d-b453-e5a2699cd2dc", "Organization-CanViewOwn", "ORGANIZATION-CANVIEWOWN", "Organization" },
                    { new Guid("61ce7b11-0d21-4068-81e1-4a822cb8b041"), "5a53062c-8129-4db1-b91b-e78536cf2f15", "Plan-CanViewDetails", "PLAN-CANVIEWDETAILS", "Plan" },
                    { new Guid("6b33be72-ceb8-4ea7-a43f-84ec0bc8e180"), "a254175b-c36f-4201-a43f-169184c642e6", "Organization-CanViewDetails", "ORGANIZATION-CANVIEWDETAILS", "Organization" },
                    { new Guid("6c1ab3ac-c77a-4612-8856-59e434db671c"), "25f1b317-0d72-497b-8043-a62f1e553325", "Tenant-CanViewAll", "TENANT-CANVIEWALL", "Tenant" },
                    { new Guid("74b28a56-a909-499f-abe1-e113cce60e0d"), "c034ae04-8b30-4e1e-b7b0-e78eab9baffd", "User-CanViewAll", "USER-CANVIEWALL", "User" },
                    { new Guid("76ffcd67-ec05-4b3b-b659-2db86802d0ca"), "5c16ac3e-35be-48b2-bda2-df953ac5cfcf", "Business-CanAdd", "BUSINESS-CANADD", "Business" },
                    { new Guid("7a6f42c1-f0a2-4772-b336-a48f16decf5a"), "0f310a04-7eea-4015-bdbe-d7e1bafb4f41", "Organization-CanAdd", "ORGANIZATION-CANADD", "Organization" },
                    { new Guid("841608e5-f99f-45c2-8b54-d2f982f55fa7"), "abee3e61-4181-4426-81c2-dd4a3d4daefa", "Organization-CanUpdate", "ORGANIZATION-CANUPDATE", "Organization" },
                    { new Guid("881b4895-175a-43bf-bb23-23dda79a96eb"), "3321b77d-a9f0-4a95-a7b9-8597d4ccbe6d", "Subscription-CanAdd", "SUBSCRIPTION-CANADD", "Subscription" },
                    { new Guid("8a769e22-cdd3-46a8-9464-88e8984f3955"), "9edf1f04-4b9e-4c22-96f3-a5b01647ef49", "Business-CanViewOwn", "BUSINESS-CANVIEWOWN", "Business" },
                    { new Guid("909d133f-1c7c-4a75-ba91-8f075b8986ab"), "d01e9c4c-f71d-4c3f-ae29-0a91057b194a", "Resources-CanUpdate", "RESOURCES-CANUPDATE", "Resources" },
                    { new Guid("90fcb673-06c8-4dec-9c91-2c7fa765dc58"), "2b2f7a5d-0500-4ddd-821b-46c356867e72", "Business-CanDelete", "BUSINESS-CANDELETE", "Business" },
                    { new Guid("93bfe3e8-0b34-49db-9568-892c21e7238e"), "04eb664c-7f19-4cb1-8ac3-d7be13646dbb", "User-CanViewDetails", "USER-CANVIEWDETAILS", "User" },
                    { new Guid("b2c3c71c-ae60-40c4-beba-b4c0738ef316"), "a28b2114-329d-4e33-b480-d0a35ba93bbb", "Resources-CanViewAll", "RESOURCES-CANVIEWALL", "Resources" },
                    { new Guid("ba155014-03fb-458a-80ec-96a8a18ea6f2"), "0ed5ac50-79be-4207-993d-27722144c666", "Plan-CanViewOwn", "PLAN-CANVIEWOWN", "Plan" },
                    { new Guid("bbc949ed-32bc-43b7-ac5b-7d91666ed19d"), "8aced989-119b-4839-9329-e1fd3fca246f", "Organization-CanDelete", "ORGANIZATION-CANDELETE", "Organization" },
                    { new Guid("bd60be96-847a-4f8a-90e8-1f2a87e37cb5"), "eaf14ac7-36c8-4ca3-99b5-b40a3e896e5c", "User-CanDeactivate", "USER-CANDEACTIVATE", "User" },
                    { new Guid("c57149ce-b62d-4aa4-9f44-489889853b89"), "536f43be-5957-4f6e-bf01-1da98b0b55cf", "Resources-CanViewDetails", "RESOURCES-CANVIEWDETAILS", "Resources" },
                    { new Guid("d241b4cc-ac50-4dc5-8da0-499406712c14"), "30ae639c-57fa-4033-93e1-b0aee5f991fe", "User-CanDelete", "USER-CANDELETE", "User" },
                    { new Guid("d328242e-966d-4552-9eb1-fce1cf18f3f9"), "937346b5-a570-4c6b-a1aa-5e52211f9923", "Subscription-CanViewOwn", "SUBSCRIPTION-CANVIEWOWN", "Subscription" },
                    { new Guid("d7c9abc2-1f01-4a5b-b8ca-384e7da773b0"), "e92e3919-9bad-49ba-a04f-ea64475514f9", "Business-CanViewDetails", "BUSINESS-CANVIEWDETAILS", "Business" },
                    { new Guid("dd050589-ece2-42d9-9eaf-345835022d23"), "c3a9dcc7-395a-452c-8dbd-056a1fb5b544", "Subscription-CanUpdate", "SUBSCRIPTION-CANUPDATE", "Subscription" },
                    { new Guid("df665298-f652-45d3-9d0b-7cb0a101c0ef"), "6f68388b-f91d-4f3a-ae38-e6ad2032d481", "User-CanUpdate", "USER-CANUPDATE", "User" },
                    { new Guid("e245925c-f5bb-4048-a7cf-b4720969350a"), "26deeffd-3912-44c9-a119-d2888563af7a", "Tenant-CanAdd", "TENANT-CANADD", "Tenant" },
                    { new Guid("e38c9683-1578-476b-b65c-85c66109fa3c"), "cd0c3075-ba80-4987-85a6-64b8f6c51322", "Resources-CanViewOwn", "RESOURCES-CANVIEWOWN", "Resources" },
                    { new Guid("efc86cbf-d47c-4dbc-907c-05033999d721"), "ed62b53c-41e9-4394-bff6-1ec5534825be", "Tenant-CanViewOwn", "TENANT-CANVIEWOWN", "Tenant" },
                    { new Guid("f0cc39c8-b283-42fe-b70f-5ca3444610df"), "b40daba3-23f9-40ac-91c7-8cc67db1a242", "Resources-CanAdd", "RESOURCES-CANADD", "Resources" },
                    { new Guid("fa457656-bbed-4dc3-8b24-21015c29b5af"), "11fb7e16-9ae6-41dd-94cc-cd92f1e91982", "Resources-CanDelete", "RESOURCES-CANDELETE", "Resources" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "Section" },
                values: new object[] { new Guid("fd4c0abe-7b81-4146-ab0e-df86462e8409"), "244bcfe0-547d-477d-9c6e-ac70c7e658b0", "Tenant-CanViewDetails", "TENANT-CANVIEWDETAILS", "Tenant" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "LastLogin", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753"), 0, null, "a6b3dd98-7eea-44db-b5e6-41ba17632904", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@tenant-catalog.com", true, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Administrator", "ADMIN@TENANT-CATALOG.COM", "ADMIN", "AQAAAAEAACcQAAAAEGLKdzP+T8hcRVRYWUx4X2Fd75P/a34kaqGsIHwICV7oDwyx9uylxn3A2brG9NEA7A==", "+2 01100072682", false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("05bfd857-f681-4803-956b-3629362f3e15"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("06fbccc0-bbec-45fe-81c9-d5a2950e813b"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("126dcd1f-3c51-4e77-a12a-41def263dfbf"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("1c618c85-561a-4341-9091-06c2d13fc9e9"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("3a67f77f-41ab-49f0-a4b2-c147dd0d701c"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("3bbc70db-658a-4ce8-9c82-6df573baa8a1"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("3d0826eb-9e93-4656-a2bf-05852f6016ec"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("492dbb6f-d131-4bf9-a599-48d942535ade"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("4d8ad27e-8645-4c88-9c30-1690e6cfb719"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("4f23197d-e165-4dc9-acac-24cccf29a910"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("50ae886e-5baf-4ef7-8a8c-ca8954efe88f"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("511074ad-75fd-4e42-9431-f26bf20f5fd4"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("520fdc1b-6284-483a-b649-f745212a1513"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("5c33c191-11a8-435b-84a1-215a4d0437ee"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("5df00ce9-8138-41d0-b628-1edfe6b1a91f"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("61ce7b11-0d21-4068-81e1-4a822cb8b041"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("6b33be72-ceb8-4ea7-a43f-84ec0bc8e180"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("6c1ab3ac-c77a-4612-8856-59e434db671c"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("74b28a56-a909-499f-abe1-e113cce60e0d"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("76ffcd67-ec05-4b3b-b659-2db86802d0ca"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("7a6f42c1-f0a2-4772-b336-a48f16decf5a"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("841608e5-f99f-45c2-8b54-d2f982f55fa7"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("881b4895-175a-43bf-bb23-23dda79a96eb"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("8a769e22-cdd3-46a8-9464-88e8984f3955"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("909d133f-1c7c-4a75-ba91-8f075b8986ab"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("90fcb673-06c8-4dec-9c91-2c7fa765dc58"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("93bfe3e8-0b34-49db-9568-892c21e7238e"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("b2c3c71c-ae60-40c4-beba-b4c0738ef316"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("ba155014-03fb-458a-80ec-96a8a18ea6f2"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("bbc949ed-32bc-43b7-ac5b-7d91666ed19d"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("bd60be96-847a-4f8a-90e8-1f2a87e37cb5"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("c57149ce-b62d-4aa4-9f44-489889853b89"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("d241b4cc-ac50-4dc5-8da0-499406712c14"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("d328242e-966d-4552-9eb1-fce1cf18f3f9"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("d7c9abc2-1f01-4a5b-b8ca-384e7da773b0"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("dd050589-ece2-42d9-9eaf-345835022d23"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("df665298-f652-45d3-9d0b-7cb0a101c0ef"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("e245925c-f5bb-4048-a7cf-b4720969350a"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("e38c9683-1578-476b-b65c-85c66109fa3c"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("efc86cbf-d47c-4dbc-907c-05033999d721"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("f0cc39c8-b283-42fe-b70f-5ca3444610df"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") },
                    { new Guid("fa457656-bbed-4dc3-8b24-21015c29b5af"), new Guid("79349908-ee08-4b2f-b1dd-f8bd35b92753") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_OrganizationId",
                table: "Address",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Business_Name",
                table: "Business",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_BusinessId",
                table: "Organizations",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_BusinessId1",
                table: "Organizations",
                column: "BusinessId1");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Name",
                table: "Organizations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_VatNumber",
                table: "Organizations",
                column: "VatNumber",
                unique: true,
                filter: "[VatNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_Name",
                table: "Plans",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_OrganizationId",
                table: "Subscriptions",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PlanId",
                table: "Subscriptions",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ConnectionString",
                table: "Tenants",
                column: "ConnectionString",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Identifier",
                table: "Tenants",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Name",
                table: "Tenants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ResourceId",
                table: "Tenants",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Business");
        }
    }
}
