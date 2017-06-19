using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using VVJ.LearningAspNetIdentity.WebForms.Services.UserService;

namespace VVJ.LearningAspNetIdentity.WebForms
{
    public partial class Register : System.Web.UI.Page
    {
        private UserService userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var result = userService.CreateUser(this.UserName.Text,this.Password.Text);
            if (result.Succeeded)
            {
                userService.SingIn(userService.GetUser(UserName.Text, Password.Text));
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}