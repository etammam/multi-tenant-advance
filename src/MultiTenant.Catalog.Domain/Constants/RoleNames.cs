namespace MultiTenant.Catalog.Domain.Constants;

public static class RoleNames
{
    public class Business
    {
        public const string Section = nameof(Business);
        public const string CanViewOwn = $"{Section}-{nameof(CanViewOwn)}";
        public const string CanViewAll = $"{Section}-{nameof(CanViewAll)}";
        public const string CanViewDetails = $"{Section}-{nameof(CanViewDetails)}";
        public const string CanAdd = $"{Section}-{nameof(CanAdd)}";
        public const string CanUpdate = $"{Section}-{nameof(CanUpdate)}";
        public const string CanDelete = $"{Section}-{nameof(CanDelete)}";
    }

    public static class Plan
    {
        public const string Section = nameof(Plan);
        public const string CanViewOwn = $"{Section}-{nameof(CanViewOwn)}";
        public const string CanViewAll = $"{Section}-{nameof(CanViewAll)}";
        public const string CanViewDetails = $"{Section}-{nameof(CanViewDetails)}";
        public const string CanAdd = $"{Section}-{nameof(CanAdd)}";
        public const string CanUpdate = $"{Section}-{nameof(CanUpdate)}";
        public const string CanDelete = $"{Section}-{nameof(CanDelete)}";
    }

    public static class Organization
    {
        public const string Section = nameof(Organization);
        public const string CanViewOwn = $"{Section}-{nameof(CanViewOwn)}";
        public const string CanViewAll = $"{Section}-{nameof(CanViewAll)}";
        public const string CanViewDetails = $"{Section}-{nameof(CanViewDetails)}";
        public const string CanAdd = $"{Section}-{nameof(CanAdd)}";
        public const string CanUpdate = $"{Section}-{nameof(CanUpdate)}";
        public const string CanDelete = $"{Section}-{nameof(CanDelete)}";
    }

    public static class Resources
    {
        public const string Section = nameof(Resources);
        public const string CanViewOwn = $"{Section}-{nameof(CanViewOwn)}";
        public const string CanViewAll = $"{Section}-{nameof(CanViewAll)}";
        public const string CanViewDetails = $"{Section}-{nameof(CanViewDetails)}";
        public const string CanAdd = $"{Section}-{nameof(CanAdd)}";
        public const string CanUpdate = $"{Section}-{nameof(CanUpdate)}";
        public const string CanDelete = $"{Section}-{nameof(CanDelete)}";
    }

    public static class Subscription
    {
        public const string Section = nameof(Subscription);
        public const string CanViewOwn = $"{Section}-{nameof(CanViewOwn)}";
        public const string CanViewAll = $"{Section}-{nameof(CanViewAll)}";
        public const string CanViewDetails = $"{Section}-{nameof(CanViewDetails)}";
        public const string CanAdd = $"{Section}-{nameof(CanAdd)}";
        public const string CanUpdate = $"{Section}-{nameof(CanUpdate)}";
        public const string CanDelete = $"{Section}-{nameof(CanDelete)}";
    }

    public static class Tenant
    {
        public const string Section = nameof(Tenant);
        public const string CanViewOwn = $"{Section}-{nameof(CanViewOwn)}";
        public const string CanViewAll = $"{Section}-{nameof(CanViewAll)}";
        public const string CanViewDetails = $"{Section}-{nameof(CanViewDetails)}";
        public const string CanAdd = $"{Section}-{nameof(CanAdd)}";
        public const string CanUpdate = $"{Section}-{nameof(CanUpdate)}";
        public const string CanDelete = $"{Section}-{nameof(CanDelete)}";
    }

    public static class User
    {
        public const string Section = nameof(User);
        public const string CanViewAll = $"{Section}-{nameof(CanViewAll)}";
        public const string CanViewDetails = $"{Section}-{nameof(CanViewDetails)}";
        public const string CanAdd = $"{Section}-{nameof(CanAdd)}";
        public const string CanUpdate = $"{Section}-{nameof(CanUpdate)}";
        public const string CanDelete = $"{Section}-{nameof(CanDelete)}";
        public const string CanDeactivate = $"{Section}-{nameof(CanDeactivate)}";
        public const string CanRevokeOthersAccess = $"{Section}-{nameof(CanRevokeOthersAccess)}";
    }
}