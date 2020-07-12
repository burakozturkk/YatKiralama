using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YatKiralama.Data;
using YatKiralama.Models;

namespace YatKiralama.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("admin") == "admin")
            {
                return View(await _context.Yatlar.ToListAsync());
            }
            return RedirectToAction("Index", "Home");

        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("admin") == "admin")
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
            return RedirectToAction("Index", "Home");
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("admin") == "admin")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Length,Capacity,Details,ImgLocation,ImgLocation2,ImgLocation3")] Yat yat)
        {
            if (HttpContext.Session.GetString("admin") == "admin")
            {
                if (ModelState.IsValid)
                {
                    _context.Add(yat);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(yat);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("admin") == "admin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var yat = await _context.Yatlar.FindAsync(id);
                if (yat == null)
                {
                    return NotFound();
                }
                return View(yat);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Length,Capacity,Details,ImgLocation,ImgLocation2,ImgLocation3")] Yat yat)
        {
            if (HttpContext.Session.GetString("admin") == "admin")
            {
                if (id != yat.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(yat);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!YatExists(yat.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(yat);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("admin") == "admin")
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
            return RedirectToAction("Index", "Home");
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("admin") == "admin")
            {
                var yat = await _context.Yatlar.FindAsync(id);
                _context.Yatlar.Remove(yat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Home");
        }

        private bool YatExists(int id)
        {
           
            return _context.Yatlar.Any(e => e.Id == id);

        }
    }
}
