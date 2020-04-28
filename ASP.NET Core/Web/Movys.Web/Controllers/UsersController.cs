namespace Movys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Movys.Data.Models;
    using Movys.Services.Data;
    using Movys.Web.ViewModels.Users;

    public class UsersController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfilePicturesService profilePicturesService;

        public UsersController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IProfilePicturesService profilePicturesService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.profilePicturesService = profilePicturesService;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInputModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var userId = Guid.NewGuid().ToString();

                var user = new ApplicationUser
                {
                    Id = userId,
                    UserName = inputModel.Username,
                    Email = inputModel.Email,
                };

                var result = await this.userManager.CreateAsync(user, inputModel.Password);

                if (result.Succeeded)
                {
                    await this.profilePicturesService.AddPictureAsync("wwwroot/images/DefaultPhoto.png", userId);
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return this.Redirect("/");
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }

                return this.Register();
            }

            return this.Register();
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.signInManager.PasswordSignInAsync(inputModel.Username, inputModel.Password, inputModel.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return this.Redirect("/");
                }
                else
                {
                    this.ModelState.AddModelError("Username", "Invalid Login Attempt.");
                    return this.Login();
                }
            }

            return this.Login();
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return this.Redirect("/");
        }
    }
}
