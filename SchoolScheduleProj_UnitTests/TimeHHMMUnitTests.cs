using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolScheduleProj_Lib;

namespace SchoolScheduleProj.Tests
{
    /**
    * SchoolScheduleProj_Lib TimeHHMM Class Tests
    *
    * Test Class for TimeHHMM
    */
    [TestClass]
    public class TimeHHMMUnitTests
    {
        /**
        * T001_TimeHHMM
        *
        * Test TimeHHMM Constructors
        */
        [TestCategory("CI"), TestMethod]
        public void T001_TimeHHMM_Constructors()
        {
            int hour = 6;
            int minute = 30;

            /** Nominal Construction */
            TimeHHMM theNominalTime = new TimeHHMM(hour, minute);
            Assert.AreEqual<int>(hour, theNominalTime.Hour);
            Assert.AreEqual<int>(minute, theNominalTime.Minute);

            /** Out of Bounds Construction */
            TimeHHMM theOOBHour = new TimeHHMM(24, minute);
            Assert.AreEqual<int>(0, theOOBHour.Hour);
            Assert.AreEqual<int>(minute, theOOBHour.Minute);

            TimeHHMM theOOBMinute = new TimeHHMM(hour, 60);
            Assert.AreEqual<int>(hour, theOOBMinute.Hour);
            Assert.AreEqual<int>(0, theOOBMinute.Minute);
        }

        /**
        * T002_TimeHHMM
        *
        * Test TimeHHMM string display methods
        */
        [TestCategory("CI"), TestMethod]
        public void T002_TimeHHMM_Display()
        {
            /** Nominal Results */
            TimeHHMM theTestTime = new TimeHHMM(6, 30);
            Assert.AreEqual<string>("06:30", theTestTime.ToString());
        }

        /*
        * T003_TimeHHMM
        *
        * Test bounds on setting Hour and Minute properties
        */
        [TestCategory("CI"), TestMethod]
        public void T003_TimeHHMM_Bounds()
        {
            int hour = 6;
            int minute = 30;

            /** Nominal Sets */
            //Test setting valid Hour
            TimeHHMM theNominalTime = new TimeHHMM(0, 0);
            theNominalTime.Hour = hour;
            Assert.AreEqual<int>(hour, theNominalTime.Hour);
            Assert.AreEqual<int>(0, theNominalTime.Minute);

            //Test setting valid Minute
            theNominalTime.Minute = minute;
            Assert.AreEqual<int>(hour, theNominalTime.Hour);
            Assert.AreEqual<int>(minute, theNominalTime.Minute);

            /** Out of Bounds Sets */
            //Test setting low OOB Hour
            TimeHHMM theOOBTime = new TimeHHMM(hour, minute);
            hour = -1;
            theOOBTime.Hour = hour;
            Assert.AreNotEqual<int>(hour, theOOBTime.Hour);
            Assert.AreEqual<int>(minute, theOOBTime.Minute);

            //Test setting minimum Hour
            hour = 0;
            theOOBTime.Hour = hour;
            Assert.AreEqual<int>(hour, theOOBTime.Hour);
            Assert.AreEqual<int>(minute, theOOBTime.Minute);

            //test setting high OOB Hour
            hour = 24;
            theOOBTime.Hour = hour;
            Assert.AreNotEqual<int>(hour, theOOBTime.Hour);
            Assert.AreEqual<int>(minute, theOOBTime.Minute);

            //Test setting maximum Hour
            hour = 23;
            theOOBTime.Hour = hour;
            Assert.AreEqual<int>(hour, theOOBTime.Hour);
            Assert.AreEqual<int>(minute, theOOBTime.Minute);

            //test setting low OOB minute
            minute = -1;
            theOOBTime.Minute = minute;
            Assert.AreEqual<int>(hour, theOOBTime.Hour);
            Assert.AreNotEqual<int>(minute, theOOBTime.Minute);

            //Test setting minimum Minute
            minute = 0;
            theOOBTime.Minute = minute;
            Assert.AreEqual<int>(hour, theOOBTime.Hour);
            Assert.AreEqual<int>(minute, theOOBTime.Minute);

            //test setting hight OOB minute
            minute = 60;
            theOOBTime.Minute = minute;
            Assert.AreEqual<int>(hour, theOOBTime.Hour);
            Assert.AreNotEqual<int>(minute, theOOBTime.Minute);

            //Test setting maximum Minute
            minute = 59;
            theOOBTime.Minute = minute;
            Assert.AreEqual<int>(hour, theOOBTime.Hour);
            Assert.AreEqual<int>(minute, theOOBTime.Minute);
        }

        /**
        * T004_TimeHHMM
        *
        * Test difference calculations
        */
        [TestCategory("CI"), TestMethod]
        public void T004_TimeHHMM_Difference()
        {
            //Time objects for testing
            int hour1 = 12;
            int minute1 = 0;
            int hour2 = 0;
            int minute2 = 0;
            double length = Math.Abs(hour1 - hour2) * 60.0 + (minute1 - minute2);
            TimeHHMM time1 = new TimeHHMM(hour1, minute1);
            TimeHHMM time2 = new TimeHHMM(hour2, minute2);
            TimeSpan timeDiff;

            /** Nominal subtraction */
            timeDiff = time1 - time2;
            Assert.AreEqual<double>(length, timeDiff.TotalMinutes);

            /** Reverse subtraction */
            timeDiff = time2 - time1;
            Assert.AreEqual<double>(-1.0 * length, timeDiff.TotalMinutes);

            /** Identical subtraction */
            timeDiff = time1 - time1;
            Assert.AreEqual<double>(0.0, timeDiff.TotalMinutes);
        }

        /**
        * T005_TimeHHMM
        *
        * Test addition calculations
        */
        [TestCategory("CI"), TestMethod]
        public void T005_TimeHHMM_Addition()
        {
            //TimeHHMM + TimeSpan
            TimeHHMM theTestStart = new TimeHHMM(9, 0); //9am
            TimeSpan theTestSpan = new TimeSpan(12, 45, 0); //12hr 45m
            TimeHHMM theNewTime = theTestStart + theTestSpan;
            Assert.AreEqual<int>(21, theNewTime.Hour);
            Assert.AreEqual<int>(45, theNewTime.Minute);

            //Truncation to minutes
            TimeSpan theTestSpan2 = new TimeSpan(12, 45, 45);
            TimeHHMM theNewTime2 = theTestStart + theTestSpan2;
            Assert.AreEqual<TimeHHMM>(theNewTime, theNewTime2);

            //TimeHHMM + minutes
            TimeHHMM theNewTime3 = theTestStart + 35;
            Assert.AreEqual<int>(9, theNewTime3.Hour);
            Assert.AreEqual<int>(35, theNewTime3.Minute);
        }
    }
}
