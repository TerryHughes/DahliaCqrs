namespace Dahlia.Web.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using NServiceBus.ObjectBuilder;

    public class NServiceBusDependencyResolver : IDependencyResolver
    {
        readonly IBuilder builder;

        public NServiceBusDependencyResolver(IBuilder builder)
        {
            this.builder = builder;
        }

        public object GetService(Type serviceType)
        {
            return builder.Build(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return builder.BuildAll(serviceType);
        }
    }
}
