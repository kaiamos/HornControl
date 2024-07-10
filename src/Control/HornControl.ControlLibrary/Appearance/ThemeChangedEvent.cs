using System.Windows.Media;

namespace HornControl.ControlLibrary.Appearance
{
    /// <summary>
    /// 主题变化的委托.
    /// </summary>
    /// <param name="currentApplicationTheme">当前的主题.</param>
    /// <param name="systemAccent">系统颜色.</param>
    public delegate void ThemeChangedEvent(ApplicationTheme currentApplicationTheme, Color systemAccent);
}