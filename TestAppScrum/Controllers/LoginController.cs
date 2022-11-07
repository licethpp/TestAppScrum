using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestAppScrum.Models;

namespace TestAppScrum.Controllers
{
    public class LoginController : Controller
    {

        private ArtikelenService artikelenService;

        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger, ArtikelenService artikelenService)
        {
            _logger = logger;
            this.artikelenService = artikelenService;

        }
        public IActionResult Index()
        {
            return View();
        }

  
        public ActionResult ChangePassword( )
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordViewModel loginViewModel)
        {
       

            if (ModelState.IsValid)
            {
                //encrypt old and check old in db 
                var dbpassword = "";
                var user = User.FindFirst("DisplayName").Value;
                var personeel = artikelenService.GetPersoneelslid(user, loginViewModel.OldPassword);
                
                if(Hashing.ValidatePassword(loginViewModel.OldPassword, personeel.Paswoord) && loginViewModel.NewPassword == loginViewModel.ConfirmPassword )
                {
                 

                    artikelenService.UpdatePasswoord(user,Hashing.HashPassword(loginViewModel.NewPassword));
                    ViewBag.Messag("Password updated Successfully!");
                    return View();
                }
                else
                {
                    ViewBag.message = "Error!"; 
                    return View(loginViewModel);
                }

            }
            else
            {
                ViewBag.message = "Password not Updated!";
            
                return View(loginViewModel);

            }
           
            
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var personeel = artikelenService.GetPersoneelslid(loginViewModel.Emailadres, loginViewModel.Paswoord);
            if (personeel != null)
            {
                var t = artikelenService.securitygroepenId(personeel.PersoneelslidAccountId);

                if (Hashing.ValidatePassword(loginViewModel.Paswoord, personeel.Paswoord) && t.SecurityGroep.Naam == "Cwebsite")
                {

                    HttpContext.Session.SetString("Emailadres", loginViewModel.Emailadres);

                    artikelenService.JuisteLogin(loginViewModel.Emailadres);
                    //HttpContext.Session.SetString("Emailadres", personeel.Emailadres);
                    //HttpContext.Session.SetInt32("personeelId", personeel.PersoneelslidAccountId);

                    var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(personeel.PersoneelslidAccountId)),
                        new Claim(ClaimTypes.Name, personeel.Emailadres),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim("DisplayName", personeel.Emailadres),
                    };

                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = true
                    });


                    return RedirectToAction("Index", "Home");

                   
                }
                else
                {
                    artikelenService.FouteLogin(loginViewModel.Emailadres);

                    ViewBag.message = "invalid login";
                    return View(loginViewModel);
                }
            }
            else
            {
                artikelenService.FouteLogin(loginViewModel.Emailadres);

                ViewBag.message = "invalid login";
                return View(loginViewModel);
            }
        }

        public async Task<IActionResult> Logout()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return LocalRedirect("/");
        }
    }
}
