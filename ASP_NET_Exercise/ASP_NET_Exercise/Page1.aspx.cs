using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_NET_Exercise
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session["firstName"] = txtFirstName.Text;
            Session["lastName"] = txtLastName.Text;
            Session["age"] = txtAge.Text;

            Global.sessions.Add(Session["firstName"].ToString() + " " + Session["lastName"].ToString() + " " + Session["age"].ToString());

            Response.Redirect("Page2.aspx");
        }
    }
}