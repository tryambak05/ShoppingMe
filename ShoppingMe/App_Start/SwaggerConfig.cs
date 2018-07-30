using System.Web.Http;
using WebActivatorEx;
using ShoppingMe;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ShoppingMe
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "ShoppingMe");
                })
                .EnableSwaggerUi(c =>
                {
                });
        }
    }
}