using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CinemaTicketManagementSystem
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
            services.AddControllersWithViews();

            //Database Context Configuration
            services.AddDbContext<CinemaTicketDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            //Dependency Injection ; I have created a class which contains all depedencies here I am calling it 
            //All Scoped Injection
            services.InjectServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                /*Whenever any request comes these all middlewares gets executed but when we apply debugger on it 
                 It does not stops because these are built in and abstraction is being achieved
                 If you try to look into implementation of any middleware then you will just see comments not code that's abstraction
                 So Point is for every request all middlewares first get executed then sends it to next so I was confused if it comes 
                 here at each request then for each request PageNotFound should be displayed but not when a valid Path comes it gets overrided
                 with last middleware app.UseEndpoints but if in UseEndpoints Path is not valid then when request travels back then 
                 its being handled in very first middleware.

                These all are built in middleware
                    app.UseHttpsRedirection();
                    app.UseStaticFiles();
                    app.UseRouting();
                    app.UseAuthorization();

                This is custom middleware
                    app.UseStatusCodePagesWithRedirects

                Use in each middleware indicates that it will call next mddleware automatically
                 */
                app.UseStatusCodePagesWithRedirects("/ErrorsHandler/PageNotFound");
            }
            else
            {
                app.UseExceptionHandler("/ErrorsHandler/PageNotFound");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                /*I have removed Home Controller and Now Home Page is set to Movies Index Page
                 Controller means any controller within request;Deafult is Movies for very first time
                 Action means any action within request; Deafult is Index for very first time*/

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}");
                
            });
            DbInitializer.Seed(app);
        }
    }
}
