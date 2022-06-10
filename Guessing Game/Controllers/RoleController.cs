using Guessing_Game.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Guessing_Game.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
    
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        
        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            IdentityResult result = await  _roleManager.CreateAsync(new IdentityRole { Name= name });

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();
            
        }

        public IActionResult AddUserToRole()
        {
            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name","Name");
            ViewBag.Users = new SelectList(_userManager.Users, "Id","UserName");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string role, string user)
        {
            var currentUser = await _userManager.FindByIdAsync(user) ;
            IdentityResult result = await _userManager.AddToRoleAsync(currentUser, role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
