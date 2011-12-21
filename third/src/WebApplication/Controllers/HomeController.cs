namespace Dahlia.WebApplication.Controllers
{
    using System.Web.Mvc;
    using MvcContrib;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction<RetreatController>(c => c.Current());
        }
    }
}
