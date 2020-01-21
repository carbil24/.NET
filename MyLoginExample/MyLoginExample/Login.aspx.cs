using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLoginExample
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] != null && Session["login"].Equals(1))
            {
                Session["login"] = 0;
                Response.Write("You were logged out");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //compare input values against application variables.
            if (this.txtUserName.Text.Equals(Global.USERNAME))
            {
                if (this.txtPassword.Text.Equals(Global.PASSWORD))
                {
                    //set my session variable for login/logoff state
                    Session["login"] = 1;

                    //redirect the action to the Default page
                    Response.Redirect("Default.aspx");
                }
            }




        }
    }
}