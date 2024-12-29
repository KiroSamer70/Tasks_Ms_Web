using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks_MS_Web.Models;

namespace Tasks_MS_Web.Controllers
{
    public class TaskController : Controller
    {
        public TasksMsContext _context = new TasksMsContext();

        // Read
        public IActionResult IndexTask()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        // Update
        public IActionResult EditTask(int? TaskID)
        {
            if (TaskID == null)
            {
                return BadRequest();
            }
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == TaskID);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult EditTask(int TaskID, string TaskStatus)
        {
            if (string.IsNullOrEmpty(TaskStatus))
            {
                ModelState.AddModelError("", "Invalid Data");
                var task = _context.Tasks.FirstOrDefault(t => t.TaskId == TaskID);
                return View(task);
            }

            var taskToUpdate = _context.Tasks.FirstOrDefault(t => t.TaskId == TaskID);
            if (taskToUpdate == null)
            {
                return NotFound();
            }

            taskToUpdate.TaskStatus = TaskStatus;
            _context.Tasks.Update(taskToUpdate);
            _context.SaveChanges();

            return RedirectToAction("IndexTask");
        }
    }
}
