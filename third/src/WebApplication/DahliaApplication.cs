namespace Dahlia.WebApplication
{
    using Dahlia.Web;
    using NServiceBus;

    public class DahliaApplication : MvcApplication
    {
        protected override void AppStart()
        {
            Configure
                .WithWeb()
                .DefaultBuilder()
                .ForMvc()
                .Log4Net()
                .XmlSerializer()
                .MsmqTransport()
                    .IsTransactional(false)
                    .PurgeOnStartup(false)
                .UnicastBus()
                    .ImpersonateSender(false)
                .CreateBus()
                .Start();
        }
    }
}
