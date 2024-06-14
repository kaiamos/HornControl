
using Microsoft.Extensions.Hosting;

namespace HornControl.WpfHost
{
    public static class WPFHost
    {
        public static void Run<TApplication, TMainWndow>(string[] args, Action<IHostBuilder>? action = null)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            action?.Invoke(hostBuilder);
            hostBuilder.Build().Run();
        }
    }
}
