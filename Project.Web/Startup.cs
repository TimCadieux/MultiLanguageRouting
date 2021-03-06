using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Project.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web
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
            // --> localization and route translation
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>();
                var defaultRequestCulture = Configuration.GetSection("AppSettings:DefaultRequestCulture").Value;
                var cultureSettings = Configuration.GetSection("AppSettings:SupportedCultures").Value?.Split(new[] { ',' }).ToList();
                cultureSettings.ForEach(delegate (string culture)
                {
                    supportedCultures.Add(new CultureInfo(culture));
                });

                options.DefaultRequestCulture = new RequestCulture(culture: defaultRequestCulture, uiCulture: defaultRequestCulture); // en
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                var requestProvider = new RouteDataRequestCultureProvider() { Options = options };
                options.RequestCultureProviders.Insert(0, requestProvider);
            });
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<TranslationRoute>();
            services.AddSingleton<TranslationTransformer>();
            // <--


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();


            // --> route translation
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
            // <--

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{culture=en}/{controller=home}/{action=index}");
                endpoints.MapDynamicControllerRoute<TranslationTransformer>("{culture}/{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
