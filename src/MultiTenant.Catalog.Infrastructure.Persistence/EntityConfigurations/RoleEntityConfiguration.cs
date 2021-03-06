using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Catalog.Domain.Constants;
using MultiTenant.Catalog.Domain.Entities.Users;

namespace MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations;

public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasData(new List<Role>
        {
            //User
            new(Guid.Parse("511074ad-75fd-4e42-9431-f26bf20f5fd4"), RoleNames.User.CanAdd, RoleNames.User.Section),
            new(Guid.Parse("df665298-f652-45d3-9d0b-7cb0a101c0ef"), RoleNames.User.CanUpdate, RoleNames.User.Section),
            new(Guid.Parse("d241b4cc-ac50-4dc5-8da0-499406712c14"), RoleNames.User.CanDelete, RoleNames.User.Section),
            new(Guid.Parse("74b28a56-a909-499f-abe1-e113cce60e0d"), RoleNames.User.CanViewAll, RoleNames.User.Section),
            new(Guid.Parse("bd60be96-847a-4f8a-90e8-1f2a87e37cb5"), RoleNames.User.CanDeactivate,RoleNames.User.Section),
            new(Guid.Parse("3d0826eb-9e93-4656-a2bf-05852f6016ec"), RoleNames.User.CanRevokeOthersAccess,            RoleNames.User.Section),
            new(Guid.Parse("93bfe3e8-0b34-49db-9568-892c21e7238e"), RoleNames.User.CanViewDetails,RoleNames.User.Section),
            //Plan
            new(Guid.Parse("492dbb6f-d131-4bf9-a599-48d942535ade"), RoleNames.Plan.CanAdd, RoleNames.Plan.Section),
            new(Guid.Parse("1c618c85-561a-4341-9091-06c2d13fc9e9"), RoleNames.Plan.CanUpdate, RoleNames.Plan.Section),
            new(Guid.Parse("3bbc70db-658a-4ce8-9c82-6df573baa8a1"), RoleNames.Plan.CanDelete, RoleNames.Plan.Section),
            new(Guid.Parse("5c33c191-11a8-435b-84a1-215a4d0437ee"), RoleNames.Plan.CanViewAll, RoleNames.Plan.Section),
            new(Guid.Parse("ba155014-03fb-458a-80ec-96a8a18ea6f2"), RoleNames.Plan.CanViewOwn, RoleNames.Plan.Section),
            new(Guid.Parse("61ce7b11-0d21-4068-81e1-4a822cb8b041"), RoleNames.Plan.CanViewDetails,RoleNames.Plan.Section),
            //Organization
            new(Guid.Parse("7a6f42c1-f0a2-4772-b336-a48f16decf5a"), RoleNames.Organization.CanAdd,RoleNames.Organization.Section),
            new(Guid.Parse("841608e5-f99f-45c2-8b54-d2f982f55fa7"), RoleNames.Organization.CanUpdate,RoleNames.Organization.Section),
            new(Guid.Parse("bbc949ed-32bc-43b7-ac5b-7d91666ed19d"), RoleNames.Organization.CanDelete,RoleNames.Organization.Section),
            new(Guid.Parse("3a67f77f-41ab-49f0-a4b2-c147dd0d701c"), RoleNames.Organization.CanViewAll,RoleNames.Organization.Section),
            new(Guid.Parse("5df00ce9-8138-41d0-b628-1edfe6b1a91f"), RoleNames.Organization.CanViewOwn,RoleNames.Organization.Section),
            new(Guid.Parse("6b33be72-ceb8-4ea7-a43f-84ec0bc8e180"), RoleNames.Organization.CanViewDetails,RoleNames.Organization.Section),
            //Business
            new(Guid.Parse("76ffcd67-ec05-4b3b-b659-2db86802d0ca"), RoleNames.Business.CanAdd,RoleNames.Business.Section),
            new(Guid.Parse("05bfd857-f681-4803-956b-3629362f3e15"), RoleNames.Business.CanUpdate,RoleNames.Business.Section),
            new(Guid.Parse("90fcb673-06c8-4dec-9c91-2c7fa765dc58"), RoleNames.Business.CanDelete, RoleNames.Business.Section),
            new(Guid.Parse("126dcd1f-3c51-4e77-a12a-41def263dfbf"), RoleNames.Business.CanViewAll,RoleNames.Business.Section),
            new(Guid.Parse("8a769e22-cdd3-46a8-9464-88e8984f3955"), RoleNames.Business.CanViewOwn,RoleNames.Business.Section),
            new(Guid.Parse("d7c9abc2-1f01-4a5b-b8ca-384e7da773b0"), RoleNames.Business.CanViewDetails,RoleNames.Business.Section),
            //Subscription
            new(Guid.Parse("881b4895-175a-43bf-bb23-23dda79a96eb"), RoleNames.Subscription.CanAdd,RoleNames.Subscription.Section),
            new(Guid.Parse("dd050589-ece2-42d9-9eaf-345835022d23"), RoleNames.Subscription.CanUpdate,RoleNames.Subscription.Section),
            new(Guid.Parse("50ae886e-5baf-4ef7-8a8c-ca8954efe88f"), RoleNames.Subscription.CanDelete,RoleNames.Subscription.Section),
            new(Guid.Parse("4d8ad27e-8645-4c88-9c30-1690e6cfb719"), RoleNames.Subscription.CanViewAll,RoleNames.Subscription.Section),
            new(Guid.Parse("d328242e-966d-4552-9eb1-fce1cf18f3f9"), RoleNames.Subscription.CanViewOwn,RoleNames.Subscription.Section),
            new(Guid.Parse("06fbccc0-bbec-45fe-81c9-d5a2950e813b"), RoleNames.Subscription.CanViewDetails,RoleNames.Subscription.Section),
            //Tenant
            new(Guid.Parse("e245925c-f5bb-4048-a7cf-b4720969350a"), RoleNames.Tenant.CanAdd, RoleNames.Tenant.Section),
            new(Guid.Parse("520fdc1b-6284-483a-b649-f745212a1513"), RoleNames.Tenant.CanUpdate,RoleNames.Tenant.Section),
            new(Guid.Parse("4f23197d-e165-4dc9-acac-24cccf29a910"), RoleNames.Tenant.CanDelete,RoleNames.Tenant.Section),
            new(Guid.Parse("6c1ab3ac-c77a-4612-8856-59e434db671c"), RoleNames.Tenant.CanViewAll,RoleNames.Tenant.Section),
            new(Guid.Parse("efc86cbf-d47c-4dbc-907c-05033999d721"), RoleNames.Tenant.CanViewOwn,RoleNames.Tenant.Section),
            new(Guid.Parse("fd4c0abe-7b81-4146-ab0e-df86462e8409"), RoleNames.Tenant.CanViewDetails,RoleNames.Tenant.Section),
            //Resources
            new(Guid.Parse("f0cc39c8-b283-42fe-b70f-5ca3444610df"), RoleNames.Resources.CanAdd,RoleNames.Resources.Section),
            new(Guid.Parse("909d133f-1c7c-4a75-ba91-8f075b8986ab"), RoleNames.Resources.CanUpdate,RoleNames.Resources.Section),
            new(Guid.Parse("fa457656-bbed-4dc3-8b24-21015c29b5af"), RoleNames.Resources.CanDelete,RoleNames.Resources.Section),
            new(Guid.Parse("b2c3c71c-ae60-40c4-beba-b4c0738ef316"), RoleNames.Resources.CanViewAll,RoleNames.Resources.Section),
            new(Guid.Parse("e38c9683-1578-476b-b65c-85c66109fa3c"), RoleNames.Resources.CanViewOwn,RoleNames.Resources.Section),
            new(Guid.Parse("c57149ce-b62d-4aa4-9f44-489889853b89"), RoleNames.Resources.CanViewDetails,RoleNames.Resources.Section)
        });
    }
}