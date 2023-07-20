using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Text.Json;

namespace SharedLibrary.Extensions
{
    public static class CustomExceptionHandler
    {

        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(configure =>
            {
                // use ile kullanılan akışa devam eder,
                //Run lar ise sonlandırıcı
                configure.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;
                        ErrorDto errorDto = null;
                        if (ex is CustomException) // kullanıcı kaynaklı oluşan bir hata ise hatayı göster
                            errorDto = new ErrorDto(ex.Message, true);
                        else // uygulama içerisinde olunan bir hata  ise hata mesajı gösterme
                            errorDto = new ErrorDto(ex.Message, false);

                        var response = Response<NoDataDto>.Fail(errorDto, 500);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }

                });

              
            });
        }

    }
}
