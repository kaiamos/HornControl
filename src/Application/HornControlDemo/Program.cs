using HornControl.WpfHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornControlDemo
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            WPFHost.Run<App, MainWindow>(args, hostBuilder =>
            {
                hostBuilder
                .ConfigureAppConfiguration((context,app) =>
                {
                    //添加配置文件
                    app.AddJsonFile("appsettings.json",true);
                })
                .UseSerilog((context, logger) =>
                {
                    //加载 Serilog 配置项
                    logger.ReadFrom.Configuration(context.Configuration);
                    logger.Enrich.FromLogContext();
                })
                .ConfigureServices((context, services) => 
                {
                    //加载服务
                    services.AddSingleton<App>();
                    services.AddTransient<MainWindow>();
                    services.AddHostedService<WpfHostedService<App, MainWindow>>();
                });
            });

            //TODO:命令，动画，行为，样式
        }
    }
}
