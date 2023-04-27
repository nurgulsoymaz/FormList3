using System.Linq;
using FormList2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormList2.Web.Controllers
{
    public class SearchResultController : Controller
    {
        private readonly AppDbContext _context;

        public SearchResultController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string formName)
        {
            var forms = _context.Forms.Include(f => f.Field).Where(f => f.FormName == formName).ToList();

            return View(forms);
        }

        [HttpGet]
        public IActionResult Search()
        {
            var forms = _context.Forms.ToList();
            ViewBag.FormId = forms.FirstOrDefault()?.Id;
            return View(forms);
        }

        [HttpPost]
        public ActionResult Search(FormCollection form)
        {
            var formName = form["FormName"];

            var forms = _context.Forms.Include(f => f.Field)
                .Where(f => f.FormName.Contains(formName))
                .ToList();

            ViewBag.FormName = formName;
            return PartialView("_SearchResults", forms);
        }
    }
}
