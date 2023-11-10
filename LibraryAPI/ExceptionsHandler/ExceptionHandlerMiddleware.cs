using System.Net;
using BusinessLogic.Exceptions;
using Newtonsoft.Json;

namespace LibraryAPI.ExceptionsHandler;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ExceptionHandlerMiddleware(RequestDelegate requestDelegate)
        => _requestDelegate = requestDelegate;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _requestDelegate.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
        }
    }
    
    private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)  
    {  
        context.Response.ContentType = "application/json";  
        var statusCode = (int)HttpStatusCode.InternalServerError;  
        var result = JsonConvert.SerializeObject(new  
        {  
            StatusCode = statusCode,  
            ErrorMessage = exception.Message  
        });  
        context.Response.ContentType = "application/json";  
        context.Response.StatusCode = statusCode;  
        return context.Response.WriteAsync(result);   
    } 
}