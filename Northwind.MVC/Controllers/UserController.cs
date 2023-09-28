using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.BLL.DTOs;
using Northwind.MVC.Models;

namespace Northwind.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager) {
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email,
                };

                var result = await _userManager.CreateAsync(user, registerDTO.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
