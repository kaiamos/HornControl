using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HornControl.Foundation.Extension
{
    public static class UIElementExtention
    {
        /// <summary>
        /// 对 UIElement进行命令绑定 - 无执行方法
        /// </summary>
        /// <param name="uIElement">UI元素</param>
        /// <param name="command">命令</param>
        public static void UIelementCommandBinding(this UIElement uIElement, ICommand command)
        {
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = command;
            uIElement.CommandBindings.Add(commandBinding);
        }

        /// <summary>
        /// 对 UIElement进行命令绑定
        /// </summary>
        /// <param name="uIElement">UI元素</param>
        /// <param name="command">命令</param>
        /// <param name="action">执行方法</param>
        public static void UIelementCommandBinding(this UIElement uIElement,ICommand command,Action<object,ExecutedRoutedEventArgs> action)
        {
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = command;
            commandBinding.Executed += new ExecutedRoutedEventHandler(action);
            uIElement.CommandBindings.Add(commandBinding);
        }

       
    }
}
