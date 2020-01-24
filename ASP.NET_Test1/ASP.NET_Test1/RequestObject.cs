using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASP.NET_Test1
{
    public class RequestObject
    {
        private HttpRequest _request;

        public RequestObject(HttpRequest request)
        {
            _request = request;
        }

        public string browserInfoFromRegularClass()
        {
            StringBuilder browserInfo = new StringBuilder();

            browserInfo.Append("<br/>Browser Info from Regular Class:<br/>");

            browserInfo.Append($"Browser : {_request.Browser.Browser}<br/>");
            browserInfo.Append($"Browser Version : {_request.Browser.Version}<br/>");
            browserInfo.Append($"Client's Platform : {_request.Browser.Platform}<br/>");
            browserInfo.Append($".NET CLR Version : {_request.Browser.ClrVersion}<br/>");
            browserInfo.Append($"ECMA Script Version : {_request.Browser.EcmaScriptVersion}<br/>");
            browserInfo.Append($"MS Html Document Object Model Version : {_request.Browser.MSDomVersion}<br/>");
            browserInfo.Append($"W3C XML Document and Object Model Version : {_request.Browser.W3CDomVersion}<br/>");

            return browserInfo.ToString();
        }
    }
}