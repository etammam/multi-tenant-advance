using System.Net;
using System.Net.Mime;
using System.Text;
using FluentValidation;
using MultiTenant.Catalog.Core.Common;
using MultiTenant.Catalog.Domain.Exceptions;
using MultiTenant.Catalog.Domain.Exceptions.Produce;

namespace MultiTenant.Catalog.Api.Common.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    private readonly ISerializerService _serializationService;

    public ExceptionMiddleware(ISerializerService serializationService)
    {
        _serializationService = serializationService;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            if (e.GetBaseException() is DomainException)
            {
                var error = new ErrorModel();
                var exception = (DomainException)e;
                error.Message = exception.Message;
                error.StackTrace = exception.StackTrace;
                error.InnerException = exception.InnerException;
                error.StatusCode = exception.Error.StatusCode;
                error.ExceptionType = exception.ExceptionType;
                context.Response.StatusCode = exception.Error.StatusCode;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                await context.Response.WriteAsync(_serializationService.Serialize(error), Encoding.UTF8);
            }
            else if (e.GetBaseException() is ValidationException || e is ValidationException)
            {
                var error = new ErrorModel();
                var exception = (ValidationException)e;
                error.Message = exception.Message;
                error.StackTrace = exception.StackTrace;
                error.ExceptionType = nameof(ValidationException);
                error.InnerException = exception.InnerException;
                error.StatusCode = (int)HttpStatusCode.BadRequest;

                var errorProperties = exception.Errors.GroupBy(c => c.PropertyName);
                foreach (var errorProperty in errorProperties)
                {
                    var validationError = new ValidationError
                    {
                        PropertyName = errorProperty.Key
                    };
                    foreach (var validationFailure in errorProperty)
                        validationError.Validations.Add(new ErrorProperty(validationFailure.AttemptedValue,
                            validationFailure.ErrorCode, validationFailure.ErrorMessage,
                            validationFailure.Severity.ToString()));
                    error.Errors.Add(validationError);
                }

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                await context.Response.WriteAsync(_serializationService.Serialize(error), Encoding.UTF8);
            }
            else
            {
                var error = new ErrorModel
                {
                    StackTrace = e.StackTrace,
                    Message = e.Message,
                    InnerException = e.InnerException,
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                await context.Response.WriteAsync(_serializationService.Serialize(error), Encoding.UTF8);
            }
        }
    }
}