﻿using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Middleware
{
    internal sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var exception = GetExceptionDetails(ex);
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Status = exception.Status,
                    Type = exception.Type,
                    Title = exception.Title,
                    Detail = exception.Detail
                };

                if(exception.errors is not null)
                {
                    problemDetails.Extensions["Errors"] = exception.errors;
                }

                context.Response.StatusCode = exception.Status;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

        private ExceptionDetails GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                ValidationException validationException => new ExceptionDetails(

                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                "Validation error",
                "One or more validation errors has occurred",
                validationException.Errors
                ),
                _ => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "ServerError",
                "Server error",
                "An unexpected error has occurred",
                null)
            };
        }

        private sealed record ExceptionDetails(
            int Status,
            string Type,
            string Title,
            string Detail,
            IEnumerable<object>? errors
            );
    }
}
