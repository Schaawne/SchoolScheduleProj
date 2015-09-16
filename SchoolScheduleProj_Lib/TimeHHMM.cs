using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public class TimeHHMM
    {
        /** Hour of the time */
        private int _hour;
        public int Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                //Only accept hours between 0 (midnight) and 23 (11pm)
                if((0 <= value) && (24 > value))
                {
                    _hour = value;
                }
            }
        }

        /** Minute of the time */
        private int _minute;
        public int Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                //Only accept values between 0 and 59
                if((0 <= value) && (60 > value))
                {
                    _minute = value;
                }
            }
        }

        /**
        * TimeHHMM Constructor
        *
        * hour - hours component of time
        * minute - minute component of time
        */
        public TimeHHMM(int hour, int minute)
        {
            this.Hour = hour;
            this.Minute = minute;
        }

        /** Implement subtraction of TimeHHMM objects */
        public static TimeSpan operator -(TimeHHMM lhs, TimeHHMM rhs)
        {
            //Check for nulls
            if((null == lhs) || (null == rhs))
            {
                return new TimeSpan();
            }
            return new TimeSpan(lhs.Hour - rhs.Hour, lhs.Minute - rhs.Minute, 0);
        }

        /** Implement addition to TimeHHMM objects */
        public static TimeHHMM operator +(TimeHHMM lhs, TimeSpan rhs)
        {
            //Use overload for minutes offset
            return (lhs + (int)rhs.TotalMinutes);
        }

        public static TimeHHMM operator +(TimeHHMM lhs, int addMinutes)
        {
            //Start with left-hand-side time object
            int returnHour = lhs.Hour;
            int totalMinutes = lhs.Minute + addMinutes;
            int returnMinutes = 0;

            //Check for future hours wrap
            if (0 <= totalMinutes)
            {
                returnMinutes = totalMinutes % 60; //Get remainder minutes
                returnHour += (totalMinutes - returnMinutes) / 60; //Offset hours
            }
            else //past hours wrap
            {
                returnMinutes = totalMinutes % -60; //Get remainder (negative) minutes
                returnHour -= (totalMinutes - returnMinutes) / -60; //Offset hours

                //Handle negative minutes
                if (0 > returnMinutes)
                {
                    returnMinutes += 60; //Offset to positive equivalent
                    returnHour--;  //Offset another hour
                }
            }

            //Return new TimeHHMM object
            return new TimeHHMM(returnHour, returnMinutes);
        }

        /** ToString() override */
        public override string ToString()
        {
            return String.Format("{0:00}:{1:00}", this.Hour, this.Minute);
        }

        /** Equals() methods */
        public override bool Equals(object obj)
        {
            //Check for null
            if(null == obj)
            {
                return false;
            }

            //Check type and use class Equals()
            TimeHHMM rhs = obj as TimeHHMM;
            return Equals(rhs);
        }
        public bool Equals(TimeHHMM rhs)
        {
            //Check for null
            if(null == rhs)
            {
                return false;
            }

            //Equal if hour and minute are equal
            return ((Hour == rhs.Hour) && (Minute == rhs.Minute));
        }
    }
}
