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
        *
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
    }
}
