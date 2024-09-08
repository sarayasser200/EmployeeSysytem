
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal2.BLL.ModelVM.EmployeeVM;
using Portal2.DAl.Entities;
using System.Security.Claims;

namespace Portal2.pll.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register(RegisterUserVM newUserVM)
        {
            if (ModelState.IsValid)
            {
                User userModel = new User();
                userModel.UserName = newUserVM.UserName;
                userModel.address = newUserVM.Address;
                userModel.Email = newUserVM.Email;
                userModel.PasswordHash = newUserVM.Password;
                IdentityResult Result=await userManager.CreateAsync(userModel,newUserVM.Password);
                if (Result.Succeeded)
                {
                    //await userManager.AddToRoleAsync(userModel, "Employee");
                    //create cookie
                    //ID , Name Roles + extra
                    await signInManager.SignInAsync(userModel, false);
                    //List<Claim> claims = new List<Claim>();
                    //claims.Add(new Claim("color", "red"));
                    //await signInManager.SignInWithClaimsAsync(userModel, false, claims);
                   
                    return RedirectToAction("Index", "Employee"); // Remove the extra space before "Employee"


                }
                else
                {
                    foreach(var error in Result.Errors)
                    {
                        ModelState.AddModelError("Password",error.Description);
                    }
                }
                


            }
            return View(newUserVM);
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult > Login(LoginUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                //create cookie 
                User userModel= await userManager.FindByNameAsync(userVM.UserName);
                if(userModel != null)
                {
                    bool found=await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found == true)
                    {
                       await  signInManager.SignInAsync(userModel, userVM.RemenberMe);
                        return RedirectToAction("Index", "Employee");

                    }
                }
                ModelState.AddModelError("", "user name or password are wrong ");


            }
            return View(userVM);
        }
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [Authorize (Roles ="Admin")]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdmin(RegisterUserVM newUserVM)
        {
            if (ModelState.IsValid)
            {
                User userModel = new User();
                userModel.UserName = newUserVM.UserName;
                userModel.address = newUserVM.Address;
                userModel.Email = newUserVM.Email;
                userModel.PasswordHash = newUserVM.Password;
                IdentityResult Result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (Result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userModel, "Admin");
                
                    await signInManager.SignInAsync(userModel, false);
                    //List<Claim> claims = new List<Claim>();
                    //claims.Add(new Claim("color", "red"));
                    //await signInManager.SignInWithClaimsAsync(userModel, false, claims);

                    return RedirectToAction("Index", "Employee"); // Remove the extra space before "Employee"


                }
                else
                {
                    foreach (var error in Result.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                }



            }
            return View( newUserVM);
        }
        

    }

}

