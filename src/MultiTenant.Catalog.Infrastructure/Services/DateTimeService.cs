using MultiTenant.Catalog.Core.Common;

namespace MultiTenant.Catalog.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now()
    {
        return DateTime.UtcNow;
    }

    public DateTime Today()
    {
        return DateTime.Today;
    }
}