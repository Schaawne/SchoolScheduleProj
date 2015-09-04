using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolScheduleProj_Lib;
using System.Collections.Generic;

namespace SchoolScheduleProj.Tests
{
    /**
    * SchoolScheduleProj_Lib_Tests
    *
    * Test Class for SchoolScheduleProj_Lib
    */
    [TestClass]
    public class SchoolScheduleProj_Lib_Tests
    {
        /** The Student List */
        private IStudentList m_studentList = null;

        /**
        * InitializeTests
        * -Run before the first TestMethod
        *
        * Creates common objects for SchoolScheduleProj_Lib_Tests
        */
        [ClassInitialize]
        public void InitializeTests()
        {
            //Create new Student List if one doesn't exist yet
            if(null == m_studentList)
            {
                m_studentList = new StudentDictionary();
            }
        }

        /**
        * CleanupTests
        * -Run after every TestMethod
        *
        * Cleans up common objects for SchoolScheduleProj_Lib_Tests
        */
        [TestCleanup]
        public void CleanupTests()
        {
            m_studentList.EmptyList();
        }

        /**
        * UC001 - Add New Student
        *
        * Tests Main Success Scenarios (1)
        * Tests Failure End Conditions (2)
        */
        [TestCategory("CI"), TestMethod]
        public void UC001_AddNewStudent()
        {
            /** Main Success Scenario */
            //Create a new Student and add it to the list.
            Student testStudent = new Student("John", "Doe");
            Assert.IsTrue(m_studentList.AddStudent(testStudent));

            //Create a second, different Student and add them to the list.
            Student testStudent2 = new Student("Jane", "Doe");
            Assert.IsTrue(m_studentList.AddStudent(testStudent2));

            /** Failure End Condition 1 - Student was already in list */
            //Create another new Student with same name as existing
            Student testStudent3 = new Student("John", "Doe");
            Assert.IsFalse(m_studentList.AddStudent(testStudent3));

            /** Failure End Condition 2 - Student information was incomplete */
            //Pass empty Student
            Student testStudent4 = new Student();
            Assert.IsFalse(m_studentList.AddStudent(testStudent4));

            //Pass empty first name
            testStudent4.lastName = "Lewis";
            Assert.IsFalse(m_studentList.AddStudent(testStudent4));

            //Pass empty last name
            testStudent4.firstName = "Lucky";
            testStudent4.lastName = "";
            Assert.IsFalse(m_studentList.AddStudent(testStudent4));
        }

        /**
        * UC002 - Remove Student
        *
        * Tests Main Success Scenarios (1)
        * Tests Failure End Conditions (2)
        */
        [TestCategory("CI"), TestMethod]
        public void UC002_RemoveStudent()
        {
            /** Main Success Scenario */
            //Create a new Student and add it to the list.
            Student testStudent = new Student("John", "Doe");
            Assert.IsTrue(m_studentList.AddStudent(testStudent));

            //Confirm Student is in list
            List<Student> students = m_studentList.GetStudents();
            Assert.IsNotNull(students);
            students.Exists(s => s.name.Equals(testStudent.name));

            //Remove the desired Student
            Assert.IsTrue(m_studentList.RemoveStudent(testStudent));

            //Confirm Student List is now empty
            Assert.AreEqual<UIntPtr>((UIntPtr) 0, m_studentList.size);

            /** Failure End Condition 1 - Student was not in list */
            //Add the Student to the List again
            Assert.IsTrue(m_studentList.AddStudent(testStudent));

            //Create a new Student with a different name
            Student testStudent2 = new Student("Jane", "Doe");
            Assert.IsFalse(m_studentList.RemoveStudent(testStudent2));

            /** Failure End Condition 2 - Student information was incomplete */
            //Pass empty Student
            Student testStudent3 = new Student();
            Assert.IsFalse(m_studentList.RemoveStudent(testStudent3));

            //Pass empty first name
            testStudent3.lastName = "Doe";
            Assert.IsFalse(m_studentList.RemoveStudent(testStudent3));

            //Pass empty last name
            testStudent3.firstName = "John";
            testStudent3.lastName = "";
            Assert.IsFalse(m_studentList.AddStudent(testStudent3));
        }
    }
}
