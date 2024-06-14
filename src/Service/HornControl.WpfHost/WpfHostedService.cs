using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HornControl.WpfHost
{
    public class WpfHostedService<TApplication, TMainWindow> : IHostedService
        where TApplication : Application
        where TMainWindow : Window
    {
        private readonly ILogger<WpfHostedService<TApplication, TMainWindow>> logger;

        public WpfHostedService(TApplication application, TMainWindow mainWindow, 
            IHostApplicationLifetime hostApplicationLifetime, ILogger<WpfHostedService<TApplication, TMainWindow>> logger)
        {
            this.logger = logger;
            this.application = application;
            this.mainWindow = mainWindow;
            // Host关闭时，关闭Application
            hostApplicationLifetime.ApplicationStopping.Register(application.Shutdown);
        }

        private readonly TApplication application;
        private readonly TMainWindow mainWindow;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // 设置Application声明周期与MainWindow无关
            application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            logger.LogInformation("启动窗口");
            application.Run(mainWindow);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("关闭窗口");
            return Task.CompletedTask;
        }
    }
}
