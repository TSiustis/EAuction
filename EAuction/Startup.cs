using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using EAuction.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EAuction.Models;
using EAuction.Hubs;
using Microsoft.Data.SqlClient;

namespace EAuction
{
    public class Startup
    {
        private string _connection = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environment.Equals("PRODUCTION"))
            {
                var builder = new SqlConnectionStringBuilder(
               Configuration.GetConnectionString("DefaultConnection"));

                _connection = builder.ConnectionString;
                builder.Password = Configuration["Password"];
                _connection = builder.ConnectionString;
            }else if (environment.Equals("DEVELOPMENT"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
              options.UseLazyLoadingProxies()
                  .UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            }
            services.AddDbContext<ApplicationDbContext>();
            services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();
            services.AddTransient<IAuctionRepository, AuctionRepository>()  ;
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<AuctionHub>("/auctionhub");
            });
            SeedData.Seed(app);
        }
    }
}
