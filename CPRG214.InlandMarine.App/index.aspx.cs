using CPRG.InlandMarine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPRG214.InlandMarine.App
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new MarinaEntities();
            uxCustomers.DataSource = db.Customers.ToList();
            uxCustomers.DataBind();

        }
    }
}