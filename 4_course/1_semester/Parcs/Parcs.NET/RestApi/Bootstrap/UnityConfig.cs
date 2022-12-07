using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace RestApi.Bootstrap
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            new UnityRegistar().Register(container);

            var unityAdapter = new UnityServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => unityAdapter);

            return container;
        }
    }
}