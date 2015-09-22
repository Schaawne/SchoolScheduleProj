using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolScheduleProj_Lib;

namespace SchoolScheduleProj_UnitTests
{
    /**
    *<summary>
    * Student Class Unit Tests
    *</summary>
    */
    [TestClass]
    public class StudentUnitTests
    {
        /**
        *<summary>
        * StudentUnitTests Constructor
        *</summary>
        */
        public StudentUnitTests()
        {
            //Empty Constructor  
        }

        /**
        *<summary>
        * T001_Student - Student Constructors
        *</summary>
        */
        [TestCategory("CI"), TestMethod]
        public void T001_Student_Constructors()
        {
            String firstName1 = "John", lastName1 = "Doe";

            //Empty Constructor
            Student emptyStudent = new Student();
            Assert.AreEqual<string>("", emptyStudent.FirstName);
            Assert.AreEqual<string>("", emptyStudent.LastName);

            //Basic Constructor
            Student basicStudent = new Student(firstName1, lastName1);
            Assert.AreEqual<string>(firstName1, basicStudent.FirstName);
            Assert.AreEqual<string>(lastName1, basicStudent.LastName);
            Assert.AreEqual<string>(firstName1 + " " + lastName1, basicStudent.Name);
        }

        /**
        *<summary>
        * T002_Student - AddClass methods
        *</summary>
        */
        [TestCategory("CI"), TestMethod]
        public void T002_Student_AddClass()
        {
            /** Method Locals */
            //Miscellaneous
            bool result = false;
            //Student object
            Student nominalTestStudent = new Student("John", "Doe");
            Student failTestStudent = new Student("Jane", "Doe");
            Student scheduleConflictStudent = new Student("Steve", "Doe");
            Student nameConflictStudent = new Student("Sally", "Doe");
            //Class names
            String[] classNames =
            {
                "Homeroom",
                "Reading",
                "Math",
                "Social Studies",
                "Recess"
            };
            //Class start times Tuples
            Tuple<int, int>[] startTimes =
            {
                new Tuple<int, int>( 8,  0),
                new Tuple<int, int>( 9,  0),
                new Tuple<int, int>( 9, 55),
                new Tuple<int, int>(10, 40),
                new Tuple<int, int>(11, 30)
            };
            //Class start time TimeHHMM
            TimeHHMM[] classStartTimes =
            {
                new TimeHHMM(startTimes[0].Item1, startTimes[0].Item2),
                new TimeHHMM(startTimes[1].Item1, startTimes[1].Item2),
                new TimeHHMM(startTimes[2].Item1, startTimes[2].Item2),
                new TimeHHMM(startTimes[3].Item1, startTimes[3].Item2),
                new TimeHHMM(startTimes[4].Item1, startTimes[4].Item2)
            };
            //Class end times Tuples
            Tuple<int, int>[] endTimes =
            {
                new Tuple<int, int>( 8, 50),
                new Tuple<int, int>( 9, 45),
                new Tuple<int, int>(10, 30),
                new Tuple<int, int>(11, 30),
                new Tuple<int, int>(12, 15)
            };
            //Class end time TimeHHMM
            TimeHHMM[] classEndTimes =
            {
                new TimeHHMM(endTimes[0].Item1, endTimes[0].Item2),
                new TimeHHMM(endTimes[1].Item1, endTimes[1].Item2),
                new TimeHHMM(endTimes[2].Item1, endTimes[2].Item2),
                new TimeHHMM(endTimes[3].Item1, endTimes[3].Item2),
                new TimeHHMM(endTimes[4].Item1, endTimes[4].Item2)
            };

            /** Nominal AddClass() Scenarios */
            result = nominalTestStudent.AddClass(classNames[0], classStartTimes[0], classEndTimes[0]);
            Assert.IsTrue(result);

            result = nominalTestStudent.AddClass(classNames[1], startTimes[1].Item1, startTimes[1].Item2, 50);
            Assert.IsTrue(result);

            result = nominalTestStudent.AddClass(classNames[2], startTimes[2].Item1, startTimes[2].Item2, endTimes[2].Item1, endTimes[2].Item2);
            Assert.IsTrue(result);

            result = nominalTestStudent.AddClass(classNames[3], classStartTimes[3], 50);
            Assert.IsTrue(result);

            result = nominalTestStudent.AddClass(new ScheduleItem(classNames[4], classStartTimes[4], classEndTimes[4]));
            Assert.IsTrue(result);

            /** Failure AddClass() Scenarios */
            result = failTestStudent.AddClass("", classStartTimes[0], classEndTimes[0]);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[0], null, classEndTimes[0]);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[0], classStartTimes[0], null);
            Assert.IsFalse(result);

            result = failTestStudent.AddClass("", startTimes[1].Item1, startTimes[1].Item2, 50);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[1], -1, startTimes[1].Item2, 50);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[1], 24, startTimes[1].Item2, 50);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[1], startTimes[1].Item1, -1, 50);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[1], startTimes[1].Item1, 60, 50);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[1], startTimes[1].Item1, startTimes[1].Item2, 0);
            Assert.IsFalse(result);

            result = failTestStudent.AddClass("", startTimes[2].Item1, startTimes[2].Item2, endTimes[2].Item1, endTimes[2].Item2);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[2], -1, startTimes[2].Item2, endTimes[2].Item1, endTimes[2].Item2);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[2], 24, startTimes[2].Item2, endTimes[2].Item1, endTimes[2].Item2);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[2], startTimes[2].Item1, -1, endTimes[2].Item1, endTimes[2].Item2);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[2], startTimes[2].Item1, 60, endTimes[2].Item1, endTimes[2].Item2);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[2], startTimes[2].Item1, startTimes[2].Item2, -1, endTimes[2].Item2);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[2], startTimes[2].Item1, startTimes[2].Item2, 24, endTimes[2].Item2);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[2], startTimes[2].Item1, startTimes[2].Item2, endTimes[2].Item1, -1);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[2], startTimes[2].Item1, startTimes[2].Item2, endTimes[2].Item1, 60);
            Assert.IsFalse(result);

            result = failTestStudent.AddClass("", classStartTimes[3], 50);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[3], null, 50);
            Assert.IsFalse(result);
            result = failTestStudent.AddClass(classNames[3], classStartTimes[3], 0);
            Assert.IsFalse(result);

            result = failTestStudent.AddClass(null);
            Assert.IsFalse(result);

            /** Schedule conflict failure */
            TimeHHMM overlappingStart = classStartTimes[0] - 15;
            TimeHHMM overlappingEnd = classEndTimes[0] - 15;

            result = scheduleConflictStudent.AddClass(classNames[0], classStartTimes[0], classEndTimes[0]); //Add first class
            Assert.IsTrue(result);

            //Overlap start of class by 15m
            result = scheduleConflictStudent.AddClass("WillFailClass", overlappingStart, classEndTimes[0]);
            Assert.IsFalse(result);
            result = scheduleConflictStudent.AddClass("WillFailClass", overlappingStart.Hour, overlappingStart.Minute, 30);
            Assert.IsFalse(result);
            result = scheduleConflictStudent.AddClass("WillFailClass", overlappingStart.Hour, overlappingStart.Minute, endTimes[0].Item1, endTimes[0].Item2);
            Assert.IsFalse(result);
            result = scheduleConflictStudent.AddClass("WillFailClass", overlappingStart, 30);
            Assert.IsFalse(result);
            result = scheduleConflictStudent.AddClass(new ScheduleItem("WillFailClass", overlappingStart, 30));
            Assert.IsFalse(result);

            //Overlap end of class by 15m
            result = scheduleConflictStudent.AddClass("WillFailClass", overlappingEnd, classEndTimes[0]);
            Assert.IsFalse(result);
            result = scheduleConflictStudent.AddClass("WillFailClass", overlappingEnd.Hour, overlappingEnd.Minute, 15);
            Assert.IsFalse(result);
            result = scheduleConflictStudent.AddClass("WillFailClass", overlappingEnd.Hour, overlappingEnd.Minute, endTimes[0].Item1, endTimes[0].Item2);
            Assert.IsFalse(result);
            result = scheduleConflictStudent.AddClass("WillFailClass", overlappingEnd, 15);
            Assert.IsFalse(result);
            result = scheduleConflictStudent.AddClass(new ScheduleItem("WillFailClass", overlappingEnd, 15));
            Assert.IsFalse(result);

            /** Name conflict failure */
            ScheduleItem duplicateClass = new ScheduleItem(classNames[0], classEndTimes[0] + 30, 30);

            //Add valid class to schedule
            result = nameConflictStudent.AddClass(classNames[0], classStartTimes[0], classEndTimes[0]);
            Assert.IsTrue(result);

            //Try to add duplicate class (same name, different time)
            result = nameConflictStudent.AddClass(duplicateClass);
            Assert.IsFalse(result);
        }

        /**
        *<summary>
        * T003_Student - GetClass
        *</summary>
        */
        [TestCategory("CI"), TestMethod]
        public void T003_Student_GetClass()
        {
            bool result = false;

            /** Classes for test */
            ScheduleItem class1 = new ScheduleItem("Class1", new TimeHHMM(8, 30), 30);
            ScheduleItem class2 = new ScheduleItem("Class2", new TimeHHMM(9, 30), 30);
            ScheduleItem foundClass;
            /** Student for test */
            Student testStudent = new Student("Jane", "Doe");

            //Build basic, valid schedule
            result = testStudent.AddClass(class1);
            Assert.IsTrue(result);
            result = testStudent.AddClass(class2);
            Assert.IsTrue(result);
            Assert.AreEqual<int>(2, testStudent.StudentSchedule.Count);

            //Nominal GetClass
            foundClass = testStudent.GetClass(class1.ItemName);
            Assert.AreEqual<ScheduleItem>(class1, foundClass);
            foundClass = testStudent.GetClass(class2.ItemName);
            Assert.AreEqual<ScheduleItem>(class2, foundClass);

            //Failed GetClass
            foundClass = testStudent.GetClass("Class3");
            Assert.AreEqual<object>(null, (object)foundClass);
        }

        /**
        *<summary>
        * T004_Student - Reschedule
        *</summary>
        */
        [TestCategory("CI"), TestMethod]
        public void T004_Student_Reschedule()
        {
            bool result = false;

            //Classes for test
            ScheduleItem class1 = new ScheduleItem("Class1", new TimeHHMM(8, 30), 30);
            ScheduleItem class2 = new ScheduleItem("Class2", new TimeHHMM(9, 30), 30);
            ScheduleItem class2moved = new ScheduleItem("Class2", new TimeHHMM(12, 30), 30); 
            //Student for test
            Student testStudent = new Student("Jane", "Doe");

            //Build basic, valid schedule
            result = testStudent.AddClass(class1);
            Assert.IsTrue(result);
            result = testStudent.AddClass(class2);
            Assert.IsTrue(result);
            Assert.AreEqual<int>(2, testStudent.StudentSchedule.Count);

            /** Nominal reschedule */
            result = testStudent.Reschedule(class2.ItemName, new TimeHHMM(12, 30));
            Assert.IsTrue(result);
            Assert.AreEqual<int>(2, testStudent.StudentSchedule.Count); //Still only 2 classes in schedule

            /** Conflict reschedule */
            result = testStudent.Reschedule(class2.ItemName, new TimeHHMM(8, 45));
            Assert.IsFalse(result);
            result = testStudent.GetClass(class1.ItemName) == class1;
            Assert.IsTrue(result); //Class1 hasn't moved
            result = testStudent.GetClass(class2moved.ItemName) == class2moved;
            Assert.IsTrue(result); //Class2 is still in modified location
        }
    }
}
