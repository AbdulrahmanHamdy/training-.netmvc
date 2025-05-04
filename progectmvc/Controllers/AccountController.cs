using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using progectmvc.Models;
using progectmvc.Viewmodel;
using System.Security.Claims;

namespace progectmvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> usermager;
        private readonly SignInManager<ApplicationUser> sing;
        public AccountController(UserManager<ApplicationUser> usermanger, SignInManager<ApplicationUser> sing) 
        {
            this.usermager = usermanger;
            this.sing = sing; 
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  saveRegister(regviewmodel userviewmodel )
        {
            if (ModelState.IsValid) 
            {
               // Mapping
                ApplicationUser appuser = new ApplicationUser();
                //UserManager<ApplicationUser> manager=new UserManager<ApplicationUser>
                appuser.Address = userviewmodel.Address;
                appuser.UserName = userviewmodel.UserName;                
               appuser.PasswordHash = userviewmodel.Password;
                //save database
               IdentityResult result= await usermager.CreateAsync(appuser,userviewmodel.Password);
                if (result.Succeeded) 
                {
                    //cookie

                    //SignInManager<ApplicationUser> sing = new SignInManager<ApplicationUser>;

                   await sing.SignInAsync(appuser, false);
                    return RedirectToAction("Index", "Department");

                }

                foreach(var item in result.Errors) 
                {
                    ModelState.AddModelError("", item.Description);
                }
                
            }

            return View("Register",userviewmodel);
        }
        public IActionResult Login() 
        {
            return View("Login");
        }
        public async Task<IActionResult> saveLogin(Loginuserviewmodel userviewmodel)
        {
            if (ModelState.IsValid) 
            {
                ApplicationUser appuser= await usermager.FindByNameAsync(userviewmodel.Name);
                if (appuser != null) 
                {
                    bool found=await usermager.CheckPasswordAsync (appuser,userviewmodel.Password);
                    if (found == true) 
                    {
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("UserAddress",appuser.Address ));

                       await sing.SignInWithClaimsAsync(appuser, userviewmodel.RememberMe, Claims);
                        //await sing.SignInAsync(appuser, userviewmodel.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Username or password");


            }

            return View("Login", userviewmodel);
        }
       
        public async Task<IActionResult> signOut() 
        {
          await  sing.SignOutAsync();
            return View("Login");

        }  
    }
}
