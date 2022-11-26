using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.Introduction.Tag.Helper.Web.DatabaseContexts;
using Razor.Introduction.Tag.Helper.Web.Models;
using System.Diagnostics;

namespace Razor.Introduction.Tag.Helper.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserDatabaseContext _context;

        public HomeController(ILogger<HomeController> logger,UserDatabaseContext context )
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userList = await _context.Users.ToListAsync();

            return View(userList);
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