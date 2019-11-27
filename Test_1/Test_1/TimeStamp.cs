using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
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
