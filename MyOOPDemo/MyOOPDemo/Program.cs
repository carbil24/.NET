using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vehicle vehicle = new Vehicle();

                Console.WriteLine(vehicle);
                Console.WriteLine("Year:" + vehicle.GetYearModel());
                Console.WriteLine("Manufacturer: " + vehicle.GetManufacturer());

                Vehicle v2 = new Vehicle(2050, 200, "BMW");
                Console.WriteLine(v2);

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            Console.WriteLine("Process continues...");

            try
            {
                Car c = new Car(
                    _year: 2019,
                    _maxSpeed: 300,
                    _manufacturer: "BMW",
                    _noDoors: 2,
                    _name: "M3"
                    );
                Console.WriteLine(c);
                for (int i = 0; i < 70; i++)
                {
                    Console.WriteLine(c.Accelerate());
                }

                Car c2 = new Car(
                _year: 2000,
                _maxSpeed: 150,
                _manufacturer: "Honda",
                _noDoors: 4,
                _name: "Civic"
                );

                Console.WriteLine(c2);
                Console.WriteLine("The older car is " + Car.OlderCar(c, c2));

            }
            catch (Exception)
            {

                throw;
            }

            Console.ReadKey();
        }
    }
}
