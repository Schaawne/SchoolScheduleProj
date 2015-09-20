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
        string itemName;
        ScheduleItem standardItem;


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

            //ScheduleItem representing the above
            standardItem = new ScheduleItem(itemName, startTime, endTime);
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
            Assert.AreEqual<int>(duration, theDetailItem1.Duration);

            //Detailed constructor (start/end time objects)
            ScheduleItem theDetailItem2 = new ScheduleItem(itemName, startTime, endTime);
            Assert.AreEqual<string>(itemName, theDetailItem2.ItemName);
            Assert.AreEqual<int>(duration, theDetailItem2.Duration);

            //Detailed constructor (start hour/minute and duration)
            ScheduleItem theDetailItem3 = new ScheduleItem(itemName, startHour, startMinute, duration);
            Assert.AreEqual<string>(itemName, theDetailItem3.ItemName);
            Assert.AreEqual<int>(duration, theDetailItem3.Duration);

            //Detailed constructor (start time and duration)
            ScheduleItem theDetailItem4 = new ScheduleItem(itemName, startTime, duration);
            Assert.AreEqual<string>(itemName, theDetailItem4.ItemName);
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

            //ScheduleItems for Test
            ScheduleItem item1 = new ScheduleItem("Item1", new TimeHHMM(8, 30), 30);
            ScheduleItem item2 = new ScheduleItem("Item2", new TimeHHMM(8, 45), 30);
            ScheduleItem item3 = new ScheduleItem("Item3", new TimeHHMM(9, 0), 30);

            //No Conflict
            result = item1.ConflictsWith(item3);
            Assert.IsFalse(result);
            result = item1.ConflictsWith(null);
            Assert.IsFalse(result);

            //Conflict
            result = item1.ConflictsWith(item2);
            Assert.IsTrue(result);
        }
    }
}
