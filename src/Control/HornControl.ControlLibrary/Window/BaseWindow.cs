using HornControl.Foundation.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HornControl.ControlLibrary
{
    public class BaseWindow : Window
    {
        static BaseWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow), new FrameworkPropertyMetadata(typeof(BaseWindow)));
        }

        public BaseWindow()
        {
            //样式中任务栏绑定的三个命令
            this.MaximizeWindowCommand = new RoutedUICommand();
            this.MinimizeWindowCommand = new RoutedUICommand();
            this.CloseWindowCommand = new RoutedUICommand();

            this.UIelementCommandBinding(MaximizeWindowCommand);
            this.UIelementCommandBinding(MinimizeWindowCommand);
            this.UIelementCommandBinding(CloseWindowCommand, CloseCommand_Execute);
        }


        #region 命令

        public ICommand? CloseWindowCommand { get; protected set; }
        public ICommand? MaximizeWindowCommand { get; protected set; }
        public ICommand? MinimizeWindowCommand { get; protected set; }
        private void CloseCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
        }
        #endregion


    }
}
