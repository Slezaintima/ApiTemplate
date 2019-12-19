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
        readonly ILocalizationManager localizationManager;

        public CurrencyExceptionFilter(ILogger<CurrencyExceptionFilter> logger, string context, ILocalizationManager manager)
        {
            _logger = logger;
            _context = context;
            this.localizationManager = manager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception, $"Error occured in context of {_context}");
            switch (context.Exception)
            {
                case ForbiddenException forbiden:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        var errorMessage = localizationManager.GetResource("Forbidden Exception");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case NotFoundException alreadyExist:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var errorMessage = localizationManager.GetResource("Not Found Exception");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessage = localizationManager.GetResource("UnhandeledException");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    };

            }
            context.ExceptionHandled = true;
        }
    }
}

