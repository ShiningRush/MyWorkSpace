using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWorkSpace.Domain.AggregateRoots.UserAggregateRoot;
using MyWorkSpace.Domain.Infrastructure.DataAccess;
using Microsoft.AspNetCore.HttpOverrides;
using MyWorkSpace.Domain.Service;
using MyWorkSpace.Domain;
using MyWorkSpace.MPA.AuthPolicy;
using Microsoft.AspNetCore.Authorization;

namespace MyWorkSpace.MPA
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
            services.AddMvc();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<LoginService, LoginService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("baseAuth",
                                  policy => policy.Requirements.Add(new BaseAuthRequirment()));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = Consts.COOKIE_LOGIN_IDENTITY;
                options.DefaultAuthenticateScheme = Consts.COOKIE_LOGIN_IDENTITY;
                options.DefaultSignInScheme = Consts.COOKIE_LOGIN_IDENTITY;
            }).AddCookie(Consts.COOKIE_LOGIN_IDENTITY, options=> {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
            });

            services.AddSingleton<IAuthorizationHandler, BaseAuthRequirmentHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                // area route
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Default}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
