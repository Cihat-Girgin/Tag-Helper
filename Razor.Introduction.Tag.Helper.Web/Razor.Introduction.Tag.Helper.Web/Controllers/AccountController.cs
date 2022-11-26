using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.Introduction.Tag.Helper.Web.DatabaseContexts;

namespace Razor.Introduction.Tag.Helper.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserDatabaseContext _context;
        public AccountController(UserDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email,string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if(user == null)
            {
                return View();
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
