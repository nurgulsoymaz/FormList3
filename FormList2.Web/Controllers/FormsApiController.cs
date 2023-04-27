using Microsoft.AspNetCore.Mvc;

namespace FormList2.Web.Controllers
{
    public class FormsApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
