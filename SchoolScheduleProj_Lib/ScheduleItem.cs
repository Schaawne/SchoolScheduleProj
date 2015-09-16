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
            ItemName = itemName;
            StartTime = new TimeHHMM(0, 0);
            EndTime = new TimeHHMM(0, 0);
        }

        /**
        * ScheduleItem(itemName, startHour, startMinute, endHour, endMinute)
        *
        * ScheduleItem detailed constructor
        */
        public ScheduleItem(String itemName, int startHour, int startMinute, int endHour, int endMinute)
        {
            ItemName = itemName;
            StartTime = new TimeHHMM(startHour, startMinute);
            EndTime = new TimeHHMM(endHour, endMinute);
        }

        /**
        * ScheduleItem(itemName, startTime, endTime)
        *
        * ScheduleItem detailed constructor
        */
        public ScheduleItem(String itemName, TimeHHMM startTime, TimeHHMM endTime)
        {
            ItemName = itemName;
            StartTime = startTime;
            EndTime = endTime;
        }

        /**
        * ScheduleItem(itemName, startHour, startMinute, duration)
        *
        * ScheduleItem detailed constructor
        */
        public ScheduleItem(String itemName, int startHour, int startMinute, int duration)
        {
            int durationHours, durationMinutes;

            ItemName = itemName;
            StartTime = new TimeHHMM(startHour, startMinute);

            durationMinutes = duration % 60;
            durationHours = (duration - durationMinutes) / 60;
            EndTime = StartTime + new TimeSpan(durationHours, durationMinutes, 0); //Ignoring seconds
        }

        /**
        * ScheduleItem(itemName, startTime, duration)
        *
        * ScheduleItem detailed constructor
        */
        public ScheduleItem(String itemName, TimeHHMM startTime, int duration)
        {
            int durationHours, durationMinutes;

            ItemName = itemName;
            StartTime = startTime;

            durationMinutes = duration % 60;
            durationHours = (duration - durationMinutes) / 60;
            EndTime = StartTime + new TimeSpan(durationHours, durationMinutes, 0); //Ignoring seconds
        }
    }
}