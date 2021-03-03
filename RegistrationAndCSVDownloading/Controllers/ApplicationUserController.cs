using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CSVApp.Contract.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CSVApp.Application.Contexts.ApplicationUsers.ViewModels;
using CSVApp.Application.Contexts.ApplicationUsers.Commands.Register;
using CSVApp.Application.Contexts.ApplicationUsers.Commands.Login;

namespace CSVApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config) {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostAplicationUser([FromBody] ApplicationUserModel request) {
            var register = new RegisterCommand(_userManager);
            return Ok(await Task.Run(() => register.Registeration(request)));
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login([FromBody] LoginModel request) {
            var JWTSecretKey = _config.GetValue<string>("ApplicationSettings:JWTSecretKey");
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password)) {
                var login = new LoginCommand(_userManager);
                return Ok(await Task.Run(() => login.Login(request, JWTSecretKey, user)));
            } else {
                return BadRequest(new { message = "Username or password is incorect." });
            } 
        }
    }
}