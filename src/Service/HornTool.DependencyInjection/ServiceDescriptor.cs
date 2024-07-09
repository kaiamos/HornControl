using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornTool.DependencyInjection
{

    /// <summary>
    /// 服务描述类，包含服务的类型，生命周期等定义.
    /// </summary>
    public class ServiceDescriptor
    {
        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDescriptor"/> class.
        /// </summary>
        /// <param name="serviceType">service type.</param>
        /// <param name="implementationType">service of implementationType.</param>
        /// <param name="lifetime">life time.</param>
        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
            : this(serviceType, lifetime)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            this.ImplementationType = implementationType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDescriptor"/> class.
        /// </summary>
        /// <param name="serviceType">the service type.</param>
        /// <param name="instance">the instance of the serviceType.</param>
        /// <exception cref="ArgumentNullException">throw execption.</exception>
        public ServiceDescriptor(Type serviceType, object instance)
            : this(serviceType, ServiceLifetime.Singleton)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            this.ImplementationInstance = instance;
        }

        private ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
        {
            this.Lifetime = lifetime;
            this.ServiceType = serviceType;
        }
        #endregion

        #region  属性

        /// <summary>
        /// Gets - 获取服务的生命周期.
        /// </summary>
        public ServiceLifetime Lifetime { get; }

        /// <summary>
        /// Gets - 获取服务的类型.
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// Gets - 获取实现服务的类型.
        /// </summary>
        public Type? ImplementationType { get; }

        /// <summary>
        ///  gets - 获取实现服务的实例.
        /// </summary>
        public object? ImplementationInstance { get; }

        #endregion

        #region Creates an instance of <see cref="ServiceDescriptor"/> with the specified

        /// <summary>
        /// Initializes .
        /// </summary>
        /// <typeparam name="TService">the type of service.</typeparam>
        /// <typeparam name="TImplementation">the service implement.</typeparam>
        /// <returns>a new instance of <see cref="ServiceDescriptor"/>. </returns>
        public static ServiceDescriptor Transient<TService, TImplementation>()
           where TService : class
           where TImplementation : class, TService
        {
            return Describe<TService, TImplementation>(ServiceLifetime.Transient);
        }

        public static ServiceDescriptor Transient( Type service, Type implementationType)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return Describe(service, implementationType, ServiceLifetime.Transient);
        }

        public static ServiceDescriptor Scoped<TService, TImplementation>()
           where TService : class
           where TImplementation : class, TService
        {
            return Describe<TService, TImplementation>(ServiceLifetime.Scoped);
        }

        public static ServiceDescriptor Scoped(Type service, Type implementationType)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return Describe(service, implementationType, ServiceLifetime.Scoped);
        }

        public static ServiceDescriptor Singleton<TService, TImplementation>()
           where TService : class
           where TImplementation : class, TService
        {
            return Describe<TService, TImplementation>(ServiceLifetime.Singleton);
        }

        public static ServiceDescriptor Singleton(Type service, Type implementationType)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return Describe(service, implementationType, ServiceLifetime.Singleton);
        }

        public static ServiceDescriptor Singleton<TService>(TService implementationInstance)  where TService : class
        {
            if (implementationInstance == null)
            {
                throw new ArgumentNullException(nameof(implementationInstance));
            }

            return Singleton(typeof(TService), implementationInstance);
        }

        /// <summary>
        /// 创建单例对象.
        /// </summary>
        /// <param name="serviceType">service type</param>
        /// <param name="implementationInstance">implementation Instance.</param>
        /// <returns>Instance.</returns>
        /// <exception cref="ArgumentNullException">throw ArgumentNullException.</exception>
        public static ServiceDescriptor Singleton(Type serviceType, object implementationInstance)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationInstance == null)
            {
                throw new ArgumentNullException(nameof(implementationInstance));
            }

            return new ServiceDescriptor(serviceType, implementationInstance);
        }

        #endregion

        private static ServiceDescriptor Describe<TService, TImplementation>(ServiceLifetime lifetime)
           where TService : class
           where TImplementation : class, TService
        {
            return Describe(
                typeof(TService),
                typeof(TImplementation),
                lifetime: lifetime);
        }

        /// <summary>
        /// 对服务进行初始化.
        /// </summary>
        /// <param name="serviceType">服务类型.</param>
        /// <param name="implementationType">接口实现类型.</param>
        /// <param name="lifetime">生命周期.</param>
        /// <returns>ServiceDescriptor 对象.</returns>
        public static ServiceDescriptor Describe(Type serviceType,Type implementationType,ServiceLifetime lifetime)
        {
            return new ServiceDescriptor(serviceType, implementationType, lifetime);
        }

        /// <summary>
        /// 重载 ToString 方法.
        /// </summary>
        /// <returns>字符串表示.</returns>
        public override string ToString()
        {
            string? lifetime = $"{nameof(this.ServiceType)}: {this.ServiceType} {nameof(this.Lifetime)}: {this.Lifetime} ";

            if (this.ImplementationType != null)
            {
                return lifetime + $"{nameof(this.ImplementationType)}: {this.ImplementationType}";
            }

            return lifetime + $"{nameof(this.ImplementationInstance)}: {this.ImplementationInstance}";
        }

        /// <summary>
        /// 获取实现类的类型.
        /// </summary>
        /// <returns>类型.</returns>
        internal Type GetImplementationType()
        {
            if (this.ImplementationType is not null)
            {
                return this.ImplementationType;
            }
            else if (this.ImplementationInstance is not null)
            {
                return this.ImplementationInstance.GetType();
            }

            Debug.Assert(false, "ImplementationType or ImplementationInstance  must be non null");
            return null;
        }
    }
}
