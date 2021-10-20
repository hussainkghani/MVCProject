using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity; //for signin methods
using Microsoft.AspNetCore.Authorization; //import aspnet core identity and authorization
using MVCProject.Models; //add models to import your user model
using MVCProject.ViewModels; //need viewmodel to be passed to the login method//u

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager; //set as private
        private UserManager<User> _userManager;
        public AccountController(SignInManager<User> signInManager, UserManager<User>userManager) //pass two variables
        {
            _signInManager = signInManager;
            _userManager = userManager; 
        }
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AllCustomers", "Customer");
            }
            return View(); //add login model
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginmodel)
        {
            if (ModelState.IsValid) //if user has entered all required fields
            {
                var result = await _signInManager.PasswordSignInAsync(loginmodel.Username, loginmodel.Password, loginmodel.RememberMe, false); //username and pw checked by signing manager
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Customer");
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View(); //user has to remain in login view itself if login has failed
        }

        public IActionResult Register()
        {
            return View(); //register page 
        }
        [HttpPost] //needs this since its post method
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) //use async for better performance
        {
            if (ModelState.IsValid)
            {
                MVCProject.Models.User newuser = new User //creating new user with data submitted by registerviewmodel
                {
                    Firstname = registerViewModel.FirstName,
                    Lastname = registerViewModel.Lastname,
                    UserName = registerViewModel.Username,
                    PhoneNumber = registerViewModel.PhoneNumber.ToString(),
                    Email = registerViewModel.Email
                };
                var result = await _userManager.CreateAsync(newuser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    var addeduser = await _userManager.FindByNameAsync(newuser.UserName); //finding user and add user to a particular role
                    //if (newuser.UserName == "Admin")
                    //{
                    //    await _userManager.AddToRoleAsync(addeduser, "Admin"); //whenever user registers with admin username, they are added to admin role
                    //    await _userManager.AddToRoleAsync(addeduser, "Employee"); //admin gets employee priveleges as well
                    //}
                    //if(newuser.UserName == "Employee")
                    //{
                    //    await _userManager.AddToRoleAsync(addeduser, "Employee"); //employees will have employee roles
                    //}
                    //else
                    //{
                    //    await _userManager.AddToRoleAsync(addeduser, "Customer"); //anyone else is added as customer
                    //}
                    return RedirectToAction("Login", "Account"); //successful acount creation takes you to login page
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); //get
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
