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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //if user is admin/instructor
        //then allow them to create, edit, or delete items for courses they can view

        //viewable by everyone
        //home/Projects
        public ActionResult Index()
        {
            //create list for projects and pass to view
            return View("Index");
        }
    }
    
}
