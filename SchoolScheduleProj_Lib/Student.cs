using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public class Student
    {
        /** Student's first name */
        public String firstName
        {
            get;
            set;
        }

        /** Student's last name */
        public String lastName
        {
            get;
            set;
        }

        /** Student's full name */
        public String name => firstName + " " + lastName;

        /**
        * Student()
        *
        * Student empty constructor
        */
        public Student()
        {
            firstName = "";
            lastName = "";
        }
        /**
        * Student(firstName, lastName)
        *
        * Student full name constructor
        */
        public Student(String firstName, String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
