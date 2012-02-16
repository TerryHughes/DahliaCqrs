namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using NServiceBus;
    using CurrentRegisterCommand = Commands.RegisterParticipantCommand.Version2;
    using CurrentRenameParticipantCommand = Commands.RenameParticipantCommand.Version1;
    using CurrentUnregisterCommand = Commands.UnregisterParticipantCommand.Version1;
    using CurrentSnapshotCommand = Commands.SnapshotParticipantCommand.Version1;
    using Data.Common;
    using Framework;

    public class ParticipantController : Controller
    {
        readonly ReadRepository repository;
        readonly IBus bus;

        public ParticipantController(IBus bus)
        {
            repository = new ReadRepository(new ConfigConnectionSettings("data"));
            this.bus = bus;
        }

        public ActionResult List()
        {
            var participants = repository.All("SELECT * FROM [Participants] ORDER BY [Name]", Enumerable.Empty<KeyValuePair<string, object>>());

            return View(participants);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Register(string name, string note)
        {
            var command = new CurrentRegisterCommand { Name = name, Note = note, DateRecieved = DateTime.Now };
            bus.Send(command);

            return RedirectToAction("List");
        }

        public ActionResult Ren(Guid id)
        {
            return View();
        }

        public ActionResult Rename(Guid id, string name)
        {
            var command = new CurrentRenameParticipantCommand { AggregateRootId = id, Name = name };
            bus.Send(command);

            return RedirectToAction("List");
        }

        public ActionResult Unregister(Guid id)
        {
            var command = new CurrentUnregisterCommand { AggregateRootId = id };
            bus.Send(command);

            return RedirectToAction("List");
        }

        public ActionResult Snapshot(Guid id)
        {
            var command = new CurrentSnapshotCommand { AggregateRootId = id };
            bus.Send(command);

            return RedirectToAction("List");
        }
    }
}
