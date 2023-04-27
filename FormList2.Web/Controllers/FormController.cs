using FormList2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
//using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;

namespace FormList2.Web.Controllers
{
    public class FormController : Controller
    {

        private readonly FormRepository _formRepository;
        private readonly AppDbContext _context;


        public FormController(AppDbContext context)
        {
            _formRepository = new FormRepository();
            _context = context;
        }

        [Authorize]
        //[Authorize] attribute, an authorization filter in ASP.NET Core, is used to restrict access to actions or controllers to only authorized users.
        public IActionResult Index()
        {
            var query = from field in _context.Fields
                        join form in _context.Forms on field.Id equals form.FieldId into formGroup
                        from form in formGroup.DefaultIfEmpty()
                        select new { field, form };

            var result = query.ToList().Select(x => new Field
            {
                Id = x.field.Id,
                Name = x.field.Name,
                SurName = x.field.SurName,
                Age = x.field.Age,
                Forms = new List<Form> { x.form }
            }).ToList();

            var forms = result.SelectMany(f => f.Forms).ToList();

            return View(forms);
        }
        //------------------------------------------------------------
        //show datas
        [HttpGet]
        public IActionResult Create()
        {
            var newForm = new Form();
            return View("FormView", newForm);
        }


        [HttpPost]

        public IActionResult Save(string FormName, string Description, DateTime CreatedAt, string CreatedBy, string Name, string SurName, int Age)
        {
            // Create a new field object
            var field = new Field
            {
                Name = Name,
                SurName = SurName,
                Age = Age
            };

            // Save the field to the database
            _context.Fields.Add(field);
            _context.SaveChanges();


            // Create a new form object
            var form = new Form
            {
                FieldId = field.Id,
                FormName = FormName,
                Description = Description,
                CreatedAt = DateTime.Now,
                CreatedBy = Convert.ToInt32(CreatedBy),

            };

            // Save the form to the database
            _context.Forms.Add(form);
            _context.SaveChanges();

            return Ok();
        }

        


    }

}











//[HttpPost]
//public IActionResult Create(Form form)
//{
//    string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

//    if (ModelState.IsValid)
//    {
//        // Set created by user id here
//        form.CreatedBy = Convert.ToInt32(userId);

//        // Create new Field object
//        Field newField = new Field()
//        {
//            Name = form.Field.Name,
//            SurName = form.Field.SurName,
//            Age = form.Field.Age
//        };

//        // Add new Field object to context
//        _context.Fields.Add(newField);

//        // Create new Form object
//        Form newForm = new Form()
//        {
//            FormName = form.FormName,
//            Description = form.Description,
//            CreatedAt = DateTime.Now,
//            CreatedBy = Convert.ToInt32(userId),
//            FieldId = newField.Id
//        };

//        // Add new Form object to context
//        _context.Forms.Add(newForm);
//        _context.SaveChanges();
//        return RedirectToAction("Index");
//    }
//    else
//    {
//        return View("FormView", form);
//    }
//}