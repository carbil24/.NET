using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPFDemo
{
    class Visitor
    {
        //For simplicity of development we will use public properties
        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty", "FullName");
                }
                _fullName = value;
            }
        }
        public string Major { get; set; }
        public string Country { get; set; }
        public Status VisitorStatus { get; set; }
        public bool IsSpeaker { get; set; }
        public DateTime CheckInDate { get; set; }

        public string AllData
        {
            get
            {
                return string.Format($"{FullName}, {Major}, {Country}, {VisitorStatus}, {IsSpeaker}, {CheckInDate}");
            }

            set
            {
                //string comma separated and set the fields of the visitor
                string[] allData = value.Split(',');
                try
                {
                    FullName = allData[0];
                    Major = allData[1];
                    Country = allData[2];

                    VisitorStatus = allData[3] == Status.Proffessional.ToString() ? Status.Proffessional : 
                                    allData[3] == Status.Teacher.ToString() ? Status.Teacher : Status.Student;

                    IsSpeaker = bool.Parse(allData[4]);
                    CheckInDate = DateTime.Parse(allData[5]);

                }
                catch (Exception ex)
                {
                    throw new Exception("All Data Property value not valid" + ex.Message);
                }
            }
        }

        public override string ToString()
        {
            return string.Format($"{FullName} | {VisitorStatus} | " 
                + (IsSpeaker ? "Guest Speaker" : "Spectator"));
        }

        public string FullInfo
        {
            get
            {
                //return string.Format(
                //$"{"Name:",-15} {FullName}\n" +
                //$"{"Major:",-15} {Major}\n" +
                //$"{"Country:",-15} {Country}\n" +
                //$"{"Name:",-15} {VisitorStatus}\n" +
                //$"{"Status:",-15} {IsSpeaker}\n" +
                //$"{"Checkin Date:",-15} {CheckInDate.ToShortDateString()}");

                return string.Format(
                "{0,-20}" + FullName + "\n" +
                "{1,-20}" + Major + "\n" +
                "{2,-20}" + Country + "\n" +
                "{3,-20}" + VisitorStatus + "\n" +
                "{4,-20}" + (IsSpeaker ? "Yes" : "No") + "\n" +
                "{5,-20}" + CheckInDate.ToShortDateString(),
                "Name:", "Major:", "Country:", "Name:", "Status:", "Checkin Date:");
            }
        }
    }

    public enum Status
    {
        Teacher, Student, Proffessional
    }

}
