using HornControl.Designer.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HornControl.Designer.Design
{
    public abstract class DesignItemProperty : INotifyPropertyChanged
    {
		public abstract string Name { get; }

        public string FullName
        {
            get
            {
                return DeclaringType.FullName + "." + Name;
            }
        }

        public abstract DesignItem Value { get; }

        public abstract string TextValue { get; }

        public abstract event EventHandler ValueChanged;

        public abstract event EventHandler ValueOnInstanceChanged;

        public abstract object DesignerValue { get; }

        public abstract object ValueOnInstance { get; }

        public abstract Type ReturnType { get; }

        public abstract Type DeclaringType { get; }

        public abstract string Category { get; }

        public virtual TypeConverter TypeConverter
        {
            get { return TypeDescriptor.GetConverter(this.ReturnType); }
        }

        /// <summary>
        /// 获取属性是否表示集合。
        /// </summary>
        public abstract bool IsCollection { get; }

        public abstract bool IsEvent { get; }

        public abstract IObservableList<DesignItem> CollectionElements { get; }

        public abstract void SetValue(object value);

        public abstract bool IsSet { get; }

        public abstract event EventHandler IsSetChanged;

        public abstract void Reset();

        public abstract T GetConvertedValueOnInstance<T>();

        public abstract DesignItem DesignItem { get; }

        public abstract DependencyProperty DependencyProperty { get; }

        public virtual bool IsAdvanced { get { return false; } }

        public object ValueOnInstanceOrView
        {
            get { return Value == null ? ValueOnInstance : Value.View; }
        }

        public string DependencyFullName
        {
            get
            {
                if (DependencyProperty != null)
                {
                    return DependencyProperty.GetFullName();
                }
                return FullName;
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
