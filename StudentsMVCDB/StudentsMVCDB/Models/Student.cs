using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsMVCDB.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Address StudentAddress { get; set; }
        public Class StudentClass { get; set; }

    }
}