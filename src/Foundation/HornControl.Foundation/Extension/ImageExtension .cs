using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HornControl.Foundation
{
    /// <summary>
    /// 将字体转为图片
    /// </summary>
    [MarkupExtensionReturnType(typeof(DrawingImage))]
    public class ImageExtension : StaticResourceExtension
    {
        //private static readonly FontFamily fontFamily =
        //    new FontFamily(new Uri("pack://application:,,,/HornControl.Resource;component/Font/Microsoft/SegoeMDL2Assets.ttf#SegoeMDL2Assets"),
        //        "pack://application:,,,/HornControl.Resource;component/Font/Microsoft/SegoeMDL2Assets.ttf#SegoeMDL2Assets");

        public FontFamily FontFamily { get; set; } = new FontFamily(
            new Uri("pack://application:,,,/HornControl.Resource;component/Font/Microsoft/SegMDL2.ttf#Segoe MDL2 Assets"),
                "pack://application:,,,/HornControl.Resource;component/Font/Microsoft/SegMDL2.ttf#Segoe MDL2 Assets");

        public int SymbolCode { get; set; }

        public double SymbolSize { get; set; } = 16;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var textBlock = new TextBlock
            {
                FontFamily = FontFamily,
                Text = char.ConvertFromUtf32(SymbolCode)
            };

            var brush = new VisualBrush
            {
                Visual = textBlock,
                Stretch = Stretch.Uniform
            };

            var drawing = new GeometryDrawing
            {
                Brush = brush,
                Geometry = new RectangleGeometry(new Rect(0, 0, SymbolSize, SymbolSize))
            };
            return new DrawingImage(drawing);
        }
    }
}
