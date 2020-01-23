using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionAndApplicationServerObjects
{
    public partial class ApplicationObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string connectionString = Application["ConnectionString"].ToString();

            string connectionString = Global.ConnectionString;
        }
    }
}