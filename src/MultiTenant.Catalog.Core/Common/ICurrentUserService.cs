namespace MultiTenant.Catalog.Core.Common;

public interface ICurrentUserService
{
    Guid UserId();
    string UserName();
}