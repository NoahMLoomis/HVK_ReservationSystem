using HVK_ZZTop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace HVK.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly HVK_ZZTopContext _context;


        public HomeController(ILogger<HomeController> logger, HVK_ZZTopContext context) {
            _logger = logger;
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {

            if (HttpContext.Session.GetInt32("ownerId") != null) {

                var ownerId = HttpContext.Session.GetInt32("ownerId");

                var owner = _context.Owner.Where(o => o.OwnerId == ownerId).FirstOrDefault();
                ViewBag.Customer = owner;
                ViewBag.User = new HVK_ZZTop.Models.User { UserId = owner.OwnerId, FirstName = owner.FirstName, LastName = owner.LastName };
            }
        }

        public IActionResult Index() {
            return View("Login");
        }

        [Route("/Login")]
        [AllowAnonymous]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [Route("/Login")]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model, string returnUrl) {
            if (!ModelState.IsValid) {
                return View();
            }

            var user = _context.Owner.Where(o => o.Email == model.Email || o.Phone == model.Email).FirstOrDefault();

            if (user != null && model.Password == user.Password) {

                string role = user.Email != null && user.Email.EndsWith("@hvk.ca") ? "Clerk" : "Customer";

                HttpContext.Session.SetInt32("ownerId", user.OwnerId);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.OwnerId.ToString()),
                    new Claim("FullName", user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.Role, role),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                // Set current principal
                Thread.CurrentPrincipal = claimsPrincipal;

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                if (role == "Clerk") {
                    return RedirectToAction("Index", "Clerk");
                } else {

                    return RedirectToAction("Index", "Customer", new { @id = user.OwnerId });
                }
            }
            ModelState.AddModelError(string.Empty, "invalid email/phone number or password.");
            return View();
        }

        public IActionResult Logout() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout(FromFormAttribute form) {
            _logger.LogInformation("User {Name} logged out at {Time}.",
                User.Identity.Name, DateTime.UtcNow);

            #region snippet1
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            #endregion

            return RedirectToAction("Index", "Home");
        }

        [Route("/AccessDenied")]
        public IActionResult AccessDenied() {
            return View();
        }
    }
}
