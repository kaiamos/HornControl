using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornTool.DependencyInjection
{

    /// <summary>
    /// 服务容器  其本质就是一个List
    /// </summary>
    public interface IServiceCollection : IList<ServiceDescriptor>
    {
    }
}
