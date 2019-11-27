using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStructsDemo
{
    class Program
    {
        struct Customer
        {
            //Fields
            public uint id;
            public string name;
            public Subscription subscription;
            public double balance;

            public const int MAX_RENTAL_DAYS = 10;

            //Constructors
            public Customer(uint _id, string _name, Subscription _subscription, double _balance)
            {
                id = _id;
                name = _name;
                subscription = _subscription;
                balance = _balance;
            }
            //Methods
            public void PrintCustomerInfo()
            {
                Console.WriteLine("Name: {0}\nID#: {1}\n Subscription: {2}\n Balance:{3}", name, id, subscription, balance);
            }

            public override string ToString()
            {
                return id + "|" + name + "|" + subscription;
            }

            public override bool Equals(object obj)
            {
                return this.subscription == ((Customer)obj).subscription;
            }

          
        }

        enum Subscription
        {
            PayAsYouGo, Monthly, Quarterly, Annual
        }

        static void Main(string[] args)
        {
            //Create one customer
            //Customer c;
            //c.name = "Alex";
            //c.id = 123;
            //c.subscription = Subscription.Monthly;
            //c.balance = 0;

            //c.PrintCustomerInfo();
            //Console.WriteLine(c.ToString());
            //Console.WriteLine("***********************" );

            //Customer x = new Customer(456, "Ben", Subscription.Monthly, 45.50);
            //x.PrintCustomerInfo();
            //Console.WriteLine(x.ToString());

            //if (x.Equals(c))
            //{
            //    Console.WriteLine("They are equal");
            //}
            //else
            //{
            //    Console.WriteLine("They are not equal");
            //}

            PrintCustomerList(GetCustomerList(@"C:\Users\ipd\source\repos\MyStructsDemo\MyStructsDemo\CustomerFile.csv"));

            Console.ReadKey();
        }

        /* create method that return a list of customers saved in CSV 
           * Inputs: File Name
           * Output: List of Customer
           * 
           * Instruction: use StreamReader
           * line: 123,Alex,0,10.50
           *       ID,Name,Subs,Balance
           */

        static List<Customer> GetCustomerList(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader streamReader = null;
                string currentLine;
                List<Customer> listOfCustomers = new List<Customer>();
                //Step 3:
                try
                {
                    //Step 4: open stream
                    using (streamReader = new StreamReader(fileName))
                    {
                        //Step 5: read from the file
                        while ((currentLine = streamReader.ReadLine()) != null)
                        {
                            string[] values = currentLine.Split(',');
                            Customer c;

                            c.id = uint.Parse(values[0]);
                            c.name = values[1];
                            c.subscription = (Subscription)int.Parse(values[2]);
                            c.balance = double.Parse(values[3]);
                            listOfCustomers.Add(c);

                        }
                    }
                    return listOfCustomers;
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.StackTrace);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Provided file does not exist");
                return null;

            }
        }

        static void PrintCustomerList(List<Customer> list)
        {
            if (list != null)
            {
                foreach (Customer customer in list)
                {
                    Console.WriteLine(customer);
                }
            }
            else
            {
                Console.WriteLine("List is corrupted.");
            }

        }

    }
}
