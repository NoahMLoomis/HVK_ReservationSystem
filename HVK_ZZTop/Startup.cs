using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HVK_ZZTop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace HVK_ZZTop {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddTransient<Models.FormattingService>();
            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();
            services.AddSession();


            services.AddDbContext<HVK_ZZTopContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HVK_ZZTopContext"))
            );


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=> {
                options.LoginPath = "/Login";// Default /Acount/Login
                options.LogoutPath = "/Logout";// Default /Acount/Logout
                options.AccessDeniedPath = "/AccessDenied";// Default /Acount/AccessDenied
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy(new CookiePolicyOptions {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            });

            app.UseSession();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
