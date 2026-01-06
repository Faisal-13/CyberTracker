using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CyberTracker.Data;
using CyberTracker.Models;

namespace CyberTracker.Controllers
{
    // 1. Force users to be logged in to see anything here
    [Authorize]
    public class IncidentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IncidentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            // Include the Reporter data so we can show their email in the list
            var incidents = await _context.Incidents.Include(i => i.Reporter).ToListAsync();
            return View(incidents);
        }

        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var incident = await _context.Incidents
                .Include(i => i.Reporter)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (incident == null) return NotFound();

            return View(incident);
        }

        // GET: Incidents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Incidents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Incident incident)
        {
            // We remove "Reporter" from validation because we set it manually below
            ModelState.Remove("Reporter");
            ModelState.Remove("ReporterId");

            if (ModelState.IsValid)
            {
                // 2. Automatically set the Reporter to the current logged-in user
                var currentUser = await _userManager.GetUserAsync(User);
                incident.ReporterId = currentUser.Id;
                incident.CreatedAt = DateTime.Now;

                _context.Add(incident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incident);
        }

        // GET: Incidents/Edit/5
        // 3. Only Admins can edit (Simple rule for now)
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null) return NotFound();
            return View(incident);
        }

        // POST: Incidents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Incident incident)
        {
            if (id != incident.Id) return NotFound();

            // We must preserve the original Reporter and Date
            // (In a real app, use a ViewModel here to avoid overwriting data)
            ModelState.Remove("Reporter");
            ModelState.Remove("ReporterId");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Incidents.Any(e => e.Id == incident.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(incident);
        }

        // GET: Incidents/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var incident = await _context.Incidents
                .Include(i => i.Reporter)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (incident == null) return NotFound();

            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident != null)
            {
                _context.Incidents.Remove(incident);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}