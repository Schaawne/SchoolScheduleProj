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

        /** Implement subtraction from TimeHHMM objects */
        public static TimeSpan operator -(TimeHHMM lhs, TimeHHMM rhs)
        {
            //Check for nulls
            if((null == (object) lhs) || (null == (object) rhs))
            {
                return new TimeSpan();
            }
            return new TimeSpan(lhs.Hour - rhs.Hour, lhs.Minute - rhs.Minute, 0);
        }
        public static TimeHHMM operator -(TimeHHMM lhs, int subtractMinutes)
        {
            return (lhs + (-1 * subtractMinutes));
        }
        public static TimeHHMM operator -(TimeHHMM lhs, TimeSpan rhs)
        {
            return (lhs - (int)rhs.TotalMinutes);
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
            if(null == (object) rhs)
            {
                return false;
            }

            //Equal if hour and minute are equal
            return ((Hour == rhs.Hour) && (Minute == rhs.Minute));
        }

        /**
        *<summary>
        *Override  ==/!= operators
        *</summary>
        */
        public static bool operator ==(TimeHHMM lhs, TimeHHMM rhs)
        {
            //Check for null
            if((null == (object) lhs) || (null == (object) rhs))
            {
                return false;
            }

            //Use Equals()
            return lhs.Equals(rhs);
        }
        public static bool operator !=(TimeHHMM lhs, TimeHHMM rhs)
        {
            //Check for null
            if((null == (object) lhs) || (null == (object) rhs))
            {
                return false;
            }

            //Use Equals()
            return !lhs.Equals(rhs);
        }

        /**
        *<summary>
        *Override gt/lt operators
        *</summary>
        */
        public static bool operator >(TimeHHMM lhs, TimeHHMM rhs)
        {
            //Check hour
            if(lhs.Hour > rhs.Hour)
            {
                return true;
            }

            //Check minute
            if((lhs.Hour == rhs.Hour) && (lhs.Minute > rhs.Minute))
            {
                return true;
            }

            return false;
        }
        public static bool operator <(TimeHHMM lhs, TimeHHMM rhs)
        {
            //Check hour
            if (lhs.Hour < rhs.Hour)
            {
                return true;
            }

            //Check minute
            if ((lhs.Hour == rhs.Hour) && (lhs.Minute < rhs.Minute))
            {
                return true;
            }

            return false;
        }

        /**
        *<summary>
        *Override ge/le operators
        *</summary>
        */
        public static bool operator >=(TimeHHMM lhs, TimeHHMM rhs)
        {
            //Check equality
            if(lhs == rhs)
            {
                return true;
            }

            //Check gt
            return (lhs > rhs);
        }
        public static bool operator <=(TimeHHMM lhs, TimeHHMM rhs)
        {
            //Check equality
            if(lhs == rhs)
            {
                return true;
            }

            //Check lt
            return (lhs < rhs);
        }

        /**
        *<summary>
        *Calculates hash code for TimeHHMM
        *</summary>
        */
        public override int GetHashCode()
        {
            int hashSeed = "TimeHHMM".GetHashCode(); //Use class name as seed hash code
            int hashGain = hashSeed / 2; //Use seed/2 as gain
            int hash;

            //Calculate hash code = seed + sum(code * gain + propertyHashCode)
            hash = hashSeed;
            hash = hash * hashGain + Hour.GetHashCode();
            hash = hash * hashGain + Minute.GetHashCode();

            return hash;
        }
    }
}