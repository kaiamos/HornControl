using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HornControl.Designer.Design
{
    public abstract class DesignContext
    {
        /// <summary>
        /// 根节点
        /// </summary>
        public abstract DesignItem RootItem { get; }

        /// <summary>
        /// 保存xaml文档
        /// </summary>
        /// <param name="writer"></param>
        public abstract void Save(XmlWriter writer);

        public abstract ChangeGroup OpenGroup(string changeGroupTitle, ICollection<DesignItem> affectedItems);
    }
}
