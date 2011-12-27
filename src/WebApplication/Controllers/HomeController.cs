namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Linq;
    using System.Web.Mvc;
    using MvcContrib;
    using Repositories;

    public class HomeController : Controller
    {
        public static readonly List<Guid> Cache = new List<Guid>();
        static DateTime last = (DateTime)SqlDateTime.MinValue;
        readonly ProcessCommandRepository repository;

        public HomeController(ProcessCommandRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return this.RedirectToAction<RetreatController>(c => c.List());
        }

        public ActionResult Pending()
        {
            var mark = DateTime.Now;
            repository.CommandsSince(last).ToList().ForEach(id => Cache.Remove(id));
            last = mark;

            return View(Cache);
        }
    }
}
