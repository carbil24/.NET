using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLoginExample
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] != null && Session["login"].Equals(1))
            {
                this.aLogin.InnerText = "Logoff";
            }
            else
            {
                this.aLogin.InnerText = "Login";
                Session["login"] = 0;
            }

        }
    }
}