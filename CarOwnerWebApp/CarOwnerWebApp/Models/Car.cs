using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOwnerWebApp.Models
{
    public enum CarColor
    {
        red,
        white,
        green,
        pink,
        black
    }

    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarColor Color { get; set; }

    }
}
