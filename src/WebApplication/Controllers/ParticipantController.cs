namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using NServiceBus;
    using CurrentAddParticipantCommand = Commands.AddParticipantCommand.Version1;
    using CurrentRenameParticipantCommand = Commands.RenameParticipantCommand.Version1;
    using CurrentRemoveParticipantCommand = Commands.RemoveParticipantCommand.Version1;
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

        public ActionResult Add(string name, string note)
        {
            var command = new CurrentAddParticipantCommand { Name = name, Note = note };
            HomeController.Cache.Add(command.Id);
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
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("List");
        }

        public ActionResult Remove(Guid id)
        {
            var command = new CurrentRemoveParticipantCommand { AggregateRootId = id };
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("List");
        }
    }
}
