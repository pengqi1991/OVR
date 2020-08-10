using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OVR.Component.Aop;
using OVR.DbContexts;
using OVR.Filters;
using OVR.Models.Automapper;
using OVR.Services;
using OVR.Services.RoleS;
using OVR.UnitOfWork;

namespace OVR
{
    public class Startup
    {
        public ILifetimeScope AutofacContainer { get; private set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
             Configuration = builder.Build();
           // Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<ApiExceptionFilter>();
            });
            //ע��automapper����
            services.AddAutomapperService();
            services.AddUnitOfWorkService<MSDbContext>(options => { options.UseSqlServer(Configuration.GetSection("ConectionStrings:SQLServerDbContext").Value); });

        }
        //���autofac��DI��������
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //ע��IBaseService��IRoleService�ӿڼ���Ӧ��ʵ����
            //builder.RegisterType<BaseService>().As<IBaseService>().InstancePerLifetimeScope();
            //builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();

            //ע��aop������ 
            //��ҵ���������ƴ��˽�ȥ����ҵ���ӿں�ʵ������ע�ᣬҲ��ҵ�������������˴���
            builder.AddAopService(ServiceExtensions.GetAssemblyName());
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
