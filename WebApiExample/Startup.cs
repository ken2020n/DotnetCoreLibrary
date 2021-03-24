using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using WebApiBase.JsonConverters;

namespace WebApiExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(e =>
            {
                e.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
            });

            services.AddApiVersioning();
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var options = new HealthCheckOptions
            {
                ResponseWriter = async (httpContext, healthReport) =>
                {
                    httpContext.Response.ContentType = "application/json";

                    var result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(new
                    {
                        status = healthReport.Status.ToString(),
                        errors = healthReport.Entries.Select(e => new {key = e.Key, value = e.Value.Status.ToString()})
                    }));

                    await httpContext.Response.WriteAsync(result);
                }
            };
            app.UseHealthChecks("/Health", options);

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                                   ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}