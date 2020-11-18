using CPRG.InlandMarine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPRG214.InlandMarine.App
{/*
    * CPRG 214 Assignment 1
    * Purpose: This is the behind code for the Available slips page
    * Author: Doug Cameron and Ini Akpan
    * Date: July, 2020
    */
    public partial class AvailableSlips : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if this the first time page load
            if (!IsPostBack)
            {
                
                var mgr = new MarinaManager();
                //populate the docks drop down list
                uxDocks.DataSource = mgr.GetDocks();
                uxDocks.DataTextField = "Name";
                uxDocks.DataValueField = "ID";
                uxDocks.DataBind();
                uxDocks.SelectedIndex = 0;
                
             } 

        }
        //this method is for the docks dropdown that will be executed on a selection change
        protected void uxDocks_SelectedIndexChanged1(object sender, EventArgs e)
        {
            // get id from the drop down list
            var selectedDock = Convert.ToInt32(uxDocks.SelectedValue);
            var mgr = new MarinaManager();
            //popluate the gridview with the available slips
            uxSlipsGridview.DataSource = mgr.GetSlipsAvailable(selectedDock);
            DataBind(); // calls it on the page; in particular: uxInstructors.DataBind();
        }
          
    }
}