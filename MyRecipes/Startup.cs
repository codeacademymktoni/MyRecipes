using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipes.Custom.Extensions;
using MyRecipes.Data;
using MyRecipes.Options;
using MyRecipes.Repository;
using MyRecipes.Repository.Interfaces;
using MyRecipes.Services;
using MyRecipes.Services.Interfaces;

namespace MyRecipes
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

            services.AddDbContext<MyRecipesContext>(options  => 
                options
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("MyRecipesDemo")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ContactUsInfo>(Configuration.GetSection("ContactUsInfo"));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options => {
                options.LoginPath = "/auth/signin";
                options.AccessDeniedPath = "/auth/accessDenied";
            });

            services.AddAuthorization(options =>
                options.AddPolicy(
                    "IsAdmin", 
                    policy => policy.RequireClaim("IsAdmin", "True"))
            );

            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IRecipesService, RecipesService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IRecipeCommentsService, RecipeCommentsService>();
            services.AddTransient<IRecipeCommentsRepository, RecipeCommentsRepository>();
            services.AddTransient<ILogsService, LogsService>();
            services.AddTransient<ILogsRepository, LogsRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCustomExceptionHandler();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Recipes}/{action=Overview}/{id?}");
            });
        }
    }
}
