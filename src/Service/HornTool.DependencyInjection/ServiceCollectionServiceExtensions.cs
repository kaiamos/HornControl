using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornTool.DependencyInjection
{
    public static class ServiceCollectionServiceExtensions
    {
        #region AddTransient
        /// <summary>
        /// 将 <paramref name="serviceType"/> 中指定的类型的暂时性服务与 <paramref name="implementationType"/> 中指定的类型的实现添加到指定的 <see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="services">需要添加到 IServiceCollection 的服务</param>
        /// <param name="serviceType">要注册的服务类型</param>
        /// <param name="implementationType">服务的实现类型</param>
        /// <returns>操作完成后对此实例的引用</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType, Type implementationType)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            if (implementationType is null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }
            return Add(services, serviceType, implementationType, ServiceLifetime.Transient);
        }

        /// <summary>
        /// 将 TService 中指定的类型和 TImplementation 中指定的实现类型的瞬态服务添加到指定的 IServiceCollection 中
        /// </summary>
        /// <typeparam name="TService">需要添加到 IServiceCollection 的服务</typeparam>
        /// <typeparam name="TImplementation">服务的实现类型</typeparam>
        /// <param name="services">需要添加到 IServiceCollection 的服务</param>
        /// <returns>操作完成后对此实例的引用</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services) 
            where TService : class
            where TImplementation : class, TService
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            return AddTransient(services, typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        ///将 serviceType 中指定的类型的临时服务添加到指定的 IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            return services.AddTransient(serviceType, serviceType);
        }
        /// <summary>
        ///将 serviceType 中指定的类型的临时服务添加到指定的 IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services) where TService : class
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            return services.AddTransient(typeof(TService));
        }
        #endregion

        #region AddScoped
        /// <summary>
        /// 将 <paramref name="serviceType"/> 中指定的类型的作用域服务与 <paramref name="implementationType"/> 中指定的类型的实现添加到指定的 <see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="services">需要添加到 IServiceCollection 的服务</param>
        /// <param name="serviceType">要注册的服务类型</param>
        /// <param name="implementationType">服务的实现类型</param>
        /// <returns>操作完成后对此实例的引用</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType, Type implementationType)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            if (implementationType is null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }
            return Add(services, serviceType, implementationType, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// 将 TService 中指定的类型和 TImplementation 中指定的实现类型的作用域服务添加到指定的 IServiceCollection 中
        /// </summary>
        /// <typeparam name="TService">需要添加到 IServiceCollection 的服务</typeparam>
        /// <typeparam name="TImplementation">服务的实现类型</typeparam>
        /// <param name="services">需要添加到 IServiceCollection 的服务</param>
        /// <returns>操作完成后对此实例的引用</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            return AddScoped(services, typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        ///将 serviceType 中指定的类型的作用域服务添加到指定的 IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            return services.AddScoped(serviceType, serviceType);
        }
        /// <summary>
        ///将 serviceType 中指定的类型的作用域服务添加到指定的 IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services) where TService : class
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            return services.AddScoped(typeof(TService));
        }
        #endregion

        #region  AddSingleton
        /// <summary>
        /// 将 <paramref name="serviceType"/> 中指定的类型的单例服务与 <paramref name="implementationType"/> 中指定的类型的实现添加到指定的 <see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="services">需要添加到 IServiceCollection 的服务</param>
        /// <param name="serviceType">要注册的服务类型</param>
        /// <param name="implementationType">服务的实现类型</param>
        /// <returns>操作完成后对此实例的引用</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, Type implementationType)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            if (implementationType is null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }
            return Add(services, serviceType, implementationType, ServiceLifetime.Singleton);
        }

        /// <summary>
        /// 将 TService 中指定的类型和 TImplementation 中指定的实现类型的单例服务添加到指定的 IServiceCollection 中
        /// </summary>
        /// <typeparam name="TService">需要添加到 IServiceCollection 的服务</typeparam>
        /// <typeparam name="TImplementation">服务的实现类型</typeparam>
        /// <param name="services">需要添加到 IServiceCollection 的服务</param>
        /// <returns>操作完成后对此实例的引用</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            return AddSingleton(services, typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        ///将 serviceType 中指定的类型的单例服务添加到指定的 IServiceCollection
        /// </summary>
        /// <param name="services">需要添加到 IServiceCollection 的服务</param>
        /// <param name="serviceType">要注册的服务类型</param>
        /// <returns>操作完成后对此实例的引用</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            return services.AddSingleton(serviceType, serviceType);
        }
        /// <summary>
        ///将 serviceType 中指定的类型的单例服务添加到指定的 IServiceCollection
        /// </summary>
        /// <typeparam name="TService">需要添加到 IServiceCollection 的服务</typeparam>
        /// <returns>操作完成后对此实例的引用</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services) where TService : class
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            return services.AddSingleton(typeof(TService));
        }
        #endregion

        private static IServiceCollection Add(IServiceCollection collection, Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
            collection.Add(descriptor);
            return collection;
        }
    }
}
