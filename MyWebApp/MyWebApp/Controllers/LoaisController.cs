using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Entities;
using System.IO;

namespace MyWebApp.Controllers
{
    public class LoaisController : Controller
    {
        private readonly eStore20Context _context;

        public LoaisController(eStore20Context context)
        {
            _context = context;
        }

        // GET: Loais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loai.ToListAsync());
        }

        // GET: Loais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loai
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }

            return View(loai);
        }

        // GET: Loais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai,MoTa")] Loai loai, IFormFile MyFile)
        {
            if (ModelState.IsValid)
            {
                if (MyFile != null)
                {
                    //upload file
                    var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Loai", MyFile.FileName);
                    using (var file = new FileStream(pathFile, FileMode.CreateNew))
                    {
                        MyFile.CopyTo(file);
                    }
                    //update trường Hinh
                    loai.Hinh = MyFile.FileName;
                }
                _context.Add(loai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loai);
        }

        // GET: Loais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loai.FindAsync(id);
            if (loai == null)
            {
                return NotFound();
            }
            return View(loai);
        }

        // POST: Loais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoai,TenLoai,MoTa,Hinh")] Loai loai, IFormFile MyFile)
        {
            if (id != loai.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (MyFile != null)
                    {
                        //upload file
                        var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Loai", MyFile.FileName);
                        using (var file = new FileStream(pathFile, FileMode.CreateNew))
                        {
                            MyFile.CopyTo(file);
                        }
                        //update trường Hinh
                        loai.Hinh = MyFile.FileName;
                    }
                    _context.Update(loai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiExists(loai.MaLoai))
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
            return View(loai);
        }

        // GET: Loais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loai
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }

            return View(loai);
        }

        // POST: Loais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loai = await _context.Loai.FindAsync(id);
            _context.Loai.Remove(loai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiExists(int id)
        {
            return _context.Loai.Any(e => e.MaLoai == id);
        }
    }
}
