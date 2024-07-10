using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace HornControl.ControlLibrary.Controls
{
    /// <summary>
    /// 流式窗口.
    /// </summary>
    public class FluentWindow : System.Windows.Window
    {
        static FluentWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FluentWindow), new FrameworkPropertyMetadata(typeof(FluentWindow)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentWindow"/> class.
        /// </summary>
        public FluentWindow()
        {
            this.SetResourceReference(StyleProperty, typeof(FluentWindow));
        }
    }
}
