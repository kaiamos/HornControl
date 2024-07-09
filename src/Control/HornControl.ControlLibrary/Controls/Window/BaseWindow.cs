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
    public class BaseWindow : Window
    {
        static BaseWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow), new FrameworkPropertyMetadata(typeof(BaseWindow)));
        }

        public BaseWindow()
        {
            //将窗体设置到屏幕中心位置
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //样式中任务栏绑定的三个命令
            MaximizeWindowCommand = new RoutedUICommand();
            MinimizeWindowCommand = new RoutedUICommand();
            CloseWindowCommand = new RoutedUICommand();
            this.UIelementCommandBinding(MaximizeWindowCommand);
            this.UIelementCommandBinding(MinimizeWindowCommand);
            this.UIelementCommandBinding(CloseWindowCommand, CloseCommand_Execute);
        }


        #region 命令

        public ICommand CloseWindowCommand { get; protected set; }
        public ICommand MaximizeWindowCommand { get; protected set; }
        public ICommand MinimizeWindowCommand { get; protected set; }

        private void CloseCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion

        #region 属性

        #region ShowWindowAnimation

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
        #endregion

        #region CloseWindowAnimation

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
        #endregion

        #endregion
        public new bool ShowDialog()
        {
            return base.ShowDialog();
        }

        public new void Show()
        {
            base.Show();
        }

        public void BeginClose()
        {
            CloseWindowAnimation?.Invoke(this);
        }

        public virtual void RefreshHide()
        {
        }

        public virtual void Show(bool value)
        {
            IWindowAnimationService animation = ServiceRegistry.Instance.GetInstance<IWindowAnimationService>();

            if (animation == null)
            {
                if (value)
                {
                    Show();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                if (value)
                {
                    animation?.ShowAnimation(this);
                }
                else
                {
                    animation?.CloseAnimation(this);
                }
            }

        }

    }
}
