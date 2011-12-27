namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Dynamic;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using NServiceBus;
    using PreviousCreateRetreatCommand = Commands.CreateRetreatCommand.Version1;
    using CurrentCreateRetreatCommand = Commands.CreateRetreatCommand.Version2;
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

        public ActionResult NewCurrent()
        {
            return View();
        }

        public ActionResult NewPrevious()
        {
            return View();
        }

        public ActionResult CreateCurrent(DateTime date, string description)
        {
            var command = new CurrentCreateRetreatCommand(date, description);
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("List");
        }

        public ActionResult CreatePrevious(DateTime date, string description)
        {
            var command = new PreviousCreateRetreatCommand(date, description);
            HomeController.Cache.Add(command.Id);
            bus.Send(command);

            return RedirectToAction("List");
        }
    }
}
