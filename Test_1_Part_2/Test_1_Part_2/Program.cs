using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1_Part_2
{
    class Program
    {
        static int totalSecondsWorked;
        static TimeStamp totalTimeWorked;
        static double totalPayment;

        static void Main(string[] args)
        {

            List<Employee> employeeList = new List<Employee>();

            generateEmployeeListFromFile(employeeList, "emp.txt");

            processTimeWorkedFile(employeeList, "hours.txt");

            printReport(employeeList, "Report.txt");

            PrintCustomerList(employeeList);

            Console.ReadKey();

        }

        public static void generateEmployeeListFromFile(List<Employee> employeeList, string fileName)
        {
            if (File.Exists(fileName))
            {
                string record;
                try
                {
                    using (StreamReader stream = new StreamReader(fileName))
                    {
                        while ((record = stream.ReadLine()) != null)
                        {
                            string[] employeeData = record.Split('|');
                            Employee emp = new Employee
                                (
                                _employeeNumber: int.Parse(employeeData[0]),
                                _lastName: employeeData[1],
                                _firstName: employeeData[2],
                                _hourlyRate: double.Parse(employeeData[3])
                                );
                            employeeList.Add(emp);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File Error: " + e.StackTrace);
                }
            }
            else
                Console.WriteLine("File does not exist");

        }

        public static void processTimeWorkedFile(List<Employee> employeeList, string fileName)
        {
            if (File.Exists(fileName))
            {
                string record;
                try
                {

                    using (StreamReader stream = new StreamReader(fileName))
                    {
                        while ((record = stream.ReadLine()) != null)
                        {
                            string[] empData = record.Split('|');
                            string[] hoursData = empData[1].Split(':');

                            int h = int.Parse(hoursData[0]);
                            int m = int.Parse(hoursData[1]);
                            int s = int.Parse(hoursData[2]);

                            TimeStamp timeWorked = new TimeStamp(h, m, s);

                            addTimeWorkedToEmployee(employeeList, int.Parse(empData[0]), timeWorked);


                            totalSecondsWorked += timeWorked.ConvertToSeconds();

                            totalTimeWorked = timeWorked.ConvertFromSeconds(totalSecondsWorked);

                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File Error: " + e.StackTrace);
                }
            }
            else
                Console.WriteLine("File does not exist");

        }

        public static void addTimeWorkedToEmployee(List<Employee> employeeList, int employeeNumber, TimeStamp timeWorked)
        {

            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].EmployeeNumber == (employeeNumber))
                {
                    employeeList[i].TimeWorked = TimeStamp.AddTwoTimeStamps(employeeList[i].TimeWorked, timeWorked);

                    employeeList[i].Payment = employeeList[i].TimeWorked.Hours * employeeList[i].HourlyRate;

                    totalPayment += employeeList[i].Payment;

                    break;
                }
            }
        }

        public static void printReport(List<Employee> employeeList, string fileName)
        {


            StreamWriter streamWriter = null;
            StringBuilder AllLines = new StringBuilder();

            AllLines.AppendLine("Emp #  Last Name   First Name  Time Worked Hourly Wage Pay");
            AllLines.AppendLine("-----  ---------   ----------  ----------- ----------- ----------");
            try
            {

                foreach (Employee employee in employeeList)
                {
                    AllLines.AppendLine(employee.ToString());
                }
             

                AllLines.AppendLine("Total Time Worked = " + totalTimeWorked.ToString());

                AllLines.AppendLine("Total Pay = " + totalPayment.ToString());
                 

                using (streamWriter = new StreamWriter(fileName, true))
                {
                    streamWriter.WriteLine(AllLines.ToString());
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        static void PrintCustomerList(List<Employee> list)
        {

        }
    }

    class Employee
    {
        private int _employeeNumber;
        private string _lastName;
        private string _firstName;
        private double _hourlyRate;
        private TimeStamp _timeWorked;
        private double _payment;


        public int EmployeeNumber
        {
            get
            {
                return _employeeNumber;
            }
            set
            {
                _employeeNumber = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public double HourlyRate
        {
            get
            {
                return _hourlyRate;
            }
            set
            {
                _hourlyRate = value;
            }
        }


        public TimeStamp TimeWorked
        {
            get
            {
                return _timeWorked;
            }
            set
            {
                _timeWorked = value;
            }
        }

        public double Payment
        {
            get
            {
                return _payment;
            }
            set
            {
                _payment = value;
            }
        }

//Methods
//Constructors
public Employee(int _employeeNumber, string _lastName, string _firstName, double _hourlyRate)
        {
            EmployeeNumber = _employeeNumber;
            LastName = _lastName;
            FirstName = _firstName;
            HourlyRate = _hourlyRate;
            _timeWorked = new TimeStamp();
        }

        public Employee(int _employeeNumber, TimeStamp _timeStamp)
        {
            EmployeeNumber = _employeeNumber;
            TimeWorked = _timeStamp;
        }

        public override string ToString()
        {
            return String.Format("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", EmployeeNumber, LastName, FirstName, TimeWorked, HourlyRate, Payment);

        }
    }

    class TimeStamp
    {

        //Fields - Properties
        private int _hours;
        private int _minutes;
        private int _seconds;

        private const int MIN_SECONDS = 0;
        private const int MAX_SECONDS = 59;
        private const int MIN_MINUTES = 0;
        private const int MAX_MINUTES = 59;
        private const int MIN_HOURS = 0;

        public int Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                if (value < MIN_HOURS)
                {
                    throw new ArgumentException("Hours must be more than 0", "Hours");
                }

                _hours = value;
            }
        }

        public int Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                if (value < MIN_MINUTES || value > MAX_MINUTES)
                {
                    throw new ArgumentException("Minutes must be in the range of 0 to 59", "Minutes");
                }

                _minutes = value;

            }
        }

        public int Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                if (value < MIN_SECONDS || value > MAX_SECONDS)
                {
                    throw new ArgumentException("Seconds must be in the range of 0 to 59", "Seconds");
                }

                _seconds = value;

            }
        }

        //Methods
        //Constructors
        public TimeStamp()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }

        public TimeStamp(int _hours, int _minutes, int _seconds)
        {
            Hours = _hours;
            Minutes = _minutes;
            Seconds = _seconds;
        }

        //Other Methods
        public TimeStamp ConvertFromSeconds(int SecondsToConvert)
        {
            Hours = SecondsToConvert / 3600;
            Minutes = (SecondsToConvert % 3600) / 60;
            Seconds = (SecondsToConvert % 3600) % 60;

            return this;

        }

        public int ConvertToSeconds()
        {
            return (Hours * 3600) + (Minutes * 60) + Seconds;

        }

        public void AddSeconds(int TheSeconds)
        {

            ConvertFromSeconds(ConvertToSeconds() + TheSeconds);
        }

        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", Hours, Minutes, Seconds);

        }

        public void ReadFromConsole()
        {
            Hours = GetPositiveIngter("Please enter number of hours (0..23)", MIN_HOURS, int.MaxValue);
            Minutes = GetPositiveIngter("Please enter number of minutes (0..59)", MIN_MINUTES, MAX_MINUTES);
            Seconds = GetPositiveIngter("Please enter number of seconds (0..59)", MIN_SECONDS, MAX_SECONDS);

        }

        static public TimeStamp AddTwoTimeStamps(TimeStamp TimeStampOne, TimeStamp TimeStampTwo)
        {
            TimeStamp newTimeStamp = new TimeStamp();

            int seconds = TimeStampOne.ConvertToSeconds() + TimeStampTwo.ConvertToSeconds();

            return newTimeStamp.ConvertFromSeconds(seconds);

        }


        private int GetPositiveIngter(string customMessage, int min, int max)
        {

            int input;
            Console.Write("{0}:\t", customMessage);

            while (int.TryParse(Console.ReadLine(), out input) == false || input < min || input > max)
            {
                Console.Write("Error! Please enter a number between {0}..{1}:\t", min, max);

            }

            return input;
        }
    }
}
