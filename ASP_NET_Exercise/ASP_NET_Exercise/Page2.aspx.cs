using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_NET_Exercise
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFirstName.Text = Session["firstName"].ToString();
            lblLastName.Text = Session["lastName"].ToString();
            lblAge.Text = Session["age"].ToString();

        }

        protected void btnResults_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page3.aspx");
        }
    }
}