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
    public class DieuKhoansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DieuKhoansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DieuKhoans
        public async Task<IActionResult> Index()
        {
            var dieuKhoans = await _context.DieuKhoans.ToListAsync();
            var listDto = new List<DieuKhoanDto>();
            foreach (var dieuKhoan in dieuKhoans)
            {
                listDto.Add(ConvertToDieuKhoanDto(dieuKhoan));
            }

            return View(listDto);
        }
        // GET: DieuKhoans by ChuongId
        public async Task<IActionResult> ListByChuongId(int? id)
        {
            var listDto = new List<DieuKhoanDto>();
            if (id != null)
            {
                var dieuKhoans = await _context.DieuKhoans.Where(x => x.ChuongMucId == id).ToListAsync();
                foreach (var dieuKhoan in dieuKhoans)
                {
                    listDto.Add(ConvertToDieuKhoanDto(dieuKhoan));
                }
            }

            return View(listDto);
        }

        // GET: DieuKhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DieuKhoans == null)
            {
                return NotFound();
            }

            var dieuKhoan = await _context.DieuKhoans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dieuKhoan == null)
            {
                return NotFound();
            }

            return View(ConvertToDieuKhoanDto(dieuKhoan));
        }

        // GET: DieuKhoans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DieuKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DieuKhoanDto dieuKhoanDto)
        {
            try
            {
                var dieuKhoan = ConvertToDieuKhoan(dieuKhoanDto);
                _context.Add(dieuKhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw;
            }


            return RedirectToAction(nameof(Index));
        }

        // GET: DieuKhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DieuKhoans == null)
            {
                return NotFound();
            }

            var dieuKhoan = await _context.DieuKhoans.FindAsync(id);
            if (dieuKhoan == null)
            {
                return NotFound();
            }

            var dieuKhoanDto = ConvertToDieuKhoanDto(dieuKhoan);
            return View(dieuKhoanDto);
        }

        // POST: DieuKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DieuKhoanDto dieuKhoanDto)
        {
            if (id != dieuKhoanDto.Id)
            {
                return NotFound();
            }
            try
            {
                var dieuKhoan = ConvertToDieuKhoan(dieuKhoanDto);
                _context.Update(dieuKhoan);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DieuKhoanExists(id))
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

        // GET: DieuKhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DieuKhoans == null)
            {
                return NotFound();
            }

            var dieuKhoan = await _context.DieuKhoans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dieuKhoan == null)
            {
                return NotFound();
            }

            return View(dieuKhoan);
        }

        // POST: DieuKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DieuKhoans == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DieuKhoans'  is null.");
            }
            var dieuKhoan = await _context.DieuKhoans.FindAsync(id);
            if (dieuKhoan != null)
            {
                _context.DieuKhoans.Remove(dieuKhoan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DieuKhoanExists(int id)
        {
            return (_context.DieuKhoans?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private DieuKhoanDto ConvertToDieuKhoanDto(DieuKhoan dieuKhoan)
        {
            return new DieuKhoanDto
            {
                Id = dieuKhoan.Id,
                Content = dieuKhoan.Content,
                Khungphat = dieuKhoan.Khungphat,
                Mucphat = dieuKhoan.Mucphat,
                ChuongMucId = dieuKhoan.ChuongMucId,
                ChuongMucContent = dieuKhoan.ChuongMuc?.Content
            };
        }

        private DieuKhoan ConvertToDieuKhoan(DieuKhoanDto dieuKhoanDto)
        {
            return new DieuKhoan
            {
                Id = dieuKhoanDto.Id ?? 0,
                Content = dieuKhoanDto.Content,
                Khungphat = dieuKhoanDto.Khungphat,
                Mucphat = dieuKhoanDto.Mucphat,
                ChuongMucId = dieuKhoanDto.ChuongMucId
            };
        }

    }
}
