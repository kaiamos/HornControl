using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornTool.DependencyInjection
{
    /// <summary>
    /// 服务容器.
    /// </summary>
    public class ServiceCollection : IServiceCollection
    {
        private readonly List<ServiceDescriptor> descriptors = new();

        /// <inheritdoc />
        public int Count => this.descriptors.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public ServiceDescriptor this[int index]
        {
            get
            {
                return this.descriptors[index];
            }

            set
            {
                this.descriptors[index] = value;
            }
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.descriptors.Clear();
        }

        /// <inheritdoc />
        public bool Contains(ServiceDescriptor item)
        {
            return this.descriptors.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            this.descriptors.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public bool Remove(ServiceDescriptor item)
        {
            return this.descriptors.Remove(item);
        }

        /// <inheritdoc />
        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            return this.descriptors.GetEnumerator();
        }

        /// <summary>
        /// 添加新实例.
        /// </summary>
        /// <param name="item">新实例.</param>
        void ICollection<ServiceDescriptor>.Add(ServiceDescriptor item)
        {
            this.descriptors.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <inheritdoc />
        public int IndexOf(ServiceDescriptor item)
        {
            return this.descriptors.IndexOf(item);
        }

        /// <inheritdoc />
        public void Insert(int index, ServiceDescriptor item)
        {
            this.descriptors.Insert(index, item);
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            this.descriptors.RemoveAt(index);
        }
    }
}
