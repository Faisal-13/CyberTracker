using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CyberTracker.Data;
using CyberTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace CyberTracker.Controllers
{
    [Authorize(Roles = "Admin")] // Only Admins can touch this controller
    public class SecurityTipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SecurityTipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SecurityTips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SecurityTips/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SecurityTip securityTip)
        {
            if (ModelState.IsValid)
            {
                securityTip.PostedDate = DateTime.Now;
                _context.Add(securityTip);
                await _context.SaveChangesAsync();

                // Redirect back to the Home Dashboard after adding
                return RedirectToAction("Index", "Home");
            }
            return View(securityTip);
        }
    }
}