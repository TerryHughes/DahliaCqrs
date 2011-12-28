namespace NServiceBus
{
    using System.Linq;
    using System.Web.Mvc;
    using NServiceBus.ObjectBuilder;
    using Dahlia.Repositories;

    public static class ConfigureExtensionsWebApp
    {
        public static Configure WithRepositories(this Configure configure)
        {
            configure.Configurer.RegisterSingleton(typeof(ProcessCommandRepository), new SqlServerProcessCommandRepository());

            return configure;
        }
    }
}
