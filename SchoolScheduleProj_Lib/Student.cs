using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public class Student : IPerson
    {
        /** Student's first name */
        public String FirstName
        {
            get;
            set;
        }

        /** Student's last name */
        public String LastName
        {
            get;
            set;
        }

        /** Student's full name */
        public String Name => FirstName + " " + LastName;

        /**
        * Student()
        *
        * Student empty constructor
        */
        public Student()
        {
            FirstName = "";
            LastName = "";
        }

        /**
        * Student(FirstName, LastName)
        *
        * Student full name constructor
        */
        public Student(String firstName, String lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
