using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ASP.NETServerObjects
{
    public class Global : System.Web.HttpApplication
    {
        public static readonly String CONNECTION = "my connection";

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["CarlosVarApplication"] = "Dan Variable from Application";
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["CarlosVarSession"] = "Carlos Variable from Session";

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Response.Write("Begin Request from Application");
            Trace.WriteLine("Request Begins");
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            Response.Write("End Request from Application");
            Trace.WriteLine("Request Ends");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}