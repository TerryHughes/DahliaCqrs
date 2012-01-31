namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Linq;
    using System.Web.Mvc;
    using MvcContrib;
    using Data.Common;
    using Framework;

    public class HomeController : Controller
    {
        public static readonly List<Guid> Cache = new List<Guid>();
        static DateTime last = (DateTime)SqlDateTime.MinValue;
        readonly ReadRepository repository;

        public HomeController()
        {
            repository = new ReadRepository(new ConfigConnectionSettings("data"));
        }

        public ActionResult Index()
        {
            return this.RedirectToAction<RetreatController>(c => c.Index());
        }

        public ActionResult Pending()
        {
            var date = new KeyValuePair<string, object>("@date", last);

            last = DateTime.Now;

            repository.All("SELECT [Id] FROM [ProcessedCommands] WHERE [Date] > @date", new[] { date }).ToList().ForEach(id => Cache.Remove(id.Id));

            return View(Cache);
        }
    }
}
