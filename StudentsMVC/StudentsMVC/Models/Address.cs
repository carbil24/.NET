using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsMVC.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return Street + " - " + City + " - " + PostalCode;
        }
    }
}