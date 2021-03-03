using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSVApp.Application.Contexts.UserProfile.Commands.UserProfile;
using CSVApp.Contract.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSVApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
         
        public UserProfileController(UserManager<ApplicationUser> userManager) {
                _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<object> GetUserProfile() {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var userProfile = new UserProfileCommand(_userManager); 
            return Ok(await Task.Run(() => userProfile.GetUserProfile(userId)));
        }
    }
}