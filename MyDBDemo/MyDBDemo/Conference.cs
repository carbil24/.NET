using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDBDemo
{
    public class Conference
    {
        private int _id;
        private string _confName;
        private string _contactNumber;
        private DateTime _date;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string ConfName
        {
            get
            {
                return _confName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Conference Name Cannot be null or empty", "ConfName");
                _confName = value;
            }
        }

        public string ContactNumber
        {
            get
            {
                return _contactNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Contact Number Cannot be null or empty", "ContactNumber");
                _contactNumber = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new ArgumentException("Date Cannot be null or empty", "Date");
                _date = value;
            }
        }

        public string AllData
        {
            get
            {
                return string.Format($"{ConfName},{ContactNumber},{Date}");
            }
            set
            {
                //string comma seperated and set the fields of the visitor
                string[] allData = value.Split(',');
                try
                {
                    ConfName = allData[0];
                    ContactNumber = allData[1];
                    Date = DateTime.Parse(allData[2]);
                }
                catch (Exception ex)
                {
                    throw new Exception("All Data Property value not valid " + ex.Message);
                }
            }
        }

        public override string ToString()
        {
            return string.Format($"{ConfName}| {ContactNumber} | {Date}");
        }

        public string FullInfo
        {
            get
            {
                return string.Format(
                "{0,-20}" + ConfName + "\n" +
                "{1,-20}" + ContactNumber + "\n" +
                "{2,-30}" + Date.ToShortDateString() + "\n",
                "Conference Name:", "Contact Number:", "Date:");
            }
        }
    }
}
