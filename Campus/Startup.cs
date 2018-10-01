using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus.Bll;
using Campus.BllInterface;
using Campus.Dal;
using Campus.DalInterface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UEditorNetCore;

namespace Campus
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
            services.AddUEditorService();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddTransient<IUserBll, UserBll>();
            services.AddTransient<IUserDal, UserDal>();
            services.AddTransient<IRoleBll, RoleBll>();
            services.AddTransient<IRoleDal, RoleDal>();
            services.AddTransient<IHomeworkBll, HomeworkBll>();
            services.AddTransient<IHomeworkDal, HomeworkDal>();
            services.AddTransient<IAnswerBll, AnswerBll>();
            services.AddTransient<IAnswerDal, AnswerDal>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/User/login";
                    option.AccessDeniedPath = "/Homework/ErrorHints";
                });
            services.AddDbContext<CampusDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Campus"),x => x.UseRowNumberForPaging());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always
            });
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
