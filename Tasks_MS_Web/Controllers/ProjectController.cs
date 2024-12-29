using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks_MS_Web.Models;

namespace Tasks_MS_Web.Controllers
{
    public class ProjectController : Controller
    {
        TasksMsContext _context = new TasksMsContext();
        //Read
        public IActionResult IndexProject()
        {
            var projects=_context.Projects.ToList();
            return View(projects);
        }
        //Create
        public IActionResult CreateProject()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CreateProject(Projects project)
        {
            if(project==null)
            {
                ModelState.AddModelError("", "Invalid Data");
                return View(project);
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("IndexProject");
        }
        //Update
        public IActionResult EditProject(int? ProjectID)
        {
            if(ProjectID==null)
            {
                return BadRequest();
            }
            Projects project=_context.Projects.FirstOrDefault(p => p.ProjectID == ProjectID);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        [HttpPost]
       public IActionResult EditProject(Projects project)
       {
            if(project==null)
            {
                ModelState.AddModelError("", "Invalid Data");
                    return View(project);
            }
            else
            {
                _context.Projects.Update(project);
                _context.SaveChanges();
                return RedirectToAction("IndexProject");
            }
       }
        //Delete
        public IActionResult DeleteProject(int? ProjectID)
        {
            if (ProjectID == null)
            {
                return BadRequest();
            }
            Projects project = _context.Projects.FirstOrDefault(p => p.ProjectID == ProjectID);
            if (project == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("IndexProject");
        }
        //Details
        public IActionResult DetailsProject(int? ProjectID)
        {
            if (ProjectID == null)
            {
                return BadRequest();
            }
            var project = _context.Projects
                .Include(p => p.Tasks)
                .FirstOrDefault(p => p.ProjectID == ProjectID);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

    }
}

