using System.Net;

namespace MultiTenant.Catalog.Domain.Exceptions.Produce;

public class ErrorModel
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
    public string Message { get; set; }
    public List<ValidationError> Errors { get; set; } = new();

    public string ExceptionType { get; set; }
    public Exception InnerException { get; set; }
    public string StackTrace { get; set; }
}