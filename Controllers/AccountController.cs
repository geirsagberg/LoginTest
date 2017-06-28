using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CookieTest.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public Task Login([FromBody] LoginParams loginParams)
        {
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity (CookieAuthenticationDefaults.AuthenticationScheme));
            return HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }
    }

    public class LoginParams
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
