using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_NET_Exercise
{
    public partial class Page3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (String session in Global.sessions)
            {
                Response.Write(session + "<br/>");
            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page1.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Global.sessions.Clear();
            Response.Redirect("Page3.aspx");
        }
    }
}