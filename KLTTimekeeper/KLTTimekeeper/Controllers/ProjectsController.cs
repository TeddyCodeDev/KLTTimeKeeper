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

        //home/Projects
        public ActionResult Index()
        {

            //if 
            return View("Index");
        }
    }
    
}
