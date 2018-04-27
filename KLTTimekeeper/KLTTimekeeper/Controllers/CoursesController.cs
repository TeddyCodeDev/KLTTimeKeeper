using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KLTTimekeeper.Data;
using KLTTimekeeper.Models;
using Microsoft.AspNetCore.Identity;

namespace KLTTimekeeper.Controllers
{
    public class CoursesController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            //ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            //if (user.isAdmin)
            //{
                return View(await _context.Course.ToListAsync());

            //}

            //List<Course> courses = new List<Course>();
            //CourseMembersController membersController = new CourseMembersController(_context);
            //foreach (CourseMember cM in membersController.getCoursesForMember(user).ToList())
            //{
            //    courses.Add(await _context.Course.SingleOrDefaultAsync(m => m.CourseID == cM.CourseID));
            //}

            //return View(courses);
        }


        // GET: Courses/Registration
        public async Task<IActionResult> Register()
        {
            return View(await _context.Course.ToListAsync());
        }

        /// <summary>
        /// Register for course
        /// </summary>
        /// <param name="cM"></param>
        /// <returns></returns>
        public async Task<IActionResult> RegisterForCourse()
        {
            //int userID = Int32.Parse(Request.Query["userID"]);
            //int courseID = Int32.Parse(Request.Query["CourseID"]);
            //CourseMember cM = new CourseMember { UserID = userID, CourseID = courseID };

            if (ModelState.IsValid)
            {
                //_context.Add(cM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return View(cM);
            return RedirectToAction(nameof(Index));
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .SingleOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,InstructorID,CourseName")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.SingleOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,InstructorID,CourseName")] Course course)
        {
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseID))
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
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .SingleOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.SingleOrDefaultAsync(m => m.CourseID == id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseID == id);
        }
    }
}
