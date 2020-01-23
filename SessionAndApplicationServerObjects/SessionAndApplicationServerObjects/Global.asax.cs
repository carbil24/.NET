using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SessionAndApplicationServerObjects
{
    public class Global : System.Web.HttpApplication
    {
        public static readonly string ConnectionString = "connection information";
        protected DateTime beginRequestTime;
        public static DataSet MyDataSet;



        protected void Application_Start(object sender, EventArgs e)
        {
            DataSet MyDataSet = (DataSet)Application["MyDataSet"];
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            beginRequestTime = DateTime.Now;
            Response.Write("Begin Request from Application on " + beginRequestTime + "<br/>");
            //Trace.WriteLine("Request Begins");
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            string messageFormat = "Elapsed request time (ms) = {0}<br/>";
            TimeSpan diffTime = DateTime.Now - beginRequestTime;
            //Trace.WriteLine(String.Format(messageFormat, diffTime.TotalMilliseconds));
            Response.Write(String.Format(messageFormat, diffTime.TotalMilliseconds));

            Response.Write("End Request from Application on " + DateTime.Now);
            //Trace.WriteLine("Request Ends");
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