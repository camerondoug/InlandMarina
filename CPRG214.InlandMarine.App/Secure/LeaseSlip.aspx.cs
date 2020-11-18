using CPRG.InlandMarine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPRG214.InlandMarine.App.Secure
{/*
    * CPRG 214 Assignment 1
    * Purpose: This is the behind code for the Lease Slip page
    * Author: Doug Cameron and Ini Akpan
    * Date: July, 2020
    */
    public partial class Enroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if this the first time page load
            if (!IsPostBack)
            {
                //populate the docks drop down list
                var mgr = new MarinaManager();
                uxDocks.DataSource = mgr.GetDocks();
                uxDocks.DataTextField = "Name";
                uxDocks.DataValueField = "ID";
                uxDocks.DataBind();
                uxDocks.SelectedIndex = 0;
                uxSlips.Visible = false;
                Label2.Visible = false;
                               
            }
            

        }
        //this method is for the docks dropdown that will be executed on a selection change
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        // get id from the drop down list
            var selectedDock = Convert.ToInt32(uxDocks.SelectedValue);
            uxSlips.Visible = true;
            Label2.Visible = true;
             
            //populate the slips drop down
            var mgr = new MarinaManager();
            //call the method from the manager class with the select dock as a parameter
            uxSlips.DataSource = mgr.GetSlipsAvailable(selectedDock);
            uxSlips.DataTextField = "ID";
            uxSlips.DataValueField = "ID";
            uxSlips.DataBind();
                            
        }
        //this the method that saves the select lease to the database
        protected void uxLease_Click(object sender, EventArgs e)
        {

            //get the selected slip from the dropdown
            var selectedSlip = Convert.ToInt32(uxSlips.SelectedValue);
            //get the customerid from the session
            var sessionCustomerID = ((int)Session["CustomerID"]);
               
            var newLease = new Lease  //create a new customer object entity class
            {
                SlipID = selectedSlip,  //add info from text boxes to object
                CustomerID = sessionCustomerID,

            };

            MarinaManager.AddLease(newLease); //call the add method to insert a new lease

            var mgr = new MarinaManager();

            //call the method that gets the data for the lease for the customer
            uxSlipsGridview.DataSource = mgr.GetSlipsGridviewCustomer(sessionCustomerID);
            DataBind(); // calls information on the page

            var selectedDock = Convert.ToInt32(uxDocks.SelectedValue); //get the select docks value

            //call the method that gets the available slips on the selected dock
            //and populate the slips drop down
            uxSlips.DataSource = mgr.GetSlipsAvailable(selectedDock);
            uxSlips.DataTextField = "ID";
            uxSlips.DataValueField = "ID";
            uxSlips.DataBind();
        }

        protected void uxSlips_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}