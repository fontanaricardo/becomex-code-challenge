using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NJsonSchema;
using NSwag.AspNetCore;
using RoboCore.Business;
using RoboCore.Business.ElbowBusiness;
using RoboCore.Business.HeadBusiness;
using RoboCore.Business.WristBusiness;
using RoboCore.Models;

namespace RoboApi
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddSingleton (new Robot ());

            services.AddTransient<IRequestHandler<HeadInclinationDownRequest, HeadInclinationDownResponse>, HeadInclinationDownInteractor> ();
            services.AddTransient<IRequestHandler<HeadInclinationUpRequest, HeadInclinationUpResponse>, HeadInclinationUpInteractor> ();
            services.AddTransient<IRequestHandler<HeadRotatePlusRequest, HeadRotatePlusResponse>, HeadRotatePlusInteractor> ();
            services.AddTransient<IRequestHandler<HeadRotateMinusRequest, HeadRotateMinusResponse>, HeadRotateMinusInteractor> ();

            services.AddTransient<IRequestHandler<ElbowContractRequest, ElbowContractResponse>, ElbowContractInteractor> ();
            services.AddTransient<IRequestHandler<ElbowRelaxRequest, ElbowRelaxResponse>, ElbowRelaxInteractor> ();
            services.AddTransient<IRequestHandler<WristPlusRotateRequest, WristPlusRotateResponse>, WristPlusRotateInteractor> ();
            services.AddTransient<IRequestHandler<WristMinusRotateRequest, WristMinusRotateResponse>, WristMinusRotateInteractor> ();

            services.AddMvc ()
                .AddJsonOptions (options =>
                {
                    // Prevent self reference looping when serialize to json
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add (new Newtonsoft.Json.Converters.StringEnumConverter ());
                })
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }
            else
            {
                app.UseHsts ();
            }

            // app.UseHttpsRedirection();

            // Enable the Swagger UI middleware and the Swagger generator
            app.UseSwaggerUi (typeof (Startup).GetTypeInfo ().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;

                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Robot API";
                    document.Info.Description = "A simple API to control a Robot";
                    document.Info.TermsOfService = "MIT";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Ricardo Fontana",
                        Email = "fontanaricardo@gmail.com",
                        Url = "https://www.linkedin.com/in/ricardo-fontana-70214847/"
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "MIT",
                        Url = "https://opensource.org/licenses/MIT"
                    };
                };
            });

            app.UseMvc ();
        }
    }
}