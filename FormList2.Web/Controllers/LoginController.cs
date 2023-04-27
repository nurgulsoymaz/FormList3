using FormList2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Build.Framework;

namespace FormList2.Web.Controllers
{
   
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {

            _context = context;
        }

       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            if (string.IsNullOrEmpty(p.UserName) || string.IsNullOrEmpty(p.Password))
            {
                // username veya password boşsa, home/index sayfasına yönlendir
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // veritabanından ilgili kullanıcıyı bul
                var datavalue = _context.Admins.FirstOrDefault(x => x.UserName == p.UserName);

                if (datavalue != null && datavalue.Password == p.Password)
                {
                    // doğru kullanıcı adı ve şifre ile /form/index sayfasına yönlendir
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,p.UserName)
            };
                    var useridentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Form");
                }
                else
                {
                    // yanlış kullanıcı adı veya şifre, hata mesajı göster
                    TempData["ErrorMessage"] = "Invalid credentials.";
                    return RedirectToAction("Index", "Login");
                }
            }
        }



        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Index(Admin p)
        //{
        //    var datavalue = _context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
        //    if (datavalue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,p.UserName)
        //        };
        //        var useridentity = new ClaimsIdentity(claims, "Login");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "Form");
        //    }
        //    return View();
        //}
    }
}
