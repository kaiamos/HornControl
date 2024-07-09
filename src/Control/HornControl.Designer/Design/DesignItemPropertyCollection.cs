using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HornControl.Designer.Design
{
    public abstract class DesignItemPropertyCollection : IEnumerable<DesignItemProperty>
    {

        public abstract DesignItemProperty GetProperty(string name);

        public DesignItemProperty this[string name]
        {
            get { return GetProperty(name); }
        }

        public DesignItemProperty this[DependencyProperty dependencyProperty]
        {
            get
            {
                return GetProperty(dependencyProperty);
            }
        }


        public DesignItemProperty GetProperty(DependencyProperty dependencyProperty)
        {
            if (dependencyProperty == null)
                throw new ArgumentNullException("dependencyProperty");
            return GetProperty(dependencyProperty.Name);
        }

        /// <summary>
        /// 获取附加属性
        /// </summary>
        /// <param name="ownerType">拥有者</param>
        /// <param name="name">属性名</param>
        /// <returns></returns>
        public abstract DesignItemProperty GetAttachedProperty(Type ownerType, string name);

        /// <summary>
        /// 获取附加属性
        /// </summary>
        /// <param name="dependencyProperty">依赖属性</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public DesignItemProperty GetAttachedProperty(DependencyProperty dependencyProperty)
        {
            if (dependencyProperty == null)
            {
                throw new ArgumentNullException("dependencyProperty");
            }
            return GetAttachedProperty(dependencyProperty.OwnerType, dependencyProperty.Name);
        }

        public abstract IEnumerator<DesignItemProperty> GetEnumerator();
       

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
