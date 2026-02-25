using System.Security.Cryptography.X509Certificates;

namespace TimeLibrary
{
    public class Time : Object
    {
        //fields
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        //constructors
        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }

        //properties
        public int Hour
        {
            get => _hour;
            set => _hour = ValidHour(value);
        }

        public int Minute
        {
            get => _minute;
            set => _minute = ValidMinute(value);
        }

        public int Second
        {
            get => _second;
            set => _second = ValidSecond(value);
        }

        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidMillisecond(value);
        }

        //methods

        //public methods
        public override string ToString() => $"{Hour:00}:{Minute:00}:{Second:00}:{Millisecond:000} tt"; //replace tt with AM or PM

        public object Add(object Time)
        {
            return Time;
        }

        public bool IsOtherDay(object Time)
        {
            return false;
        }

        public int ToMinutes(object Time, int minute)
        {
            return 0;
        }

        public int ToSeconds(object Time, int second)
        {
            return 0;
        }

        public int ToMilliseconds(object Time, int millisecond)
        {
            return 0;
        }

        //private methods
        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 24)
            {
                throw new ArgumentOutOfRangeException(nameof(hour), "Hours MUST be GREATER than 0 or LESS than 24.");
            }
            return hour;
        }

        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute), "Minutes MUST be GREATER than 0 or LESS than 59.");
            }
            return minute;
        }

        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(second), "Seconds MUST be GREATER than 0 or LESS than 59.");
            }
            return second;
        }

        private int ValidMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(millisecond), "Milliseconds MUST be GREATER than 0 or LESS than 999.");
            }
            return millisecond;
        }
    }
}
