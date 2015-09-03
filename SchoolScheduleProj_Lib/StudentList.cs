using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public class StudentList
    {
        /** Dictionary of Students keyed by full name */
        private Dictionary<String, Student> studentList;

        /**
        * StudentList()
        *
        * StudentList Empty Constructor
        */
        public StudentList()
        {
            studentList = new Dictionary<string, Student>();
        }

        /**
        * AddStudent(newStudent)
        *
        * Add provided Student object to the Dictionary
        */
        public bool AddStudent(Student newStudent)
        {
            return false;
        }
    }
}
