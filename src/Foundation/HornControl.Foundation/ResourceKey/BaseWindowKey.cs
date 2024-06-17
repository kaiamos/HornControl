using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HornControl.Foundation.ResourceKey
{
    public class BaseWindowKey
    {
        /// <summary>
        /// 默认的 BaseWindow 的样式 key
        /// </summary>
        public ComponentResourceKey Default => new ComponentResourceKey(typeof(BaseWindowKey), "BaseWindow.Default");
    }
}
