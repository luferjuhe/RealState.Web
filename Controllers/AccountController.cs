using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealState.Data.Entities;
using RealState.Web.Services;
using RealState.Web.ViewModels;
using System.Security.Claims;

namespace RealState.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService svc;

        public AccountController(IUsersService svc)
        {
            this.svc = svc;
        }

        [AllowAnonymous]
        public IActionResult LogIn()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("Restaurant.Web");

            return RedirectToAction("Login", "Login");
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel vm)
        {

            //if (ModelState.IsValid)
            //{
            User user = await svc.GetUserByEmail(vm.UserName);
            if (user.InactiveDate != null)
            {
                ModelState.AddModelError("", "El usuario se encuentra dado de baja");

                return View(vm);
            }
            if (user.Password == vm.Password)
            {
                return await Claims(user.UserId, vm.ReturnUrl);
            }

            ModelState.AddModelError("", "Usuario o contraseña incorrecta");
            //}

            return View(vm);
        }

        [AllowAnonymous]
        private async Task<IActionResult> Claims(int userId, string returnUrl)
        {
            UserViewModel user = await svc.GetUserById(userId);
            var claims = new List<Claim>
             {
                 new Claim("UserId", user.UserId.ToString(), ClaimValueTypes.Integer),
                 new Claim("Name",user.Name),
                 //new Claim("UserActions", await svc.GetActionsForUserAsync(user.UserId))
             };
            var claimsIdentity = new ClaimsIdentity(claims, "RealState.Web");
            await HttpContext.SignInAsync("RealState.Web", new ClaimsPrincipal(claimsIdentity));

            if (returnUrl != null && Url.IsLocalUrl(returnUrl))
            {
                returnUrl = returnUrl.Replace("/Search", "");
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
