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
            return HttpContext.Current.Response.StatusCode;
        }
    }
}