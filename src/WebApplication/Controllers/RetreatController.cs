namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using NServiceBus;
    using CurrentScheduleRetreatCommand = Commands.ScheduleRetreatCommand.Version1;
    using CurrentRescheduleRetreatCommand = Commands.RescheduleRetreatCommand.Version1;
    using CurrentRenameRetreatCommand = Commands.RenameRetreatCommand.Version1;
    using CurrentCancelRetreatCommand = Commands.CancelRetreatCommand.Version1;
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

            var retreats = repository.All("SELECT * FROM [Retreats] WHERE @start < [Date] AND [Date] < @end ORDER BY [Date], [Description]", new[] { start, end });

            return View(retreats);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Schedule(DateTime date, string description)
        {
            var command = new CurrentScheduleRetreatCommand { Date = date, Description = description };
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("Current");
        }

        public ActionResult Res(Guid id)
        {
            return View();
        }

        public ActionResult Reschedule(Guid id, DateTime date)
        {
            var command = new CurrentRescheduleRetreatCommand { AggregateRootId = id, Date = date };
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("Current");
        }

        public ActionResult Ren(Guid id)
        {
            return View();
        }

        public ActionResult Rename(Guid id, string description)
        {
            var command = new CurrentRenameRetreatCommand { AggregateRootId = id, Description = description };
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("Current");
        }

        public ActionResult Cancel(Guid id)
        {
            var command = new CurrentCancelRetreatCommand { AggregateRootId = id };
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("Current");
        }
    }
}
