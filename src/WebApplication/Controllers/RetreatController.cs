namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using NServiceBus;
    using CurrentScheduleRetreatCommand = Commands.ScheduleRetreatCommand.Version1;
    using CurrentAddParticipantCommand = Commands.AddParticipantToRetreatCommand.Version1;
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

        public ActionResult Current(Guid selected)
        {
            var today = DateTime.Today;

            // show one year (365 days) worth [back 30 days, forward the rest]
            var start = new KeyValuePair<string, object>("@start", today.AddDays(-30));
            var end = new KeyValuePair<string, object>("@end", today.AddDays(335));

            var retreats = repository.All("SELECT * FROM [Retreats] WHERE @start < [Date] AND [Date] < @end ORDER BY [Date], [Description]", new[] { start, end });

            foreach (var retreat in retreats)
            {
                retreat.IsSelected = false;

                if (retreat.Id == selected)
                    retreat.IsSelected = true;
            }

            return View(retreats);
        }

        public ActionResult GoTo(Guid? id)
        {
            if (id.HasValue)
            {
                var idpair = new KeyValuePair<string, object>("@id", id);

                var retreat = repository.One("SELECT * FROM [Retreats] WHERE [Id] = @id", new[] { idpair });

                var participants = repository.All("SELECT * FROM [ParticipantsAssignedToRetreat] WHERE [RetreatId] = @id", new[] { idpair });

                retreat.Participants = participants;

                return View(retreat);
            }

            var today = DateTime.Today;

            var date = new KeyValuePair<string, object>("@date", today);

            var retreat2 = repository.All("SELECT * FROM [Retreats] WHERE @date <= [Date] ORDER BY [Date], [Description]", new[] { date }).First();

            return View(retreat2);
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

            return RedirectToAction("GoTo");
        }

        public ActionResult AddPartic(Guid id)
        {
            return View();
        }

        public ActionResult AddParticipantTo(Guid id, Guid participantId)
        {
            var command = new CurrentAddParticipantCommand { AggregateRootId = id, ParticipantId = participantId };
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("GoTo");
        }
    }
}
