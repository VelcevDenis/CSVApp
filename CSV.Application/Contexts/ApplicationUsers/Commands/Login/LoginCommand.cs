using Castle.Core.Configuration;
using CSVApp.Application.Contexts.ApplicationUsers.ViewModels;
using CSVApp.Contract.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.ApplicationUsers.Commands.Login {
    public class LoginCommand {
        private UserManager<ApplicationUser> _userManager;

        public LoginCommand() {
        }

        public LoginCommand(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<object> Login(LoginModel request, string jwtSecretKey, ApplicationUser user) {
            //var user = await _userManager.FindByNameAsync(request.UserName);

            //if (user != null && await _userManager.CheckPasswordAsync(user, request.Password)) {
                var key = Encoding.UTF8.GetBytes(jwtSecretKey);

                var tokenDescriptor = new SecurityTokenDescriptor {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserID", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHendler = new JwtSecurityTokenHandler();
                var securityToken = tokenHendler.CreateToken(tokenDescriptor);
                var token = tokenHendler.WriteToken(securityToken);
                return new { token };
            //} else
            //    return new { action = false, result = new { message = "Username or password is incorect." } });
        }
    }

}