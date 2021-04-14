using BLTS.WebApi.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;

namespace BLTS.WebApi.Web
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "DefaultCorsPolicy";
        private const string _apiVersion = "v1";
        public IConfiguration Configuration { get; }


        public Startup(IWebHostEnvironment env)
        {
            Configuration = env.GetAppConfiguration();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adds Microsoft Identity platform (AAD v2.0) support to protect this Api
            services.AddMicrosoftIdentityWebApiAuthentication(Configuration);

            services.AddControllers();
            services.AddControllersWithViews(options =>
            {
                //AuthorizationPolicy policy = new AuthorizationPolicyBuilder()
                //                                .RequireAuthenticatedUser()
                //                                .Build();
                //options.Filters.Add(new AuthorizeFilter(policy));
            }).AddMicrosoftIdentityUI();

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
                    // uncomment if needed
                    //TermsOfService = new Uri("https://example.com/terms"),
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

                //string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlFile = $"BLTS.WebApi.Application.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.DocInclusionPredicate((docName, description) => true);

                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.OpenIdConnect,
                        Scheme = "openIdConnect"
                    });
            });

            Core.Startup applicationServicesStartup = new Core.Startup(services, Configuration);
            applicationServicesStartup.Initialize();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(_defaultCorsPolicyName); // Enable CORS!
            app.UseDefaultFiles();
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
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
                //options.RoutePrefix = string.Empty;
                options.EnableFilter();
                //options.DefaultModelsExpandDepth(-1); // Hide models in Swagger UI

                options.OAuthClientId(Configuration["AzureAd:ClientId"]);
                options.OAuthScopeSeparator(" ");
                options.OAuthAppName("API for BLTS Services");

            });
        }
    }
}
