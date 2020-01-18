using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyPageLifeExample_ASP.NET_
{
    public partial class PageLife : System.Web.UI.Page
    {
        StringBuilder msg = new StringBuilder();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //lblHelloWorld.Text = msg.ToString();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            msg.AppendLine("From Page_Init");
            lblHelloWorld.Text = msg.ToString();
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            msg.AppendLine("From Page_InitComplete");
            lblHelloWorld.Text = msg.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            msg.AppendLine("From Page_Load");
            lblHelloWorld.Text = msg.ToString();

            if (!Page.IsPostBack)
            {
                lblHelloWorld.Text = "Hello before PostBack";
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            msg.AppendLine("From Page_PreRender");
            //lblHelloWorld.Text = msg.ToString();
        }

        protected void Page_Render(object sender, EventArgs e)
        {
            msg.AppendLine("From Page_Render");
            //lblHelloWorld.Text = msg.ToString();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            msg.AppendLine("From Page_Unload");
            //lblHelloWorld.Text = msg.ToString();
        }
    }
}