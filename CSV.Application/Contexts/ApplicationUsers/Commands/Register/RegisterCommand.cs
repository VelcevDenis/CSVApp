using CSVApp.Application.Contexts.ApplicationUsers.ViewModels;
using CSVApp.Contract.Entity;
using CSVApp.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.ApplicationUsers.Commands.Register {
    public class RegisterCommand {
        private UserManager<ApplicationUser> _userManager;

        public RegisterCommand() {
        }

        public RegisterCommand(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<object> Registeration(ApplicationUserModel request) {
            var applicationUser = new ApplicationUser() {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName
            };

            try {
                return await _userManager.CreateAsync(applicationUser, request.Password);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}