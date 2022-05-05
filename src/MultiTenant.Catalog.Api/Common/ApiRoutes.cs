namespace MultiTenant.Catalog.Api.Common;

public static class ApiRoutes
{
    private const string BaseUrl = "api/";

    public static class Foobar
    {
        private const string FoobarBaseUrl = BaseUrl + "foobar";
        public const string Princess = FoobarBaseUrl + "/princess";
    }
}