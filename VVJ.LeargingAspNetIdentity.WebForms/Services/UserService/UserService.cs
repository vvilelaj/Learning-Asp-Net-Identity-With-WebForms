using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VVJ.LearningAspNetIdentity.WebForms.Services.UserService
{
    public class UserService
    {
        public UserManager<IdentityUser> GetUserManager()
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            return userManager;
        }

        public IdentityUser GetUser(string userName, string password)
        {
            var userManager = this.GetUserManager();
            var user = userManager.Find(userName, password);
            return user;
        }

        public void SingIn(IdentityUser user)
        {
            var authenticationManager = GetAuthenticationManager();
            var userIdentity = GetUserManager().CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, userIdentity);
        }

        public IAuthenticationManager GetAuthenticationManager()
        {
            return HttpContext.Current.GetOwinContext().Authentication;
        }

        public void SingOut()
        {
            var authenticationManager = GetAuthenticationManager();
            authenticationManager.SignOut();
        }

        public IdentityResult CreateUser(string userName, string password)
        {
            var user = new IdentityUser() { UserName = userName };
            var result = GetUserManager().Create(user, password);
            return result;
        }
    }
}