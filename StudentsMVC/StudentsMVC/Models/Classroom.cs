using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsMVC.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return Name + " - " + Number;
        }
    }
}