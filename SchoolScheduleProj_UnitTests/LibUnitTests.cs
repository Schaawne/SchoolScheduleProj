using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolScheduleProj_Lib;
using System.Diagnostics;

namespace SchoolScheduleProj.Tests
{
    /**
    * SchoolScheduleProj_Lib Use Case Tests
    *
    * Test Class for SchoolScheduleProj_Lib Use Cases
    */
    [TestClass]
    public class SchoolScheduleProj_Lib_UseCases
    {
        /** The Student List */
        private static IStudentList m_studentList = null;

        /**
        * InitializeTests
        * -Run before the first TestMethod
        *
        * Creates common objects for SchoolScheduleProj_Lib_Tests
        */
        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            //Create new Student List if one doesn't exist yet
            if(null == m_studentList)
            {
                //Populate m_studentList with StudentDictionary
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
            
            //Confirm Student was added
            Assert.IsNotNull(m_studentList.GetStudent(testStudent.Name));

            //Create a second, different Student and add them to the list.
            Student testStudent2 = new Student("Jane", "Doe");
            Assert.IsTrue(m_studentList.AddStudent(testStudent2));

            //Confirm 2nd Student was added
            Assert.IsNotNull(m_studentList.GetStudent(testStudent2.Name));
            Assert.AreEqual<UIntPtr>((UIntPtr) 2, m_studentList.size);

            /** Failure End Condition 1 - Student was already in list */
            //Create another new Student with same name as existing
            Student testStudent3 = new Student("John", "Doe");
            Assert.IsFalse(m_studentList.AddStudent(testStudent3));

            /** Failure End Condition 2 - Student information was incomplete */
            //Pass empty Student
            Student testStudent4 = new Student();
            Assert.IsFalse(m_studentList.AddStudent(testStudent4));

            //Pass empty first name
            testStudent4.LastName = "Lewis";
            Assert.IsFalse(m_studentList.AddStudent(testStudent4));

            //Pass empty last name
            testStudent4.FirstName = "Lucky";
            testStudent4.LastName = "";
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
            Assert.IsNotNull(m_studentList.GetStudent(testStudent.Name));

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
            testStudent3.LastName = "Doe";
            Assert.IsFalse(m_studentList.RemoveStudent(testStudent3));

            //Pass empty last name
            testStudent3.FirstName = "John";
            testStudent3.LastName = "";
            Assert.IsFalse(m_studentList.AddStudent(testStudent3));
        }
    }
}
