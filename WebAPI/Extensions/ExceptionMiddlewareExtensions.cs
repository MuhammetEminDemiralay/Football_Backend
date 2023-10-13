using Core.CrossCuttingConcerns.Logging;
using Entities.ErrorModel;
using Entities.Exceptions.Abstract;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "Application/json";
                    var features = context.Features.Get<IExceptionHandlerFeature>();
                    if (features != null)
                    {
                        context.Response.StatusCode = features.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong :{features.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = features.Error.Message

                        }.ToString());
                    }
                });
            });
        }
    }
}
