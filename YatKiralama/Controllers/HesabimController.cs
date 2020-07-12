using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YatKiralama.Data;
using YatKiralama.Models;

namespace YatKiralama.Controllers
{
    public class HesabimController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HesabimController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(User u)
        {
            User login = null;
            try
            {
                login = _context.Users.Where(x => x.Mail == u.Mail && x.Sifre == u.Sifre).SingleOrDefault() ;
            }
            catch (Exception)
            {
            }

            if (login !=null && login.admin == false)
            {
                HttpContext.Session.SetString("ID", login.Id.ToString());
                HttpContext.Session.SetString("Mail" ,login.Mail);
                return RedirectToAction("Index","Home");
            }
            if (login != null && login.admin == true)
            {
                HttpContext.Session.SetString("ID", login.Id.ToString());
                HttpContext.Session.SetString("Mail", login.Mail);
                HttpContext.Session.SetString("admin", "admin");
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.error = "Hatalı Şifre veya E-posta";
            return View();
        }
        public IActionResult Cikis()
        {
            HttpContext.Session.Remove("Mail");
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("admin");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kayit([Bind("Id,Name,Surname,Mail,Sifre,admin")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Giris");

            }
            ViewBag.error = "Kayıt Olunamadı.";
            return View();
        }










        //public IActionResult Giris()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Giris(User loginModel)
        //{
        //    if (LoginUser(loginModel))
        //    {
        //        var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, loginModel.Mail)
        //    };

        //        var userIdentity = new ClaimsIdentity(claims, "login");

        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(principal);

        //        //Just redirect to our index after logging in. 
        //        return RedirectToAction("Index", "Home");
        //    }
        //    ViewBag.error = "Hatalı Şifre veya E-posta";
        //    return View();
        //}

        //public async Task<IActionResult> LogOut()
        //{
        //    await HttpContext.SignOutAsync();

        //    return RedirectToAction("Index");
        //}

        //private bool LoginUser(User user)
        //{
        //    var login = _context.Users.FirstOrDefault(a => a.Mail == user.Mail && a.Sifre == user.Sifre);
        //    if (login != null)
        //    {
        //        return true;
        //    }

        //    else
        //    {
        //        return false;
        //    }

        //}
    }
}