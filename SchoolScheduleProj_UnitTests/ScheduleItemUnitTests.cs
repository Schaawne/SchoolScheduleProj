using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolScheduleProj_Lib;

namespace SchoolScheduleProj.Tests
{
    /**
    * SchoolScheduleProj_Lib Schedule Item Class Tests
    *
    * Test Class for ScheduleItem
    */
    [TestClass]
    public sealed class ScheduleItemUnitTests
    {
        /** fields for testing */
        private TimeHHMM startTime, endTime;
        private int startHour, startMinute, endHour, endMinute, duration;
        private string itemName;


        public ScheduleItemUnitTests()
        {
            //Name of item
            itemName = "Homeroom";

            //Start @ 8:15a
            startHour = 8;
            startMinute = 15;
            startTime = new TimeHHMM(startHour, startMinute);

            //End @ 8:45a
            endHour = 8;
            endMinute = 45;
            endTime = new TimeHHMM(endHour, endMinute);
            duration = 30;
        }

        /**
        * T001_ScheduleItem
        *
        * Test ScheduleItem Constructors
        */
        [TestCategory("CI"), TestMethod]
        public void T001_ScheduleItem_Constructors()
        {
            //Basic constructor
            ScheduleItem theBasicItem = new ScheduleItem(itemName);
            Assert.AreEqual<string>(itemName, theBasicItem.ItemName);
            Assert.AreEqual<int>(0, theBasicItem.Duration);

            //Detailed constructor (start/end hours and minutes)
            ScheduleItem theDetailItem1 = new ScheduleItem(itemName, startHour, startMinute, endHour, endMinute);
            Assert.AreEqual<string>(itemName, theDetailItem1.ItemName);
            Assert.AreEqual<TimeHHMM>(startTime, theDetailItem1.StartTime);
            Assert.AreEqual<TimeHHMM>(endTime, theDetailItem1.EndTime);
            Assert.AreEqual<int>(duration, theDetailItem1.Duration);

            //Detailed constructor (start/end time objects)
            ScheduleItem theDetailItem2 = new ScheduleItem(itemName, startTime, endTime);
            Assert.AreEqual<string>(itemName, theDetailItem2.ItemName);
            Assert.AreEqual<TimeHHMM>(startTime, theDetailItem2.StartTime);
            Assert.AreEqual<TimeHHMM>(endTime, theDetailItem2.EndTime);
            Assert.AreEqual<int>(duration, theDetailItem2.Duration);

            //Detailed constructor (start hour/minute and duration)
            ScheduleItem theDetailItem3 = new ScheduleItem(itemName, startHour, startMinute, duration);
            Assert.AreEqual<string>(itemName, theDetailItem3.ItemName);
            Assert.AreEqual<TimeHHMM>(startTime, theDetailItem3.StartTime);
            Assert.AreEqual<TimeHHMM>(endTime, theDetailItem3.EndTime);
            Assert.AreEqual<int>(duration, theDetailItem3.Duration);

            //Detailed constructor (start time and duration)
            ScheduleItem theDetailItem4 = new ScheduleItem(itemName, startTime, duration);
            Assert.AreEqual<string>(itemName, theDetailItem4.ItemName);
            Assert.AreEqual<TimeHHMM>(startTime, theDetailItem4.StartTime);
            Assert.AreEqual<TimeHHMM>(endTime, theDetailItem4.EndTime);
            Assert.AreEqual<int>(duration, theDetailItem4.Duration);
        }

        /**
        * T002_ScheduleItem
        *
        * Test ScheduleItem ConflictsWith()
        */
        [TestCategory("CI"), TestMethod]
        public void T002_ScheduleItem_ConflictsWith()
        {
            bool result = false;

            //New TimeHHMMs for Test
            TimeHHMM time1 = new TimeHHMM(8, 30);
            TimeHHMM time2 = new TimeHHMM(8, 45);
            TimeHHMM time3 = new TimeHHMM(9,  0);

            //ScheduleItems for Test
            ScheduleItem item1 = new ScheduleItem("Item1", time1, 30);
            ScheduleItem item2 = new ScheduleItem("Item2", time2, 30);
            ScheduleItem item3 = new ScheduleItem("Item3", time3, 30); 

            //No Conflict
            result = item1.ConflictsWith(item3);
            Assert.IsFalse(result);
            result = item1.ConflictsWith(null);
            Assert.IsFalse(result);

            //Conflict
            result = item1.ConflictsWith(item2);
            Assert.IsTrue(result);
        }

        /**
        * T003_ScheduleItem
        *
        * Test ScheduleItem ConflictsWithStart()
        */
        [TestCategory("CI"), TestMethod]
        public void T003_ScheduleItem_ConflictsWithStart()
        {
            bool result = false;

            //New TimeHHMMs for Test
            TimeHHMM time1 = new TimeHHMM(8, 30);
            TimeHHMM time2 = new TimeHHMM(8, 45);
            TimeHHMM time3 = new TimeHHMM(9, 0);

            //ScheduleItems for Test
            ScheduleItem item = new ScheduleItem("Item", time1, 30);

            //No Conflict
            result = item.ConflictsWithStart(time3);
            Assert.IsFalse(result);

            //Conflict
            result = item.ConflictsWithStart(time1);
            Assert.IsTrue(result);
            result = item.ConflictsWithStart(time2);
            Assert.IsTrue(result);
        }

        /**
        * T004_ScheduleItem
        *
        * Test ScheduleItem ConflictsWithStart()
        */
        [TestCategory("CI"), TestMethod]
        public void T004_ScheduleItem_ConflictsWithEnd()
        {
            bool result = false;

            //New TimeHHMMs for Test
            TimeHHMM time1 = new TimeHHMM(8, 30);
            TimeHHMM time2 = new TimeHHMM(8, 45);
            TimeHHMM time3 = new TimeHHMM(9,  0);

            //ScheduleItems for Test
            ScheduleItem item = new ScheduleItem("Item", time1, 30);

            //No Conflict
            result = item.ConflictsWithEnd(time1);
            Assert.IsFalse(result);

            //Conflict
            result = item.ConflictsWithEnd(time2);
            Assert.IsTrue(result);
            result = item.ConflictsWithEnd(time3);
            Assert.IsTrue(result);
        }

        /**
        * T005_ScheduleItem
        *
        * Test ScheduleItem Reschedule()
        */
        [TestCategory("CI"), TestMethod]
        public void T005_ScheduleItem_Reschedule()
        {
            bool result = false;

            //TimeHHMMs for Test
            TimeHHMM startTime = new TimeHHMM(8, 30);
            TimeHHMM endTime = new TimeHHMM(9, 0);
            TimeHHMM newTime = new TimeHHMM(9, 30);

            //Nominal Test
            ScheduleItem nominalItem = new ScheduleItem("Nominal Item", startTime, endTime);
            result = nominalItem.Reschedule(newTime);
            Assert.IsTrue(result);
            Assert.AreEqual<TimeHHMM>(newTime, nominalItem.StartTime); //New start time
            Assert.AreNotEqual<TimeHHMM>(endTime, nominalItem.EndTime); //New end time
            Assert.AreEqual<int>((int) (endTime - startTime).TotalMinutes, nominalItem.Duration); //Same duration

            //Failed test
            ScheduleItem failureItem = new ScheduleItem("Failure Item", new TimeHHMM(11, 0), 45);
            result = failureItem.Reschedule(null);
            Assert.IsFalse(result);
        }
    }
}
