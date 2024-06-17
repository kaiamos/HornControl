using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HornControl.Foundation.Attach
{
    /// <summary>
    /// 关于样式的附加属性
    /// </summary>
    public static partial class KAttach
    {
        /// <summary>
        /// 控件样式的类型
        /// </summary>
        public static readonly DependencyProperty StyleTypeProperty = 
            DependencyProperty.RegisterAttached("StyleType",typeof(StyleType),typeof(KAttach),new PropertyMetadata(default(StyleType)));
        public static StyleType GetStyleType(DependencyObject obj)
        {
            return (StyleType)obj.GetValue(StyleTypeProperty);
        }

        public static void SetStyleType(DependencyObject obj, StyleType value)
        {
            obj.SetValue(StyleTypeProperty, value);
        }

    }
}
