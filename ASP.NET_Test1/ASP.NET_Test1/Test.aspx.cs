using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Test1
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder browserInfo = new StringBuilder();

            browserInfo.Append("Browser Info from Page Class:<br/>");
            browserInfo.Append($"Browser : {Request.Browser.Browser}<br/>");
            browserInfo.Append($"Browser Version : {Request.Browser.Version}<br/>");
            browserInfo.Append($"Client's Platform : {Request.Browser.Platform}<br/>");
            browserInfo.Append($".NET CLR Version : {Request.Browser.ClrVersion}<br/>");
            browserInfo.Append($"ECMA Script Version : {Request.Browser.EcmaScriptVersion}<br/>");
            browserInfo.Append($"MS Html Document Object Model Version : {Request.Browser.MSDomVersion}<br/>");
            browserInfo.Append($"W3C XML Document and Object Model Version : {Request.Browser.W3CDomVersion}<br/>");

            Response.Write(browserInfo.ToString());

            //Calling the regular class
            RequestObject req = new RequestObject(Request);

            string browserInfoFromRegularClass = req.browserInfoFromRegularClass();

            Response.Write(browserInfoFromRegularClass); 
        }
    }
}