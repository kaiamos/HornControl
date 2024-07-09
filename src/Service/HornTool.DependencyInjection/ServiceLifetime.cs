using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornTool.DependencyInjection
{
    public enum ServiceLifetime
    {
        /// <summary>
        /// 指定将创建服务的单个实例。
        /// </summary>
        Singleton,
        /// <summary>
        /// 指定每个作用域创建服务的新实例。
        /// </summary>
        Scoped,
        /// <summary>
        /// 指定每次请求服务时都将创建该服务的新实例。
        /// </summary>
        Transient
    }
}
