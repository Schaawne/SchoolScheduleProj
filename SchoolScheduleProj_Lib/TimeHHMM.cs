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
            TimeSpan lhsTS, rhsTS, returnTS;

            //Check for nulls
            if((null == (object) lhs) || (null == (object) rhs))
            {
                return new TimeSpan();
            }

            //Represent operands as TimeSpans from midnight
            lhsTS = new TimeSpan(lhs.Hour, lhs.Minute, 0);
            rhsTS = new TimeSpan(rhs.Hour, rhs.Minute, 0);
            returnTS = lhsTS - rhsTS;

            //TimeHHMM subtraction represents time span from rhs to lhs (always positive)
            if(0.0 > returnTS.TotalMinutes)
            {
                returnTS += new TimeSpan(24, 0, 0); //Wrap by 24h
            }

            return returnTS;
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
            TimeSpan lhsTS, rhsTS, sumTS;

            //Check for null
            if(null == (object)lhs)
            {
                return new TimeHHMM(0, 0);
            }

            //Represent operands as TimeSpans from midnight
            lhsTS = new TimeSpan(lhs.Hour, lhs.Minute, 0);
            rhsTS = new TimeSpan(0, addMinutes, 0);
            sumTS = lhsTS + rhsTS;

            //Check for wrap forward across midnight
            if(24.0 <= sumTS.TotalHours)
            {
                sumTS -= new TimeSpan(24, 0, 0);
            }

            //Check for wrap backwards aross midnight
            if(0.0 > sumTS.TotalHours)
            {
                sumTS += new TimeSpan(24, 0, 0);
            }

            //Return new TimeHHMM object
            return new TimeHHMM(sumTS.Hours, sumTS.Minutes);
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