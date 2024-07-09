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
    /// <summary>
    /// DesignItem 将组件与服务系统和设计器连接起来。
    /// </summary>
    public abstract class DesignItem : INotifyPropertyChanged
    {
        /// <summary>
        /// 设计元素的名称
        /// </summary>
        public abstract string Name { get; set; }
        
        /// <summary>
        /// 属性名变化的事件
        /// </summary>
        public abstract event EventHandler NameChanged;

        /// <summary>
        /// x:key属性的值
        /// </summary>
        public abstract string Key { get; set; }

        /// <summary>
        /// 元素拖拽后的坐标
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// 设计器创建的组件
        /// </summary>
        public abstract object Component { get; }

        /// <summary>
        /// 组件的类型
        /// </summary>
        public abstract Type ComponentType { get; }

        /// <summary>
        /// 编辑组件的视图
        /// </summary>
        public abstract UIElement View { get; }

        /// <summary>
        /// 为指定的组件设置试图
        /// </summary>
        /// <param name="newView">组件</param>
        public abstract void SetView(UIElement newView);

        /// <summary>
        /// 设计器的上下文
        /// </summary>
        public abstract DesignContext Context { get; }

        /// <summary>
        /// 设计元素的父类
        /// </summary>
        public abstract DesignItem Parent { get; }
        
        /// <summary>
        /// 父元素变化的事件
        /// </summary>

        public abstract event EventHandler ParentChanged;

        /// <summary>
        /// 属性集合
        /// </summary>
        public abstract DesignItemPropertyCollection Properties { get; }


        public abstract string ContentPropertyName { get; }

        public DesignItemProperty ContentProperty
        {
            get
            {
                if (ContentPropertyName == null) return null;
                return Properties[ContentPropertyName];
            }
        }


        /// <summary>
        /// 元素变化的事件
        /// </summary>
        public abstract DesignItemProperty ParentProperty { get; }

        public ChangeGroup OpenGroup(string changeGroupTitle)
        {
            return this.Context.OpenGroup(changeGroupTitle, new DesignItem[] { this });
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
