using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NETServerObjects
{
    public partial class SessionTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String myCarlosVar = Session["CarlosVarSession"].ToString();
            Response.Write(myCarlosVar);
            Response.Write(Session.IsCookieless);
            Response.Write(Session.SessionID);
        }
    }
}