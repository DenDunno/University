using System;
using DataAccess.Auth;
using DataAccess.Logs;
using Microsoft.Practices.Unity;
using RestApi.Services;

namespace RestApi.Bootstrap
{
    public class UnityRegistar
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IRestApiClient, RestApiClient>();
            container.RegisterType<ILogEntryRepository>(
                new InjectionFactory(_ => new LogEntryRepository(GetConnectionString())));
            container.RegisterType<IParcsService, ParcsService>();
            container.RegisterType<IAuthRepository, AuthRepository>();
            container.RegisterType<IModuleRunner, ModuleRunner>();
            container.RegisterType<IModuleService, ModuleService>();
        }

        private string GetConnectionString()
        {
            string connectionStringOrName = Environment.GetEnvironmentVariable(EnvironmentVariables.LogConnectionString);

            if (string.IsNullOrWhiteSpace(connectionStringOrName))
            {
                connectionStringOrName = "HostServerContext";
            }

            return connectionStringOrName;
        }
    }
}