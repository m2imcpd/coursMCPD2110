using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoursAspNetCore
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults : new
                    {
                        controller = "Home",
                        action = "Index"
                    }
                );
                routes.MapRoute(
                    name: "formProduct",
                    template: "formProduct/{type?}/{message?}",
                    defaults: new
                    {
                        controller = "Panier",
                        action = "FormProduct"
                    }
                );
                routes.MapRoute(
                    name: "user",
                    template: "Detail/{nom}/{prenom}",
                    defaults: new
                    {
                        controller = "AppUser",
                        action = "DetailMore"
                    }
                    );

                routes.MapRoute(
                    name : "maRoute",
                    template :"toto",
                    defaults : new 
                    {
                        controller = "Test",
                        action = "Index",
                    }
                    );
            });
        }
    }
}
