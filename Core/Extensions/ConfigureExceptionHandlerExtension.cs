using Core.Exceptions;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ConfigureExceptionHandlerExtension
    {
        public static void ConfiguraExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        int statusCode = contextFeature.Error switch
                        {
                            AccessDeniedException => (int)HttpStatusCode.Forbidden,
                            _ => (int)HttpStatusCode.InternalServerError
                        };
                        context.Response.StatusCode = statusCode;
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResult(contextFeature.Error.Message)));
                    }
                });
            });

        }
    }
}
