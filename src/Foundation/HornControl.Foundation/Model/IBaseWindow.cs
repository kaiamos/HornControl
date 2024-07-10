using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HornControl.Foundation.Model
{
    /// <summary>
    /// 基础窗口接口.
    /// </summary>
    public interface IBaseWindow
    {
        /// <summary>
        /// ShowDialog.
        /// </summary>
        /// <returns>是否成功展示。</returns>
        bool ShowDialog();

        bool Show();

        bool Close();
    }
}
