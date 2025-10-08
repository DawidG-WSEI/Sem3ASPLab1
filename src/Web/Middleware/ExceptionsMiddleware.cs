using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Exceptions.ArtistExceptions;
using CleanArchitecture.Domain.Exceptions.ListenerExceptions;
using CleanArchitecture.Domain.Exceptions.SongExceptions;
using CleanArchitecture.Domain.Exceptions.Common;

namespace CleanArchitecture.WebAPI.Middleware;

public class ExceptionsMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                ArtistNotFoundException => (int)HttpStatusCode.NotFound,
                ListenerNotFoundException => (int)HttpStatusCode.NotFound,
                SongNotFoundException => (int)HttpStatusCode.NotFound,
                InvalidUsernameException => (int)HttpStatusCode.BadRequest,
                InvalidEmailException => (int)HttpStatusCode.BadRequest,
                InvalidPayoutTierException => (int)HttpStatusCode.BadRequest,
                SongAlreadyExistsException => (int)HttpStatusCode.Conflict,
                UserAlreadyExistsException => (int)HttpStatusCode.Conflict,
                InsufficientPermissionsException => (int)HttpStatusCode.Forbidden,
                _ => (int)HttpStatusCode.InternalServerError
            };

            context.Response.Headers["X-Error-Type"] = ex.GetType().Name;
            context.Response.Headers["X-Error-Message"] = ex.Message;

            var result = JsonSerializer.Serialize(new
            {
                error = ex.Message,
                type = ex.GetType().Name
            });

            await context.Response.WriteAsync(result);
        }
    }
}