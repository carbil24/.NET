using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NETServerObjects
{
    public partial class ResponseObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lblDownload_Click(object sender, EventArgs e)
        {
            // Append a Header to the response to force a Download of the file Summary.txt as an attachement
            Response.AppendHeader("Content-Disposition", "Attachment;FileName=Summary.txt");

            // Set the Content Type to text/plain as the download file is a TXT file
            Response.ContentType = "text/plain";

            // Write the file to the Response
            Response.WriteFile("Summary.txt");

            // Stop further execution of the page
            Response.End();

        }
    }
}