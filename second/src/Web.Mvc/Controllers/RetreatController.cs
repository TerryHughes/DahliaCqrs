namespace Dahlia.Web.Mvc
{
    using System;
    using System.Dynamic;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using NServiceBus;
    using PreviousCreateRetreatCommand = Dahlia.Commands.CreateRetreatCommand.Version1;
    using CurrentCreateRetreatCommand = Dahlia.Commands.CreateRetreatCommand.Version2;
    using Dahlia.Repositories;

    public class RetreatController : Controller
    {
        private readonly RetreatRepository repository;
        private readonly IBus b;

        public RetreatController(RetreatRepository repository, IBus b)
        {
            this.repository = repository;
            this.b = b;
        }

        public IBus Bus { get; set; }

        public ActionResult List()
        {
            var retreats = repository.GetAll().OrderBy(r => r.Date);

            return View(retreats);
        }

        public ActionResult Dynamic()
        {
            return View(repository.GetAllAsDynamic().OrderBy(r => r.Date));
        }

        public ActionResult DynamicFromStatic()
        {
            var vms = repository.GetAll().OrderBy(r => r.Date);
           
            var objs = vms.Select(x => {
                                dynamic o = new ExpandoObject();
                                var properties = x.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                                foreach (var p in properties)
                                {
                                    (o as IDictionary<string,object>)[p.Name] = p.GetValue(x, null);
                                }
                                return o;
                            });
            
            return View(objs);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult New2()
        {
            return View();
        }

        public ActionResult Create(DateTime date, string description)
        {
            var command = new PreviousCreateRetreatCommand(date, description);
            HomeController.Cache.Add(command.Id);
            b.Send(command);

            return RedirectToAction("List");
        }

        public ActionResult Create2(DateTime date, string description)
        {
            var command = new CurrentCreateRetreatCommand(date, description);
            HomeController.Cache.Add(command.Id);
            b.Send(command);

            return RedirectToAction("List");
        }

        public ActionResult StepInTime()
        {
            var poppins = new DateTime(1964, 08, 29);

            for (var i = 0; i < 5; i++)
            {
                var command = new PreviousCreateRetreatCommand(poppins.AddDays(i), "kick your knees up " + i);
                HomeController.Cache.Add(command.Id);
                b.Send(command);
            }

            return RedirectToAction("List");
        }

        public ActionResult Msg()
        {
            var str = Bus == null ? "is null" : "has value";
            var date = DateTime.Now.AddDays(5);
            var command = new PreviousCreateRetreatCommand(date.Date, date.TimeOfDay + " from the future web: " + str);
            HomeController.Cache.Add(command.Id);
            b.Send(command);
System.Threading.Thread.Sleep(100);
            return RedirectToAction("List");
        }
    }
}
