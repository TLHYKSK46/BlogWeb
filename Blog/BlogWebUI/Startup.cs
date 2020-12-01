using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogBusiness.Concreate;
using BlogDataAccess.Abstract;
using BlogDataAccess.Concreate.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogWebUI
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

            services.AddControllersWithViews()
              .AddRazorRuntimeCompilation();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();

            //services.AddDbContext<BlogContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            services.AddScoped<IMakaleServis, MakaleYonetici>();
            services.AddScoped<IMakaleDal, EfMakaleDal>();

            services.AddScoped<IKategoriServis, KategoriYonetici>();
            services.AddScoped<IKategoriDal, EfKategoriDal>();

            services.AddScoped<IKullaniciServis, KullaniciYonetici>();
            services.AddScoped<IKullaniciDal, EfKullaniciDal>();

            services.AddScoped<IYorumServis, YorumYonetici>();
            services.AddScoped<IYorumDal, EfYorumDal>();

            services.AddScoped<IHakkimdaServis, HakkimdaYonetici>();
            services.AddScoped<IHakkimdaDal, EfHakkimdaDal>();

            services.AddScoped<IReferansServis, ReferansYonetici>();
            services.AddScoped<IReferansDal, EfReferansDal>();

            services.AddScoped<IIletisimServis, IletisimYonetici>();
            services.AddScoped<IIletisimDal, EfIletisimDal>();

          

            //services.AddScoped<IRolServis, RolYonetici>();
            //services.AddScoped<IRolDal, EfRolDal>();

            //services.AddEntityFrameworkNpgsql().AddDbContext<MyWebApiContext>(opt =>
            //opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection"));
            //options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));





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
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<BlogContext>();
            //    context.Database.Migrate();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //      name: "areas",
            //      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                "Admin",
                "Admin",
                "Admin/{controller=AdminHome}/{action=Index}/{id?}");

            });
        }
    }
}
