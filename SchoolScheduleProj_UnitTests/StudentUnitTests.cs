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
            Student overlapTestStudent = new Student("Steve", "Doe");
            //Class names
            String[] classNames =
            {
                "Homeroom",
                "Reading",
                "Math",
                "Social Studies"
            };
            //Class start times Tuples
            Tuple<int, int>[] startTimes =
            {
                new Tuple<int, int>( 8,  0),
                new Tuple<int, int>( 9,  0),
                new Tuple<int, int>( 9, 55),
                new Tuple<int, int>(10, 40)
            };
            //Class start time TimeHHMM
            TimeHHMM[] classStartTimes =
            {
                new TimeHHMM(startTimes[0].Item1, startTimes[0].Item2),
                new TimeHHMM(startTimes[1].Item1, startTimes[1].Item2),
                new TimeHHMM(startTimes[2].Item1, startTimes[2].Item2),
                new TimeHHMM(startTimes[3].Item1, startTimes[3].Item2)
            };
            //Class end times Tuples
            Tuple<int, int>[] endTimes   =
            {
                new Tuple<int, int>( 8, 50),
                new Tuple<int, int>( 9, 45),
                new Tuple<int, int>(10, 30),
                new Tuple<int, int>(11, 30)
            };
            //Class end time TimeHHMM
            TimeHHMM[] classEndTimes =
            {
                new TimeHHMM(endTimes[0].Item1, endTimes[0].Item2),
                new TimeHHMM(endTimes[1].Item1, endTimes[1].Item2),
                new TimeHHMM(endTimes[2].Item1, endTimes[2].Item2),
                new TimeHHMM(endTimes[3].Item1, endTimes[3].Item2)
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

            /** Overlapping classes failure */
            result = overlapTestStudent.AddClass(classNames[0], classStartTimes[0], classEndTimes[0]); //Add first class
            Assert.IsTrue(result);
            result = overlapTestStudent.AddClass("WillFailClass", classEndTimes[0] - 15, 30); //Overlap first class end by 15m
            Assert.IsFalse(result);
            result = overlapTestStudent.AddClass("WillFailClass", classStartTimes[0] - 15, 30); //Overlap first class start by 15m
            Assert.IsFalse(result);
        }
    }
}
