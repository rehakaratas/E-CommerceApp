using E_CommerceApp.Application.Models.DTOs;
using E_CommerceApp.Application.Services.LoginService;
using E_CommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace EcommerceApp.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var loggedUser = await _loginService.Login(loginDTO);

            if (loggedUser != null)
            {
                var jsonUser = JsonConvert.SerializeObject(loggedUser);

                HttpContext.Session.SetString("loggedUser", jsonUser);

                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Role, loggedUser.Roles.ToString()));

                var userIdentity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                if (loggedUser.Roles == Roles.Admin)
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
                if (loggedUser.Roles == Roles.Manager)
                {
                    return RedirectToAction("Index", "Manager", new { area = "Manager" });
                }

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return View(loginDTO);
        }
    }
}
