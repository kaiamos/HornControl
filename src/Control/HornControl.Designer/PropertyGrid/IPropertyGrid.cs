using HornControl.Designer.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornControl.Designer.PropertyGrid
{
    /// <summary>
    /// 编辑器表格
    /// </summary>
    public interface IPropertyGrid
    {
        IEnumerable<DesignItem> SelectedItems { get; set; }
        Dictionary<MemberDescriptor, PropertyNode> NodeFromDescriptor { get; }
        DesignItem SingleItem { get; }
        string Name { get; set; }
        string OldName { get; }
        bool IsNameCorrect { get; set; }
        bool ReloadActive { get; }
        event EventHandler AggregatePropertiesUpdated;
        event PropertyChangedEventHandler PropertyChanged;
    }
}
