using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornControl.ControlLibrary.Appearance
{
    /// <summary>
    /// 应用主题管理.
    /// </summary>
    public static class ApplicationThemeManager
    {
        /// <summary>
        /// 主题字典路径.
        /// </summary>
        internal const string ThemesDictionaryPath = "pack://application:,,,/HornControl.Resource;component/Theme/";

        /// <summary>
        /// 库命名空间.
        /// </summary>
        internal const string LibraryNamespace = "HornControl.ControlLibrary;";

        /// <summary>
        /// 主题变化事件.
        /// </summary>
        public static event ThemeChangedEvent? ApplicationThemeChanged;

        /// <summary>
        /// 应用主题.
        /// </summary>
        /// <param name="applicationTheme">应用主题</param>
        /// <param name="backgroundEffect"></param>
        /// <param name="updateAccent"></param>
        public static void AppTheme(ApplicationTheme applicationTheme,bool updateAccent = true)
        {

        }
    }
}
