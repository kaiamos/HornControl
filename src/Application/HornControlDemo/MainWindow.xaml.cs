using Microsoft.Extensions.Hosting;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HornControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IHostApplicationLifetime applicationLifetime)
        {
            InitializeComponent();
            this.hostApplicationLifetime = applicationLifetime;
        }

        private readonly IHostApplicationLifetime? hostApplicationLifetime;

        protected override void OnClosed(EventArgs e)
        {
            hostApplicationLifetime?.StopApplication();
        }
    }
}