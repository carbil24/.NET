using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLoginExample
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null || Session["login"].Equals(0))
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}