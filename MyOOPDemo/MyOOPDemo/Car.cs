using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOOPDemo
{
    class Car : Vehicle
    {
        //Fields - Properties
        //backing properties
        private int _currentSpeed;
        private int _noDoors;
        private string _name;

        //Shortcut: prop
        public int CurrentSpeed {
            get
            {
                return _currentSpeed;
            }

            private set //keyword: value
            {
                //if (value < 0)
                //{
                //    throw new ArgumentException("Speed can not be negative.", "CurrentSpeed");
                //}
                //else if (value > base.GetMaxSpeed())
                //{
                //    throw new ArgumentException("Speed can not exceed max speed.", "CurrentSpeed");
                //}
                //_currentSpeed = value;


                if (value < 0)
                {
                    _currentSpeed = 0;
                }
                else if (value > base.GetMaxSpeed())
                {
                    _currentSpeed = base.GetMaxSpeed();
                }
                else
                {
                    _currentSpeed = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Car name cannot be empty", "Name");
                }
                _name = value;
            }
        }

        //Increases the speed of the car (by 5)
        public int Accelerate()
        {
            CurrentSpeed += 5;
            return CurrentSpeed;
        }

        public int Break()
        {
            return CurrentSpeed -= 5;
        }

        public int NoDoors
        {
            get
            {
                return _noDoors;
            }
            set
            {
                //min one door - max: 10
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Invalid number of doors", "NoDoors");
                }
                _noDoors = value;

            }
        }

        //Methods
        public Car(int _year, int _maxSpeed, string _manufacturer, int _noDoors, string _name): base(_year, _maxSpeed, _manufacturer)
        {
            CurrentSpeed = 0;
            NoDoors = _noDoors;
            Name = _name;
        }


        //Override

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}", Name, GetManufacturer(), GetYearModel());
        }

        //Static method belongs to the class.
        public static Car OlderCar(Car car1, Car car2)
        {
            return car1.GetYearModel() < car2.GetYearModel() ? car1 : car2;
        }

    }
}
