using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NETServerObjects
{
    public class ServerObjects
    {
        private HttpResponse _response;

        public ServerObjects() { }

        public ServerObjects(HttpResponse response)
        {
            _response = response;
        }

        public int GetResponseStatusCode()
        {
            return _response.StatusCode;
        }

        public int GetResponseStatusCodeFromContext()
        {
            String myConnection = Global.CONNECTION;
            //String myCarlosVar = (String)HttpContext.Current.Application["CarlosVar"];
            String myCarlosVar = HttpContext.Current.Application["CarlosVarApplication"].ToString();

            return HttpContext.Current.Response.StatusCode;
        }

        public int AddNumbers(int n1, int n2)
        {
            if ((n1 + n2) > 0)
            {
                return n1 + n2;
            }
            else
            {
                return 0;
            }
        }
    }
}