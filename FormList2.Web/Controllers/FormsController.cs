using System.Linq;
using FormList2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormList2.Web.Controllers
{
    public class FormsController : Controller
    {
        private readonly AppDbContext _context;

        public FormsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int Id)
        {
            var forms = _context.Forms.Include(f => f.Field).Where(f => f.Id == Id).ToList();

            return View(forms);
        }

        //update işlemini ürün id sine göre yaptık ve bütün FORMLARI view katmanına çektik
        [HttpGet]
        public IActionResult Update(int id)
        {
            var form = _context.Forms.Include(f => f.Field).FirstOrDefault(f => f.Id == id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        [HttpPost]
        public IActionResult Update(Form form)
        {
            if (ModelState.IsValid)
            {
                var formToUpdate = _context.Forms.FirstOrDefault(f => f.Id == form.Id);
                if (formToUpdate == null)
                {
                    return NotFound();
                }
                formToUpdate.FormName = form.FormName;
                formToUpdate.Description = form.Description;
                formToUpdate.CreatedAt = form.CreatedAt;
                formToUpdate.CreatedBy = form.CreatedBy;
                formToUpdate.Field.Name = form.Field.Name;
                formToUpdate.Field.SurName = form.Field.SurName;
                formToUpdate.Field.Age = form.Field.Age;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

    }
}
