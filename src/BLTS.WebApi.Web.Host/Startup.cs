using BLTS.WebApi.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;


namespace BLTS.WebApi.Web
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";
        private const string _apiVersion = "v1";
        public IConfiguration Configuration { get; }


        public Startup(IWebHostEnvironment env)
        {
            Configuration = env.GetAppConfiguration();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Core.Startup applicationServicesStartup = new Core.Startup(services, Configuration);
            applicationServicesStartup.Initialize();

            services.AddMicrosoftIdentityWebApiAuthentication(Configuration, "AzureAd");

            services.AddControllers();
            services.AddControllersWithViews();

            services.AddCors(
              options => options.AddPolicy(
              _defaultCorsPolicyName,
              builder => builder
                  .WithOrigins(
                      // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                      Configuration["App:CorsOrigins"]
                          .Split(",", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray()
                  )
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials()
            )
            );

            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(_apiVersion, new OpenApiInfo
                {
                    Version = _apiVersion,
                    Title = $"BLTS API {_apiVersion}",
                    Description = "API for BLTS Services",
                    // uncomment if needed TermsOfService = new Uri("https://example.com/terms"),
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "WebApi",
                    //    Email = string.Empty,
                    //    Url = new Uri("https://twitter.com/aspboilerplate"),
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = "MIT License",
                    //    Url = new Uri("https://github.com/aspnetboilerplate/aspnetboilerplate/blob/dev/LICENSE"),
                    //}
                });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.IncludeXmlComments(xmlPath);


                options.DocInclusionPredicate((docName, description) => true);

            });


        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseCors(_defaultCorsPolicyName); // Enable CORS!
            app.Use(async (context, next) => { await next(); if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api/services", StringComparison.InvariantCultureIgnoreCase)) { context.Request.Path = "/swagger"; await next(); } });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(options => { options.RouteTemplate = "swagger/{documentName}/swagger.json"; });

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                // specifying the Swagger JSON endpoint.
                options.SwaggerEndpoint($"/swagger/{_apiVersion}/swagger.json", $"BLTS API {_apiVersion}");
                options.DisplayRequestDuration(); // Controls the display of the request duration (in milliseconds) for "Try it out" requests.  
                options.DocumentTitle = "BLTS Web API";
            }); // URL: /swagger
        }
    }
}
