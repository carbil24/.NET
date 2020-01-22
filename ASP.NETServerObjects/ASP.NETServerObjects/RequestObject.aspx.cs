using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NETServerObjects
{
    public partial class RequestObjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder requestInfo = new StringBuilder();


            requestInfo.Append($"The URL of the ASPX page: {Request.Url} <br>");
            requestInfo.Append($"The Virtual File Path: {Request.FilePath} <br>");
            requestInfo.Append($"The Physical File Path: {Request.PhysicalPath} <br>");
            requestInfo.Append($"The Application Path: {Request.ApplicationPath} <br>");
            requestInfo.Append($"The Physical Application Path: {Request.PhysicalApplicationPath} <br><br>");


            requestInfo.Append("Request Header: <br>");
            NameValueCollection headers = Request.Headers;
            String[] keys = headers.AllKeys;
            foreach (String key in keys)
            {
                requestInfo.Append(key + ": " + headers.Get(key) + "<br>");
            }


            requestInfo.Append($"The Physical File Path: {Request.MapPath("RequestObject.aspx")} <br>");


            lblRequestInfo.Text = requestInfo.ToString();

            StringBuilder browserInfo = new StringBuilder();
            browserInfo.Append($"Browser : {Request.Browser.Browser}<br/>");
            browserInfo.Append($"Browser Version : {Request.Browser.Version}<br/>");
            browserInfo.Append($"Client's Platform : {Request.Browser.Platform}<br/>");
            browserInfo.Append($".NET CLR Version : {Request.Browser.ClrVersion}<br/>");
            browserInfo.Append($"ECMA Script Version : {Request.Browser.EcmaScriptVersion}<br/>");
            //browserInfo.Append($"JavaScript Support : {Request.Browser.JavaScript.toString()}<br/>");
            browserInfo.Append($"MS Html Document Object Model Version : {Request.Browser.MSDomVersion}<br/>");
            browserInfo.Append($"W3C XML Document and Object Model Version : {Request.Browser.W3CDomVersion}<br/>");

            lblBrowserInfo.Text = browserInfo.ToString();
        }
    }
}