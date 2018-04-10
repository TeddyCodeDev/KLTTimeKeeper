using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KLTTimekeeper.Data;
using KLTTimekeeper.Models;

namespace KLTTimekeeper.Controllers
{
    public class TimeCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeCard.ToListAsync());
        }

        // GET: TimeCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeCard = await _context.TimeCard
                .SingleOrDefaultAsync(m => m.TimeCardID == id);
            if (timeCard == null)
            {
                return NotFound();
            }

            return View(timeCard);
        }

        // GET: TimeCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeCardID,UserID,GroupID,ClockIn,ClockOut")] TimeCard timeCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeCard);
        }

        // GET: TimeCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeCard = await _context.TimeCard.SingleOrDefaultAsync(m => m.TimeCardID == id);
            if (timeCard == null)
            {
                return NotFound();
            }
            return View(timeCard);
        }

        // POST: TimeCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeCardID,UserID,GroupID,ClockIn,ClockOut")] TimeCard timeCard)
        {
            if (id != timeCard.TimeCardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeCardExists(timeCard.TimeCardID))
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
            return View(timeCard);
        }

        // GET: TimeCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeCard = await _context.TimeCard
                .SingleOrDefaultAsync(m => m.TimeCardID == id);
            if (timeCard == null)
            {
                return NotFound();
            }

            return View(timeCard);
        }

        // POST: TimeCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeCard = await _context.TimeCard.SingleOrDefaultAsync(m => m.TimeCardID == id);
            _context.TimeCard.Remove(timeCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeCardExists(int id)
        {
            return _context.TimeCard.Any(e => e.TimeCardID == id);
        }
    }
}
