﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public class Student : IPerson
    {
        /** Schedule as List */
        private List<ScheduleItem> studentSchedule;
        public List<ScheduleItem> StudentSchedule
        {
            get
            {
                return studentSchedule;
            }
        }

        /** Student's first name */
        public String FirstName
        {
            get;
            set;
        }

        /** Student's last name */
        public String LastName
        {
            get;
            set;
        }

        /** Student's full name */
        public String Name => FirstName + " " + LastName;

        /**
        * Student()
        *
        * Student empty constructor
        */
        public Student()
        {
            FirstName = "";
            LastName = "";
            studentSchedule = new List<ScheduleItem>();
        }

        /**
        * Student(FirstName, LastName)
        *
        * Student full name constructor
        */
        public Student(String firstName, String lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            studentSchedule = new List<ScheduleItem>();
        }

        /**
        *<summary>
        *With Name, Start hour/minute, and End hour/minute
        *</summary>
        */
        public bool AddClass(string className, int startHour, int startMinute, int endHour, int endMinute)
        {
            //Validate className (non-empty String)
            if ("" == className)
            {
                return false;
            }

            //Validate startHour (0-23)
            if ((0 > startHour) || (23 < startHour))
            {
                return false;
            }

            //Validate startMinute (0-59)
            if ((0 > startMinute) || (59 < startMinute))
            {
                return false;
            }

            //Validate endHour (0-23)
            if ((0 > endHour) || (23 < endHour))
            {
                return false;
            }

            //Validate endMinute (0-59)
            if ((0 > endMinute) || (59 < endMinute))
            {
                return false;
            }

            //Create the ScheduleItem
            ScheduleItem newClass = new ScheduleItem(className, new TimeHHMM(startHour, startMinute), new TimeHHMM(endHour, endMinute));
            if (scheduleConflict(newClass))
            {
                return false;
            }

            //Check that new class isn't same name as any existing
            if (nameConflict(newClass))
            {
                return false;
            }

            //Add class to schedule
            studentSchedule.Add(newClass);
            return true;
        }

        /**
        *<summary>
        *With Name, Start hour/minute, and Duration
        *</summary>
        */
        public bool AddClass(string className, int startHour, int startMinute, int minutesDuration)
        {
            //Validate className
            if ("" == className)
            {
                return false;
            }

            //Validate startHour (0-23)
            if ((0 > startHour) || (23 < startHour))
            {
                return false;
            }

            //Validate startMinute (0-59)
            if ((0 > startMinute) || (59 < startMinute))
            {
                return false;
            }

            //Validate minutesDuration
            if (minutesDuration <= 0)
            {
                return false;
            }

            //Check that new class doesn't conflict with any existing
            ScheduleItem newClass = new ScheduleItem(className, startHour, startMinute, minutesDuration);
            if (scheduleConflict(newClass))
            {
                return false;
            }

            //Check that new class isn't same name as any existing
            if (nameConflict(newClass))
            {
                return false;
            }

            //Add class to schedule
            studentSchedule.Add(newClass);
            return true;
        }

        /**
        *<summary>
        *With Name and TimeHHMMs
        *</summary>
        */
        public bool AddClass(string className, TimeHHMM startTime, TimeHHMM endTime)
        {
            //Validate className
            if ("" == className)
            {
                return false;
            }

            //Validate startTime
            if (null == (object)startTime)
            {
                return false;
            }

            //Validate endTime
            if (null == (object)endTime)
            {
                return false;
            }

            //Check that new class doesn't conflict with any existing
            ScheduleItem newClass = new ScheduleItem(className, startTime, endTime);
            if (scheduleConflict(newClass))
            {
                return false;
            }

            //Check that new class isn't same name as any existing
            if (nameConflict(newClass))
            {
                return false;
            }

            //Add class to schedule
            studentSchedule.Add(newClass);
            return true;
        }

        /**
        *<summary>
        *With Name, Start TimeHHMM, and Duration
        *</summary>
        */
        public bool AddClass(string className, TimeHHMM startTime, int minutesDuration)
        {
            //Validate className
            if ("" == className)
            {
                return false;
            }

            //Validate startTime
            if (null == (object)startTime)
            {
                return false;
            }

            //Validate minutesDuration
            if (minutesDuration <= 0)
            {
                return false;
            }

            //Check that new class doesn't conflict with any existing
            ScheduleItem newClass = new ScheduleItem(className, startTime, minutesDuration);
            if (scheduleConflict(newClass))
            {
                return false;
            }

            //Check that new class isn't same name as any existing
            if (nameConflict(newClass))
            {
                return false;
            }

            //Add class to schedule
            studentSchedule.Add(newClass);
            return true;
        }

        /**
        *<summary>
        *With ScheduleItem
        *</summary>
        */
        public bool AddClass(ScheduleItem newClass)
        {
            //Validate newClass
            if(null == (object)newClass)
            {
                return false;
            }

            //Check that new class doesnt conflict with any existing
            if(scheduleConflict(newClass))
            {
                return false;
            }

            //Check that new class isn't same name as any existing
            if(nameConflict(newClass))
            {
                return false;
            }

            //Add class to schedule
            studentSchedule.Add(newClass);
            return true;
        }

        /**
        *<summary>
        *Schedule conflict helper (ScheduleItems conflict with ScheduleItems)
        *</summary>
        */
        private bool scheduleConflict(ScheduleItem newClass)
        {
            return (null != (object)studentSchedule.Find(x => x.ConflictsWith(newClass)));
        }

        /**
        *<summary>
        *Schedule conflict helper (ScheduleItems conflict with TimeHHMM as start time)
        *</summary>
        */
        private bool scheduleConflictStart(TimeHHMM time)
        {
            return (null != (object)studentSchedule.Find(x => x.ConflictsWithStart(time)));
        }

        /**
        *<summary>
        *Schedule conflict helper (ScheduleItems conflict with TimeHHMM as end time)
        *</summary>
        */
        private bool scheduleConflictEnd(TimeHHMM time)
        {
            return (null != (object)studentSchedule.Find(x => x.ConflictsWithEnd(time)));
        }

        /**
        *<summary>
        *Name conflict helper
        *</summary>
        */
        private bool nameConflict(ScheduleItem newClass)
        {
            return (null != (object)studentSchedule.Find(x => x.ItemName.Equals(newClass.ItemName)));
        }

        /**
        *<summary>
        *Get Class by name
        *</summary>
        */
        public ScheduleItem GetClass(string name)
        {
            return studentSchedule.Find(x => x.ItemName.Equals(name));
        }

        /**
        *<summary>
        *Reschedules a class to a new start time
        *</summary>
        */
        public bool Reschedule(string className, TimeHHMM newStartTime)
        {
            ScheduleItem foundClass;

            //Check null
            if(null == (object) newStartTime)
            {
                return false;
            }

            //Retrieve named class
            foundClass = GetClass(className);

            //Check that Class was found
            if (null == (object)foundClass)
            {
                return false;
            }

            //Check that new start time doesn't conflict with any existing
            if(scheduleConflictStart(newStartTime))
            {
                return false;
            }

            //Check that new end time doesn't conflict with any existing
            if (scheduleConflictEnd(newStartTime + foundClass.Duration))
            {
                return false;
            }

            return foundClass.Reschedule(newStartTime);
        }

        /**
        *<summary>
        *ToString Override
        *</summary>
        */
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            IComparer<ScheduleItem> comparer = new SchoolScheduleProjComparers();

            builder.AppendFormat("Student: %s\n", Name);
            builder.AppendFormat("---Schedule---\n");

            //Sort schedule and print
            studentSchedule.Sort(comparer);
            foreach (ScheduleItem item in studentSchedule)
            {
                builder.AppendFormat("\t%s\n", item);
            }

            return builder.ToString();
        }
    }
}