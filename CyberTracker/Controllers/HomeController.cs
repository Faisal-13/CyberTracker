using CyberTracker.Data;
using CyberTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CyberTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Get Incident Counts by Severity
            var severityData = await _context.Incidents
                .GroupBy(i => i.Severity)
                .Select(g => new { Severity = g.Key, Count = g.Count() })
                .ToListAsync();

            // 2. Get Incident Counts by Status
            var statusData = await _context.Incidents
                .GroupBy(i => i.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToListAsync();


            var tips = await _context.SecurityTips
                .OrderByDescending(t => t.PostedDate)
                .Take(3)
                .ToListAsync();
            
            // 3. Pass data to View using ViewBag (Simple way for JSON)
            ViewBag.SeverityLabels = severityData.Select(d => d.Severity).ToArray();
            ViewBag.SeverityCounts = severityData.Select(d => d.Count).ToArray();

            ViewBag.StatusLabels = statusData.Select(d => d.Status).ToArray();
            ViewBag.StatusCounts = statusData.Select(d => d.Count).ToArray();

            // 4. Fetch recent "Security Awareness" tips (We will build this next)
            // For now, let's just send the counts
            return View(tips);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}