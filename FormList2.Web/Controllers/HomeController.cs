using FormList2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormList2.Web.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly FormRepository _formRepository;
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private AppDbContext? context;

        public HomeController(ILogger<HomeController> logger)
        {
            _formRepository = new FormRepository();
            _context = context;
            _logger = logger;
        }

       //[Authorize]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}