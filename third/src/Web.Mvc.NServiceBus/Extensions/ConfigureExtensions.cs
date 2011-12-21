namespace NServiceBus
{
    using System.Linq;
    using System.Web.Mvc;
    using NServiceBus.ObjectBuilder;
    using Dahlia.Web.Mvc;

    public static class ConfigureExtensions
    {
        public static Configure ForMvc(this Configure configure)
        {
            configure.Configurer.RegisterSingleton(typeof(IControllerActivator), new DependencyResolverControllerActivator());

            var controllers = Configure.TypesToScan.Where(typeof(IController).IsAssignableFrom);
            foreach (var controller in controllers)
                configure.Configurer.ConfigureComponent(controller, ComponentCallModelEnum.Singlecall);

            DependencyResolver.SetResolver(new NServiceBusDependencyResolver(configure.Builder));

            return configure;
        }
    }
}
