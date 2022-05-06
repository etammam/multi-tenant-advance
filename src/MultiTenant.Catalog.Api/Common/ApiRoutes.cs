namespace MultiTenant.Catalog.Api.Common;

public static class ApiRoutes
{
    private const string BaseUrl = "api/";

    public static class Foobar
    {
        private const string FoobarBaseUrl = BaseUrl + "foobar";
        public const string Princess = FoobarBaseUrl + "/princess";
    }

    public static class Business
    {
        private const string BusinessBaseUrl = BaseUrl + "business";
        public const string GetList = BusinessBaseUrl;
        public const string Get = BusinessBaseUrl + "/{{id}}";
        public const string Post = BusinessBaseUrl;
        public const string Put = BusinessBaseUrl + "/{{id}}";
        public const string Delete = BusinessBaseUrl + "/{{id}}";
    }
}