using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWebSite.Domain;
using MyWebSite.Domain.Repositories.Abstract;
using MyWebSite.Domain.Repositories.EntityFramework;
using MyWebSite.Service;

namespace MyWebSite
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;


        public void ConfigureServices(IServiceCollection services)
        {
            //Add configuration witch appsetings.json
            Configuration.Bind("Project", new Config());

            //Add functions application 
            //For example, if you need to change the ORM system, you only need to replace these parameters here.
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();

            //Add context Db
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //Gonfiguring identity system 
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //Configuring authentication cookies
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "SoloviovAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });
            //Configuring policy authorization for Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //Add support controllers and views (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //version asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // The procedure for registering meddleware is important!

            // If we are in development then this item helps to display errors to the developer in the browser
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Connect support of static files in the project(css, js...)
            app.UseStaticFiles();

            //Add system routing 
            app.UseRouting();

            //Add authentication and authorization
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // register the routes we need (endpoints)
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
       
        }
    }
}
