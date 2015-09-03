using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolScheduleProj_Lib;

namespace SchoolScheduleProj_UnitTests
{
    [TestClass]
    public class UnitTestingClass
    {
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
            //Create a new, empty student list
            StudentList testStudentList = new StudentList();

            //Create a new Student and add it to the list.
            Student testStudent = new Student("John", "Doe");
            Assert.IsTrue(testStudentList.AddStudent(testStudent));

            //Create a second, different Student and add them to the list.
            Student testStudent2 = new Student("Jane", "Doe");
            Assert.IsTrue(testStudentList.AddStudent(testStudent2));

            /** Failure End Condition 1 - Student was already in list */
            //Create another new Student with same name as existing
            Student testStudent3 = new Student("John", "Doe");
            Assert.IsFalse(testStudentList.AddStudent(testStudent3));

            /** Failure End Condition 2 - Student information was incomplete */
            //Pass empty Student
            Student testStudent4 = new Student();
            Assert.IsFalse(testStudentList.AddStudent(testStudent4));

            //Pass empty first name
            testStudent4.lastName = "Lewis";
            Assert.IsFalse(testStudentList.AddStudent(testStudent4));

            //Pass empty last name
            testStudent4.firstName = "Lucky";
            testStudent4.lastName = "";
            Assert.IsFalse(testStudentList.AddStudent(testStudent4));
        }
    }
}
