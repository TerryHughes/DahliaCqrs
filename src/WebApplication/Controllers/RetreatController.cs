namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Dynamic;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using NServiceBus;
    using CreateRetreatCommand = Commands.CreateRetreatCommand.Version1;
    using Repositories;

    public class RetreatController : Controller
    {
        private readonly RetreatRepository repository;
        private readonly IBus bus;

        public RetreatController(RetreatRepository repository, IBus bus)
        {
            this.repository = repository;
            this.bus = bus;
        }

        public ActionResult List()
        {
            var retreats = repository.GetAllAsDynamic().OrderBy(r => r.Date);

            return View(retreats);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(DateTime date, string description)
        {
            var command = new CreateRetreatCommand(date, description);
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("List");
        }
    }
}
