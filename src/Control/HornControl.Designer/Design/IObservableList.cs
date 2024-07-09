using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornControl.Designer.Design
{
    public interface IObservableList<T> : IList<T>, INotifyCollectionChanged
    {
    }
}
