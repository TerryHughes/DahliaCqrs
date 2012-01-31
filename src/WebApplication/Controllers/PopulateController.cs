namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using MvcContrib;
    using NServiceBus;
    using CurrentScheduleRetreatCommand = Commands.ScheduleRetreatCommand.Version1;
    using CurrentCancelRetreatCommand = Commands.CancelRetreatCommand.Version1;
    using CurrentRegisterParticipantCommand = Commands.RegisterParticipantCommand.Version1;
    using CurrentRenameParticipantCommand = Commands.RenameParticipantCommand.Version1;
    using CurrentUnregisterParticipantCommand = Commands.UnregisterParticipantCommand.Version1;
    using Data.Common;
    using Framework;

    public class PopulateController : Controller
    {
        readonly IBus bus;

        public PopulateController(IBus bus)
        {
            this.bus = bus;
        }

        public ActionResult Clear()
        {
            var repository = new ReadRepository(new ConfigConnectionSettings("data"));

            foreach (var retreat in repository.All("SELECT * FROM [Retreats]", Enumerable.Empty<KeyValuePair<string, object>>()))
                bus.Send(new CurrentCancelRetreatCommand { AggregateRootId = retreat.Id });

            foreach (var participant in repository.All("SELECT * FROM [Participants]", Enumerable.Empty<KeyValuePair<string, object>>()))
                bus.Send(new CurrentUnregisterParticipantCommand { AggregateRootId = participant.Id });

            return this.RedirectToAction<ParticipantController>(c => c.List());
        }

        public ActionResult DoIt()
        {
            Func<DateTime, DateTime> firstOfTheMonth = d => d.AddDays(1 - d.Day);
            Action<DateTime> scheduleRetreat = d => bus.Send(new CurrentScheduleRetreatCommand { Date = d, Description = d.ToString("MMMyyyy") });

            var date = firstOfTheMonth(DateTime.Today);

            foreach (var mnth in Enumerable.Range(-2, 16))
                scheduleRetreat(date.AddMonths(mnth));

            bus.Send(new CurrentRegisterParticipantCommand { Name = "Eddie Adams", Note = "Mostly an average kid, mostly" });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "First Doctor", Note = "Always changing ... keep an eye on him" });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "Ms Yolanda", Note = "yosaffbridge" });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "Jeffrey Drew Wilschke", Note = "weirdo" });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "Bob Loblaw", Note = "Author of \"The Bob Loblaw Law Blog\"" });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "Earl Sinclair", Note = "Somewhat thick-headed and very suggestible" });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "Jack Bauer", Note = "Hates suprises; looking for a relaxing and uneventful time to unwind" });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "Silent Bob", Note = "Doesn't talk much" });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "Kal-El", Note = "Orphan" });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "Humma Kavula", Note = "A semi-insane missionary living amongst the Jatravartid people of Viltvodle VI"/*, and a former space pirate*/ });
            bus.Send(new CurrentRegisterParticipantCommand { Name = "Zezozose Zadfrack Glutz", Note = "Charles Manson's kid" });

            return this.RedirectToAction<ParticipantController>(c => c.List());
        }

        public ActionResult Dirk(Guid id)
        {
//            bus.Send(new updatenote { AggregateRootId = id, Note = "Hanging out with the wrong crowd" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Dirk Diggler" });
//            bus.Send(new updatenote { AggregateRootId = id, Note = "Pornstar" });

            return this.RedirectToAction<ParticipantController>(c => c.List());
        }

        public ActionResult Who(Guid id)
        {
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Second Doctor" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Third Doctor" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Fourth Doctor" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Fifth Doctor" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Sixth Doctor" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Seventh Doctor" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Eighth Doctor" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Ninth Doctor" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Tenth Doctor" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Eleventh Doctor" });

            return this.RedirectToAction<ParticipantController>(c => c.List());
        }

        public ActionResult Yo(Guid id)
        {
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Ms Saffron" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Ms Bridget" });

            return this.RedirectToAction<ParticipantController>(c => c.List());
        }

        public ActionResult Beep(Guid id)
        {
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Beezow Doo-Doo Zopittybop-Bop-Bop" });

            return this.RedirectToAction<ParticipantController>(c => c.List());
        }

        public ActionResult Super(Guid id)
        {
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Clark Kent" });
//            bus.Send(new updatenote { AggregateRootId = id, Note = "Awkward" });
            bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "Superman" });
//            bus.Send(new updatenote { AggregateRootId = id, Note = "Has trouble relating to others" });

            return this.RedirectToAction<ParticipantController>(c => c.List());
        }

        public ActionResult NameChange(Guid id)
        {
            for (var i = 0; i < 1000; i++)
                bus.Send(new CurrentRenameParticipantCommand { AggregateRootId = id, Name = "NameChange" + i });

            return this.RedirectToAction<ParticipantController>(c => c.List());
        }
    }
}
