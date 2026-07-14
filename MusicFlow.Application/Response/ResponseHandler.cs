using System;
using System.Net;

public class ResponseHandler
{
    public ResponseHandler()
    {
        
    }

    public Response<T> Deleted<T>()
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = "Success"
        };
    }
    public Response<T> Success<T>(T entity, object? Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = "Success",
            Meta = Meta
        };
    }

    public Response<T> Unauthorized<T>(string message)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = "UnAuthorized"
        };
    }
    public Response<T> BadRequest<T>(string? Message = null)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = Message == null ? "NotExists" : Message
        };
    }

    public Response<T> NotFound<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message == null ? "NotFound" : message
        };
    }

    public Response<T> Created<T>(T entity, object? Meta = null )
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
            Message =  "created",
            Meta = null
        };
    }
}
