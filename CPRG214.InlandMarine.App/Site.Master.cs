using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPRG214.InlandMarine.App
{/*
    * CPRG 214 Assignment 1
    * Purpose: This is the behind code for the site master page
    * Author: Doug Cameron and Ini Akpan
    * Date: July, 2020
    */
    public partial class SiteMaster : MasterPage
    {
        //method for when the page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            //reset the icons on the nav bar
            //if the user exists, set the welcome message
            if (Context.User.Identity.IsAuthenticated)
            {
                uxWelcome.InnerText = $"Welcome {Context.User.Identity.Name}";
                uxLogin.InnerHtml = "<span class= 'fa fa-sign-out-alt'>";
            }
            else // if the user isn't register page is displayed
            {
                uxLogin.InnerHtml = "<span class= 'fa fa-sign-in-alt'>";
                uxWelcome.InnerText = string.Empty;
                
            }

        }
        //method for when user clicks the login icon
        protected void ChangeIconOnClick(object sender, EventArgs e)
        {
            //when the login icon is clicked,
            //and the user is logged in, then log them out
            if (Context.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Response.Redirect("~/");
            }
            else //if the user is not logged in, then forward them to register
            {
                Response.Redirect("~/Register");
            }
        }

    }

}