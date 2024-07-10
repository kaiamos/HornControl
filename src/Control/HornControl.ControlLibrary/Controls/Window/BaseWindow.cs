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

namespace HornControl.ControlLibrary.Controls
{
    /// <summary>
    /// 基础窗口.
    /// </summary>
    public class BaseWindow : System.Windows.Window
    {
        static BaseWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow), new FrameworkPropertyMetadata(typeof(BaseWindow)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseWindow"/> class.
        /// </summary>
        public BaseWindow()
        {
            // 将窗体设置到屏幕中心位置
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // 样式中任务栏绑定的三个命令
            MaximizeWindowCommand = new RoutedUICommand();

            MinimizeWindowCommand = new RoutedUICommand();

            CloseWindowCommand = new RoutedUICommand();

            this.UIelementCommandBinding(MaximizeWindowCommand);

            this.UIelementCommandBinding(MinimizeWindowCommand);

            this.UIelementCommandBinding(CloseWindowCommand, CloseCommand_Execute);
        }



        public ICommand CloseWindowCommand { get; protected set; }
        public ICommand MaximizeWindowCommand { get; protected set; }
        public ICommand MinimizeWindowCommand { get; protected set; }

        private void CloseCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
        }
        


        public static readonly DependencyProperty ShowWindowAnimationProperty =
          DependencyProperty.Register(nameof(ShowWindowAnimation), typeof(Action<BaseWindow>), typeof(BaseWindow),
              new PropertyMetadata(default(Action<BaseWindow>), (d, e) =>
              {
                  BaseWindow control = d as BaseWindow;
                  if (control != null)
                  {
                      //Action<BaseWindow> config = e.NewValue as Action<BaseWindow>;
                  }
                  else
                  {
                      return;
                  }
              }));

        /// <summary>
        /// 打开窗口的动画
        /// </summary>
        Action<BaseWindow> ShowWindowAnimation
        {
            get { return (Action<BaseWindow>)GetValue(ShowWindowAnimationProperty); }
            set { SetValue(ShowWindowAnimationProperty, value); }
        }


        public static readonly DependencyProperty CloseWindowAnimationProperty =
           DependencyProperty.Register(nameof(CloseWindowAnimation), typeof(Action<BaseWindow>), typeof(BaseWindow), new PropertyMetadata(default(Action<BaseWindow>), (d, e) =>
           {
               BaseWindow control = d as BaseWindow;
               if (control != null)
               {
                   // Action<BaseWindow> config = e.NewValue as Action<BaseWindow>;
               }
               else
               {
                   return;
               }
           }));

        /// <summary>
        /// 关闭窗口的动画
        /// </summary>
        Action<BaseWindow> CloseWindowAnimation
        {
            get { return (Action<BaseWindow>)GetValue(CloseWindowAnimationProperty); }
            set { SetValue(CloseWindowAnimationProperty, value); }
        }

        public new bool? ShowDialog()
        {
            return base.ShowDialog();
        }

        public new void Show()
        {
            base.Show();
        }

        public void BeginClose()
        {
        }

        public virtual void RefreshHide()
        {
        }

        public virtual void Show(bool value)
        {
        }
    }
}
