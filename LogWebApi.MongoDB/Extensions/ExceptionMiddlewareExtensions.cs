using LogWebApi.MongoDB.Model;
using LogWebApi.MongoDB.Model.Settings;
using LogWebApi.MongoDB.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LogWebApi.MongoDB.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IOptions<DBSettings> settings)
        {
            LogRepository _repository = new LogRepository(settings);
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await _repository.Add(new LogData
                        {
                            Message = contextFeature.Error.ToString(),
                            Date = DateTime.Now,
                            Level = "Fatal",
                            LogSource = "LogWebApi"
                        });
                        await context.Response.WriteAsync(context.Response.StatusCode + "-Internal Server Error.");
                    }
                });
            });
        }
    }
}
