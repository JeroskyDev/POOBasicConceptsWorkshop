using System.Reflection.Metadata.Ecma335;
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
            Hour = 0;
            Minute = 0;
            Second = 0;
            Millisecond = 0;
        }
        
        //overloads
        public Time(int hour)
        {
            Hour = hour;
        }

        public Time (int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public Time (int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
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
        public override string ToString()
        {
            string tt = Hour < 12 ? "AM" : "PM";
            int hourToDisplay = Hour; //temporal local variable to not change the whole Hour property
            if (hourToDisplay == 0)
            {
                hourToDisplay = 0;
                tt = "AM";
            }
            else if (hourToDisplay >= 1 && hourToDisplay <= 11)
            {
                tt = "AM";
            }
            else if (hourToDisplay >= 13 && hourToDisplay <= 23)
            {
                hourToDisplay -= 12;
                tt = "PM";
            }
            else
            {
                tt = "PM";
            }
            return $"{hourToDisplay:00}:{Minute:00}:{Second:00}.{Millisecond:000} {tt}"; 
            
        }

        public object Add(Time time)
        {
            //do summation component by component and with carry
            int milliseconds = Millisecond + time.Millisecond;
            int seconds = 0;
            int minutes = 0;
            int hours = 0;
            int carrySeconds = milliseconds / 1000; //seconds to add if milliseconds were more than 999
            
            seconds = Second + time.Second + carrySeconds;
            int carryMinutes = seconds / 60;
            milliseconds = milliseconds % 1000; //milliseconds remaining if higher than 999 (it gets turned into seconds)

            minutes = Minute + time.Minute + carryMinutes;
            int carryHours = minutes / 60;
            seconds = seconds % 60;

            hours = Hour + time.Hour + carryHours;
            minutes = minutes % 60;

            hours = hours % 24;
            
            return new Time(hours, minutes, seconds, milliseconds);
        }

        public bool IsOtherDay(Time time)
        {
            int milliseconds = Millisecond + time.Millisecond;
            int seconds = 0;
            int minutes = 0;
            int hours = 0;
            int carrySeconds = milliseconds / 1000; //seconds to add if milliseconds were more than 999

            seconds = Second + time.Second + carrySeconds;
            int carryMinutes = seconds / 60;
            milliseconds = milliseconds % 1000; //milliseconds remaining if higher than 999 (it gets turned into seconds)

            minutes = Minute + time.Minute + carryMinutes;
            int carryHours = minutes / 60;
            seconds = seconds % 60;

            hours = Hour + time.Hour + carryHours;
            minutes = minutes % 60;

            if (hours > 23) return true;
            else return false;
        }

        public int ToMinutes()
        {
            int minutesToDisplay = 0;
            ValidMinute(Minute);
            
            //do calculations 
            minutesToDisplay = ToMilliseconds() / 60000;

            return minutesToDisplay;
        }

        public int ToSeconds()
        {
            int secondsToDisplay = 0;
            ValidSecond(Second);
            
            //do calculations 
            secondsToDisplay = ToMilliseconds() / 1000;

            return secondsToDisplay;
        }

        public int ToMilliseconds()
        {
            int millisecondsToDisplay = 0;

            //constants for conversion
            int hourOnMilliseconds = (60 * 60 * 1000);
            int minuteOnMilliseconds = (60 * 1000);
            int secondOnMilliseconds = 1000;

            ValidMillisecond(Millisecond);
            
            //do calculations
            millisecondsToDisplay = (Hour * hourOnMilliseconds) + (Minute * minuteOnMilliseconds) + (Second * secondOnMilliseconds) + Millisecond;

            return millisecondsToDisplay;
        }

        //private methods
        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentException($"The hour: {hour}, is not valid.");
            }
            return hour;
        }

        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException($"The minute: {minute}, is not valid.");
            }
            return minute;
        }

        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentException($"The second: {second}, is not valid.");
            }
            return second;
        }

        private int ValidMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentException($"The millisecond: {millisecond}, is not valid.");
            }
            return millisecond;
        }
    }
}
