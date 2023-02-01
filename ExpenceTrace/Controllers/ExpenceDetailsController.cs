using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenceTrace.Data;
using Expence_Treace.Models;

namespace ExpenceTrace.Controllers
{
    public class ExpenceDetailsController : Controller
    {
        private readonly ExpenceTraceContext _context;

        public ExpenceDetailsController(ExpenceTraceContext context)
        {
            _context = context;
        }

        // GET: ExpenceDetails
        public async Task<IActionResult> Index()
        {
            var expenceTraceContext = _context.ExpenceDetails.Include(e => e.CategoryName).Include(e => e.UserName);
            return View(await expenceTraceContext.ToListAsync());
        }

        // GET: ExpenceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExpenceDetails == null)
            {
                return NotFound();
            }

            var expenceDetails = await _context.ExpenceDetails
                .Include(e => e.CategoryName)
                .Include(e => e.UserName)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenceDetails == null)
            {
                return NotFound();
            }

            return View(expenceDetails);
        }

        // GET: ExpenceDetails/Create
        public IActionResult Create()
        {
            ViewData["CategoriesId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["UsersId"] = new SelectList(_context.User, "Id", "Name");
            return View();
        }

        // POST: ExpenceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoriesId,Cost,Description,ExpencDate,UsersId")] ExpenceDetails expenceDetails)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(expenceDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriesId"] = new SelectList(_context.Category, "Id", "Name", expenceDetails.CategoriesId);
            ViewData["UsersId"] = new SelectList(_context.User, "Id", "Name", expenceDetails.UsersId);
            return View(expenceDetails);
        }

        // GET: ExpenceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExpenceDetails == null)
            {
                return NotFound();
            }

            var expenceDetails = await _context.ExpenceDetails.FindAsync(id);
            if (expenceDetails == null)
            {
                return NotFound();
            }
            ViewData["CategoriesId"] = new SelectList(_context.Category, "Id", "Name", expenceDetails.CategoriesId);
            ViewData["UsersId"] = new SelectList(_context.User, "Id", "Name", expenceDetails.UsersId);
            return View(expenceDetails);
        }

        // POST: ExpenceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoriesId,Cost,Description,ExpencDate,UsersId")] ExpenceDetails expenceDetails)
        {
            if (id != expenceDetails.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenceDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenceDetailsExists(expenceDetails.Id))
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
            ViewData["CategoriesId"] = new SelectList(_context.Category, "Id", "Name", expenceDetails.CategoriesId);
            ViewData["UsersId"] = new SelectList(_context.User, "Id", "Name", expenceDetails.UsersId);
            return View(expenceDetails);
        }

        // GET: ExpenceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExpenceDetails == null)
            {
                return NotFound();
            }

            var expenceDetails = await _context.ExpenceDetails
                .Include(e => e.CategoryName)
                .Include(e => e.UserName)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenceDetails == null)
            {
                return NotFound();
            }

            return View(expenceDetails);
        }

        // POST: ExpenceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExpenceDetails == null)
            {
                return Problem("Entity set 'ExpenceTraceContext.ExpenceDetails'  is null.");
            }
            var expenceDetails = await _context.ExpenceDetails.FindAsync(id);
            if (expenceDetails != null)
            {
                _context.ExpenceDetails.Remove(expenceDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenceDetailsExists(int id)
        {
          return _context.ExpenceDetails.Any(e => e.Id == id);
        }
    }
}
