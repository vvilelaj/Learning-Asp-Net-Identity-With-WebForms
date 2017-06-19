using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VVJ.LearningAspNetIdentity.WebForms.Services.UserService;

namespace VVJ.LearningAspNetIdentity.WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        private UserService userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    StatusText.Text = $"Hello {User.Identity.Name}!!";
                    LoginStatus.Visible = true;
                    LogoutButton.Visible = true;
                }
                else
                {
                    LoginForm.Visible = true;
                }
            }
        }

        protected void SignIn(object sender, EventArgs e)
        {
            var user = userService.GetUser(UserName.Text, Password.Text);
            if (user != null)
            {
                userService.SingIn(user);
                var returnUrl = (string.IsNullOrWhiteSpace(Request.QueryString["ReturnUrl"])) ? "~/Login.aspx" : Request.QueryString["ReturnUrl"];
                Response.Redirect(returnUrl);
            }
            else
            {
                StatusText.Text = "Invalid username or password.";
                LoginStatus.Visible = true;
            }
        }

        protected void SignOut(object sender, EventArgs e)
        {
            userService.SingOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}