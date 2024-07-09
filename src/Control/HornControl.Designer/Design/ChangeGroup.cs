using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornControl.Designer.Design
{
    public abstract class ChangeGroup:IDisposable
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; }

        public abstract void Commit();

        public abstract void Abort();

        protected abstract void Dispose();

        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}
