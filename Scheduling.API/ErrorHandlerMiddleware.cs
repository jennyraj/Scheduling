﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Scheduling.API
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int) HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int) HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new {message = error?.Message});
                await response.WriteAsync(result);
            }
        }
    }

    // custom exception class for throwing application specific exceptions (e.g. for validation) 
    // that can be caught and handled within the application
    public class AppException : Exception
    {
        public AppException() : base()
        {
        }

        public AppException(string message) : base(message)
        {
        }

        public AppException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}