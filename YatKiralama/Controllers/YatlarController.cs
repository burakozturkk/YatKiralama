using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using YatKiralama.Data;
using YatKiralama.Models;

namespace YatKiralama.Controllers
{
    public class YatlarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public YatlarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Yatlar;
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Detay(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var yat = await _context.Yatlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yat == null)
            {
                return NotFound();
            }

            return View(yat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Kirala([Bind("ID,YatID,Tarih,SaatID,UserID")] Kirala kirala)
        {
            if (ModelState.IsValid)
            {
                var kirala2 = _context.Kirala.ToList();

                for (int i = 0; i < kirala2.Count; i++)
                {
                    if (kirala2[i].Tarih == kirala.Tarih && kirala2[i].SaatID == kirala.SaatID && kirala2[i].YatID == kirala.YatID)
                    {
                       return PartialView("_ErrorKiralandiPartial", kirala);
                    }
                }

                _context.Add(kirala);
                await _context.SaveChangesAsync();
                return PartialView("_KiralandiPartial" , kirala);
            }
            return PartialView("_ErrorKiralandiPartial", kirala);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumYap([Bind("ID,Detail,Name,CreatedDate,YatId,UserID")] Comment yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                await _context.SaveChangesAsync();

                return RedirectToAction("Detay", new { id = yorum.YatId });


            }

            return RedirectToAction("Detay", new { id = yorum.YatId });
        }
    }
}