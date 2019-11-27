using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOOPDemo
{
    class Vehicle
    {
        //Fields
        private int yearModel; //cannot have a values less than 1900 or more than this year+1.
        private int maxSpeed; //cannot be negative 
        private string manufacturer;

        private const int MIN_YEAR = 1900;
        //Methods
        //Default constuctor - shortcut: ctor
        public Vehicle()
        {
            SetYearModel(MIN_YEAR);
            SetMaxSpeed(0);
            SetManufacturer("Unknown");
        }

        public Vehicle(int _yearModel, int _maxSpeed, string _manufacturer)
        {
            SetYearModel(_yearModel);
            SetMaxSpeed(_maxSpeed);
            SetManufacturer(_manufacturer);
        }


        //Getters
        public int GetYearModel()
        {
            return yearModel;
        }

        protected int GetMaxSpeed() // access in inherited classes
        {
            return maxSpeed;
        }

        public string GetManufacturer()
        {
            return manufacturer;
        }

        //setters

        public void SetYearModel(int _year)
        {
            if (_year < MIN_YEAR || _year > DateTime.Now.Year + 1)
                throw new ArgumentException("Year Model cannot be less than 1900 or more than next year", "yearModel");
            yearModel = _year;
        }

        public void SetMaxSpeed(int _speed)
        {
            if (_speed < 0)
                throw new ArgumentException("Max speed cannot be negative", "maxSpeed");
            maxSpeed = _speed;
        }

        public string SetManufacturer(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value cannot be empty", "manufacturer");
            manufacturer = value;
            return manufacturer;
        }

        public override string ToString()
        {
            return string.Format("{0}|{1}", yearModel, manufacturer);
        }
    }
}
