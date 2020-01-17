using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTextBoxApplication
{
    public partial class UserInfo : System.Web.UI.UserControl
    {
        public string UserName { get; set; }
        public int UserAge { get; set; }
        public string UserCountry { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //UserName = System.Configuration.ConfigurationManager.AppSettings["UserNameKey"];
            UserName = "asdasdadssdfd";
        }
    }
}