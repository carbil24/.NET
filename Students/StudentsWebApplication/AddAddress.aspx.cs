using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentsWebApplication.BussinessLayer;
using StudentsWebApplication.DataLayer;

namespace StudentsWebApplication
{
    public partial class AddAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertAddress_Click(object sender, EventArgs e)
        {
            Address address = new Address();

            if (!String.IsNullOrEmpty(txtStreet.Text))
            {
                address.Street = txtStreet.Text;
            }

            if (!String.IsNullOrEmpty(txtCity.Text))
            {
                address.City = txtCity.Text;
            }

            if (!String.IsNullOrEmpty(txtProvince.Text))
            {
                address.Province = txtProvince.Text;
            }

            if (!String.IsNullOrEmpty(txtPostalCode.Text))
            {
                address.PostalCode = txtPostalCode.Text;
            }

            if(DBUtility.InsertAddressFromSP(address) == 1)
            {
                lblMessage.Text = "The address record was successfully inserted";
            }
            else
            {
                lblMessage.Text = "Not good";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}