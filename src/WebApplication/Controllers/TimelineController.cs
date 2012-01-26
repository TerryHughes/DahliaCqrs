namespace Dahlia.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Common;
    using Framework;

    public class TimelineController : Controller
    {
        readonly ReadRepository repository;

        public TimelineController()
        {
            repository = new ReadRepository(new ConfigConnectionSettings("event"));
        }

        public ActionResult Events()
        {
            var events = repository.All("SELECT [Id], [DateTime] FROM [Events] ORDER BY [DateTime] DESC", Enumerable.Empty<KeyValuePair<string, object>>());

            return View(events);
        }

        public JsonResult EventData()
        {
            var events = repository.All("SELECT [Id], [DateTime] FROM [Events] ORDER BY [DateTime] DESC", Enumerable.Empty<KeyValuePair<string, object>>())
                .Select(e => new { title = e.Id, start = e.DateTime.ToString() });

            return Json(new { events = events }, JsonRequestBehavior.AllowGet);
        }
    }
}
