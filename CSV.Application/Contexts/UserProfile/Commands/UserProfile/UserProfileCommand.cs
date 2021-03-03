using CSVApp.Contract.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.UserProfile.Commands.UserProfile {

    public class UserProfileCommand {
        private UserManager<ApplicationUser> _userManager;

        public UserProfileCommand() {
        }

        public UserProfileCommand(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }        

        public async Task<object> GetUserProfile(string userId) {
            var user = await _userManager.FindByIdAsync(userId);
            return new {
                user.FullName,
                user.Email,
                user.UserName
            };
        }
    }
}
