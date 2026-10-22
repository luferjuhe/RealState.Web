using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealState.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
