using App.Configuration;
using App.Deposits.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using App.Deposits.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Deposits.Filters
{
    public class DepositsExceptionFilter : IAsyncExceptionFilter
    {
        private readonly string context;
        private readonly ILogger<DepositsExceptionFilter> logger;
        private readonly ILocalizationManager localizationManager;

        public DepositsExceptionFilter(ILocalizationManager localizationManager,ILogger<DepositsExceptionFilter> logger, string context)
        {
            this.context = context;
            this.logger = logger;
            this.localizationManager = localizationManager;

        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {context}");

            switch (context.Exception)
            {
                case InvalidDataException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                        var errorMessage = localizationManager.GetResource("InvalidDataDTO");

                        logger.LogWarning($"{e.Message}. Method: {e.TargetSite}.");

                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case EntityNotFoundException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                        var errorMessage = localizationManager.GetResource("EntityNotExist");

                        logger.LogWarning($"Type : {e.EntityType.AssemblyQualifiedName},EntityId {e.EntityId}. Method: {e.TargetSite}.");

                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessage = localizationManager.GetResource("UnhandledException");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
            }

            context.ExceptionHandled = true;
        }
    }
}
