using CPRG.InlandMarine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPRG214.InlandMarine.App
{
    /*
    * CPRG 214 Assignment 1
    * Purpose: This is the behind code for the registration page
    * Author: Doug Cameron and Ini Akpan
    * Date: July, 2020
    */
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //this is the method for authenticating a user
        protected void uxAuthenticate_Click(object sender, EventArgs e)
        {
            //run the authenticate method to see if user already exists
            //First and Last names come from the text boxes
            var customerExists = MarinaManager.Authenticate(uxFirstname.Text, uxLastname.Text);

            if (customerExists == null)  //if the customer does not exist
            {
                var newCust = new Customer  //create a new customer object entity class
                {
                    FirstName = uxFirstname.Text,  //add info from text boxes to object
                    LastName = uxLastname.Text,
                    Phone = uxPhone.Text,
                    City = uxCity.Text
                };

                MarinaManager.AddCust(newCust); //call the add method to insert in customer

                
                Session.Add("CustomerID", newCust.ID);//add id to the session from the object id

                //if logged in successfull, direct to slips page with username Fullname
               
                var FullName = $"{newCust.FirstName} {newCust.LastName}";

                FormsAuthentication.RedirectFromLoginPage(FullName, false);
            }
            else
            { 
                //if the customer does exist, the add id to the session
                Session.Add("CustomerID", customerExists.ID);

                //if logged in successfull, direct to main page with username Fullname
                FormsAuthentication.RedirectFromLoginPage(customerExists.FullName, false);
            }
        }
    }
}