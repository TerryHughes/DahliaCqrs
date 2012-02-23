namespace Dahlia.RelationalStore
{
    using NServiceBus;
    using Dahlia.Data.Common;
    using Dahlia.Framework;

    public class Register : IWantCustomInitialization
    {
        public void Init()
        {
            Configure.Instance.Configurer.RegisterSingleton(typeof(WriteRepository), new WriteRepository(new ConfigConnectionSettings("rel")));
        }
    }
}
