namespace Dahlia.CommandProcessor
{
    using NServiceBus;
    using NServiceBus.Unicast;

    public class UnicastBusConfigurationOverride : IWantCustomInitialization
    {
        public void Init()
        {
            Configure.Instance.Configurer.ConfigureProperty<UnicastBus>(ub => ub.ImpersonateSender, false);
        }
    }
}
