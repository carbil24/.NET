using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NETServerObjects
{
    public partial class ServerObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServerObjects so = new ServerObjects(Response);
            int statusCode1 = so.GetResponseStatusCode();
            int statusCode2 = so.GetResponseStatusCodeFromContext();

            Response.Write(statusCode1);
            Response.Write(statusCode2);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                lblName.Text = String.Format("Welcome, {0}, <br/> The url is {1}<br/>The machine is {2}<br/>Session ID: {3}",
                                             Server.HtmlEncode(txtName.Text), Server.UrlEncode(Request.Url.ToString()), Server.MachineName, Session.SessionID);
            }
        }
    }
}