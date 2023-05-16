using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyLamNghiep.Data;
using QuanLyLamNghiep.Models;

namespace QuanLyLamNghiep.Controllers
{
    public class ChuongMucsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChuongMucsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChuongMucs
        public async Task<IActionResult> Index()
        {
              return _context.ChuongMucs != null ? 
                          View(await _context.ChuongMucs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ChuongMucs'  is null.");
        }

        // GET: ChuongMucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChuongMucs == null)
            {
                return NotFound();
            }

            var chuongMuc = await _context.ChuongMucs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chuongMuc == null)
            {
                return NotFound();
            }

            return View(chuongMuc);
        }

        // GET: ChuongMucs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChuongMucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content")] ChuongMuc chuongMuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuongMuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chuongMuc);
        }

        // GET: ChuongMucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChuongMucs == null)
            {
                return NotFound();
            }

            var chuongMuc = await _context.ChuongMucs.FindAsync(id);
            if (chuongMuc == null)
            {
                return NotFound();
            }
            return View(chuongMuc);
        }

        // POST: ChuongMucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content")] ChuongMuc chuongMuc)
        {
            if (id != chuongMuc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuongMuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuongMucExists(chuongMuc.Id))
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
            return View(chuongMuc);
        }

        // GET: ChuongMucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChuongMucs == null)
            {
                return NotFound();
            }

            var chuongMuc = await _context.ChuongMucs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chuongMuc == null)
            {
                return NotFound();
            }

            return View(chuongMuc);
        }

        // POST: ChuongMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChuongMucs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChuongMucs'  is null.");
            }
            var chuongMuc = await _context.ChuongMucs.FindAsync(id);
            if (chuongMuc != null)
            {
                _context.ChuongMucs.Remove(chuongMuc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuongMucExists(int id)
        {
          return (_context.ChuongMucs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
