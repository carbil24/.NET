using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTextBoxApplication
{
    public partial class DropDownList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserInfo.UserName = System.Configuration.ConfigurationManager.AppSettings["UserNameKey"];

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "Hello from " + DropDownList1.SelectedItem.Text;
        }
    }
}