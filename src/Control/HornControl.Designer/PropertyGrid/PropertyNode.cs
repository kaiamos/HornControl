using HornControl.Designer.Design;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HornControl.Designer.PropertyGrid
{
    public class PropertyNode : INotifyPropertyChanged
    {
        /// <summary>
        /// 属性集合
        /// </summary>
        public ReadOnlyCollection<DesignItemProperty> Properties
        {
            get; private set;
        }

        bool hasStringConverter;//是否拥有字符串转化器

        public DesignItemProperty FirstProperty { get { return Properties[0]; } }

        public string Name
        {
            get
            {
                var dp = FirstProperty.DependencyProperty;
                if (dp != null)
                {
                    var dpd = DependencyPropertyDescriptor.FromProperty(dp, FirstProperty.DesignItem.ComponentType);
                    if (dpd.IsAttached)
                    {
                        return dpd.Name;
                    }
                }
                return FirstProperty.Name;
            }
        }






        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;

            if (handler is not null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
