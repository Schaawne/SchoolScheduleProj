using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public class ScheduleItem
    {
        /** Schedule item starting time (HHMM) */
        public TimeHHMM StartTime
        {
            get;
            private set;
        }

        /** Schedule item ending time (HHMM) */
        public TimeHHMM EndTime
        {
            get;
            private set;
        }

        /** Schedule item duration */
        public int Duration
        {
            //Return number of minutes between Start and End as int
            get
            {
                return (int)((EndTime - StartTime).TotalMinutes);
            }
        }

        /** Schedule item name */
        public String ItemName
        {
            get;
            set;
        }

        /**
        * ScheduleItem(itemName)
        *
        * ScheduleItem basic constructor
        */
        public ScheduleItem(String itemName)
        {
            //Use constructor helper
            constructorHelper(itemName, new TimeHHMM(0, 0), new TimeHHMM(0, 0));
        }

        /**
        * ScheduleItem(itemName, startHour, startMinute, endHour, endMinute)
        *
        * ScheduleItem detailed constructor
        */
        public ScheduleItem(String itemName, int startHour, int startMinute, int endHour, int endMinute)
        {
            //Use constructor helper
            constructorHelper(itemName, new TimeHHMM(startHour, startMinute), new TimeHHMM(endHour, endMinute));
        }

        /**
        * ScheduleItem(itemName, startTime, endTime)
        *
        * ScheduleItem detailed constructor
        */
        public ScheduleItem(String itemName, TimeHHMM startTime, TimeHHMM endTime)
        {
            //Use construtor helper
            constructorHelper(itemName, startTime, endTime);
        }

        /**
        * ScheduleItem(itemName, startHour, startMinute, duration)
        *
        * ScheduleItem detailed constructor
        */
        public ScheduleItem(String itemName, int startHour, int startMinute, int duration)
        {
            int durationHours, durationMinutes;
            TimeHHMM startTime = new TimeHHMM(startHour, startMinute);

            durationMinutes = duration % 60;
            durationHours = (duration - durationMinutes) / 60;

            //Use constructor helper
            constructorHelper(itemName, startTime, startTime + new TimeSpan(durationHours, durationMinutes, 0));
        }

        /**
        * ScheduleItem(itemName, startTime, duration)
        *
        * ScheduleItem detailed constructor
        */
        public ScheduleItem(String itemName, TimeHHMM startTime, int duration)
        {
            int durationHours, durationMinutes;

            durationMinutes = duration % 60;
            durationHours = (duration - durationMinutes) / 60;

            //Use constructor helper
            constructorHelper(itemName, startTime, startTime + new TimeSpan(durationHours, durationMinutes, 0));
        }

        /**
        *<summary>
        * Initializes name, start time, and end time
        *</summary>
        */
        private void constructorHelper(string itemName, TimeHHMM startTime, TimeHHMM endTime)
        {
            ItemName = itemName;
            StartTime = startTime;
            EndTime = endTime;
        }

        /**
        *<summary>
        * Checks if two ScheduleItems conflict
        *</summary>
        */
        public bool ConflictsWith(ScheduleItem item2)
        {
            //Check for null
            if(null == (object) item2)
            {
                return false;
            }

            //Check that start time
            if(item2.StartTime >= EndTime)
            {
                return false;
            }
            if(item2.StartTime >= StartTime)
            {
                return true;
            }

            //Check that end time out of range
            if(item2.EndTime <= StartTime)
            {
                return false;
            }
            if(item2.EndTime <= EndTime)
            {
                return true;
            }

            return false;
        }

        /**
        *<summary>
        *ToString Override
        *</summary>
        */
        public override string ToString()
        {
            return String.Format("%s(%s - %s)", ItemName, StartTime.ToString(), EndTime.ToString());
        }
    }
}