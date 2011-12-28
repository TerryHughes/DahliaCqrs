namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using NServiceBus;
    using CreateRetreatCommand = Commands.CreateRetreatCommand.Version1;
    using Data.Common;
    using Framework;

    public class RetreatController : Controller
    {
        readonly ReadRepository repository;
        readonly IBus bus;

        public RetreatController(IBus bus)
        {
            repository = new ReadRepository(new ConfigConnectionSettings("data"));
            this.bus = bus;
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

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(DateTime date, string description)
        {
            var command = new CreateRetreatCommand { Date = date, Description = description };
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("Current");
        }
    }
}
