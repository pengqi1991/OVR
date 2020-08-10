using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using OVR.DbContexts;
using OVR.UnitOfWork.UnitOfWork;
using OVR.WebCore.Logger;


namespace OVR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                var host = CreateHostBuilder(args).Build();
               // logger.Trace("��վ������...");
                using (IServiceScope scope = host.Services.CreateScope())
                {
                    //logger.Trace("��ʼ��NLog");
                    //ȷ��NLog.config�������ַ�����appsettings.json��ͬ��
                    NLogExtensions.EnsureNlogConfig("NLog.config", "SqlServer", scope.ServiceProvider.GetRequiredService<IConfiguration>().GetSection("ConectionStrings:SQLServerDbContext").Value);

                    //logger.Trace("��ʼ�����ݿ�");
                    //��ʼ�����ݿ�
                    

                    //for test -start
                    //���ڲ鿴��ɫ����̨��ʽ���Լ���־�ȼ�����
                    //logger.Trace("Test For Trace");
                    //logger.Debug("Test For Debug");
                   // logger.Info("Test For Info");
                   // logger.Warn("Test For Warn");
                    //logger.Error("Test For Error");
                    //logger.Fatal("Test For Fatal");
                    //for test -end
                }
               // logger.Trace("��վ�������");
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "��վ����ʧ��");
                throw;
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .AddNlogService();
    }
}