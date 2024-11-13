using Idea.Data;
using Idea.Models;
using Idea.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Idea.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identities.Any(x => x.IsAuthenticated))
                return RedirectToAction("Login", "Account", new { area = "Identity" });

            var labels = new List<string>();
            var reactionCounting = new List<int>();
            var ideas = await _context.Ideas.Include(x => x.Reactions).ToListAsync();
            var totalUsers = await _context.Users.CountAsync();
            var totalSubmissions = await _context.Submissions.CountAsync();
            var totalDepartments = await _context.Departments.CountAsync();

            foreach (var idea in ideas)
            {
                labels.Add(idea.Title ?? "(empty)");
                reactionCounting.Add(idea.Reactions.Count());
            }

            return View(new HomeVM
            {
                ChartLabels = labels,
                ChartReactionCounting = reactionCounting,
                TotalUsers = totalUsers,
                TotalSubmissions = totalSubmissions,
                TotalDepartments = totalDepartments,
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

