using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HornControl.Designer.Extensions
{
    public static class Metadata
    {
        public static string GetFullName(this DependencyProperty p)
        {
            return p.OwnerType.FullName + "." + p.Name;
        }
    }
}
