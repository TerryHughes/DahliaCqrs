/*
namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using NServiceBus;
    using CurrentCreateRetreatCommand = Commands.CreateRetreatCommand.Version1;
    using Data.Common;
    using Framework;

    public class RetreatController_Clean : Controller
    {
        readonly ReadRepository repository;
        readonly IBus bus;

        public RetreatController_Clean(IBus bus)
        {
            repository = new ReadRepository(new ConfigConnectionSettings("data"));
            this.bus = bus;
        }

        public IBus Bus { get; set; }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(DateTime date, string description)
        {
            bus.Send(new CurrentCreateRetreatCommand { Date = date, Description = description });

            return RedirectToAction("Current");
        }

        public ActionResult Current()
        {
            var today = DateTime.Today;

            // show one year (365 days) worth [back 30 days, forward the rest]
            var start = new KeyValuePair<string, object>("@start", today.AddDays(-30));
            var end = new KeyValuePair<string, object>("@end", today.AddDays(335));

            var retreats = repository.All("SELECT * FROM [Retreats] WHERE @start < [Date] AND [Date] < @end ORDER BY [Date]", new[] { start, end });

            return View(retreats);
        }

        public ActionResult Msg()
        {
            var str = Bus == null ? "is null" : "has value";
            bus.Send(new CurrentCreateRetreatCommand { Date = DateTime.Today, Description = DateTime.Now.TimeOfDay + " from the web " + str });
System.Threading.Thread.Sleep(100);
            return RedirectToAction("Current");
        }
    }
}
*/
