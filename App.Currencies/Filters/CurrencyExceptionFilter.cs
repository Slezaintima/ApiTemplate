using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using App.Currencies.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace App.Currencies.Filters
{
    class CurrencyExceptionFilter : IAsyncExceptionFilter
    {
        readonly string _context;
        readonly ILogger<CurrencyExceptionFilter> _logger;

        public CurrencyExceptionFilter(ILogger<CurrencyExceptionFilter> logger, string context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception, $"Error occured in context of {_context}");
            switch (context.Exception)
            {
                case ForbiddenException forbiden:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        await context.HttpContext.Response.WriteAsync($"Access to resource {context.HttpContext.Request.Path} forbidden");
                        break;
                    }
                case NotFoundException alreadyExist:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await context.HttpContext.Response.WriteAsync($"Specified resource {context.HttpContext.Request.Query} not found");
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.HttpContext.Response.WriteAsync("Unhandled exception ! Please, contact support for resolve");
                        break;
                    };

            }
            context.ExceptionHandled = true;
        }
    }
}

