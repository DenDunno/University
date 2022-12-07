using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace RestApi.Bootstrap
{
    internal class UnityServiceLocatorAdapter : ServiceLocatorImplBase
    {
        private readonly IUnityContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityServiceLocatorAdapter"/> class.
        /// </summary>
        /// <param name="container">The inner Unity container to use for service location.</param>
        public UnityServiceLocatorAdapter(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of resolving
        /// the requested service instance.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>
        /// The requested service instance.
        /// </returns>
        /// <exception cref="InstanceNotFoundException">Resolution of concrete instance failed.</exception>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            try
            {
                return _container.Resolve(serviceType, key);
            }
            catch (ResolutionFailedException resolutionFailedException)
            {
                throw ErrorResolutionFailed(resolutionFailedException);
            }
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of
        /// resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>
        /// Sequence of service instance objects.
        /// </returns>
        /// <exception cref="InstanceNotFoundException">Resolution of at least one concrete instance failed.</exception>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException resolutionFailedException)
            {
                throw ErrorResolutionFailed(resolutionFailedException);
            }
        }

        private static ActivationException ErrorResolutionFailed(ResolutionFailedException inner)
        {
            string message = string.Format("Instance resolution failed. Type={0}, Name='{1}'.", inner.TypeRequested, inner.NameRequested);
            return new ActivationException(message, inner);
        }
    }
}