using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks_MS_Web.Models;

namespace Tasks_MS_Web.Controllers
{
    public class TeamMemberController : Controller
    {

        TasksMsContext _context = new TasksMsContext();
        //Read
        public IActionResult IndexMember()
        {
            var member = _context.TeamMembers.ToList();
            return View(member);
        }

        //Update
        public IActionResult EditMember(int? MemberID)
        {
            if (MemberID == null)
            {
                return BadRequest();
            }
            TeamMember member = _context.TeamMembers.FirstOrDefault(m => m.MemberID == MemberID);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
        [HttpPost]
        public IActionResult EditMember(TeamMember member)
        {
            if (member == null)
            {
                ModelState.AddModelError("", "Invalid Data");
                return View(member);
            }
            else
            {
                _context.TeamMembers.Update(member);
                _context.SaveChanges();
                return RedirectToAction("IndexMember");
            }
        }

        //Details
        public IActionResult DetailsMember(int? MemberID)
        {
            if (MemberID == null)
            {
                return BadRequest();
            }
            var member = _context.TeamMembers.Include(T=>T.Tasks).FirstOrDefault(m => m.MemberID == MemberID);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }


    }
}
