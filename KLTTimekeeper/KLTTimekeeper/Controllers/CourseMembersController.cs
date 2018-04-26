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
    public class CourseMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseMember.ToListAsync());
        }

        public IEnumerable<CourseMember> getCoursesForMember(ApplicationUser user)
        {
            var coursesForMember = _context.CourseMember.Where(predicate: cM => cM.UserID.ToString() == user.Id).ToList().AsEnumerable();

            return coursesForMember;
        }

        // GET: CourseMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseMember = await _context.CourseMember
                .SingleOrDefaultAsync(m => m.CourseMemberID == id);
            if (courseMember == null)
            {
                return NotFound();
            }

            return View(courseMember);
        }

        // GET: CourseMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseMemberID,UserID,CourseID")] CourseMember courseMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseMember);
        }

        // GET: CourseMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseMember = await _context.CourseMember.SingleOrDefaultAsync(m => m.CourseMemberID == id);
            if (courseMember == null)
            {
                return NotFound();
            }
            return View(courseMember);
        }

        // POST: CourseMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseMemberID,UserID,CourseID")] CourseMember courseMember)
        {
            if (id != courseMember.CourseMemberID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseMemberExists(courseMember.CourseMemberID))
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
            return View(courseMember);
        }

        // GET: CourseMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseMember = await _context.CourseMember
                .SingleOrDefaultAsync(m => m.CourseMemberID == id);
            if (courseMember == null)
            {
                return NotFound();
            }

            return View(courseMember);
        }

        // POST: CourseMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseMember = await _context.CourseMember.SingleOrDefaultAsync(m => m.CourseMemberID == id);
            _context.CourseMember.Remove(courseMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseMemberExists(int id)
        {
            return _context.CourseMember.Any(e => e.CourseMemberID == id);
        }
    }
}
