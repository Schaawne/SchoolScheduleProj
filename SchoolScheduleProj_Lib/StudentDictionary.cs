using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public class StudentDictionary : IStudentList
    {
        /** Dictionary of Students keyed by full name */
        private Dictionary<String, Student> studentList;

        /** Size property from IStudentList */
        public UIntPtr size
        {
            get;
            private set;
        }

        /**
        * StudentList()
        *
        * StudentList Empty Constructor.
        */
        public StudentDictionary()
        {
            studentList = new Dictionary<string, Student>();
        }

        /**
        * AddStudent(newStudent)
        *
        * Add provided Student object to the Dictionary.
        */
        public bool AddStudent(Student newStudent)
        {
            return false;
        }

        /**
        * RemoveStudent(oldStudent)
        *
        * Remove Student matching provided Student from the Dictionary.
        */
        public bool RemoveStudent(Student oldStudent)
        {
            return false;
        }

        /**
        * EmptyList()
        *
        * Remove all Students from the Dictionary.
        */
        public bool EmptyList()
        {
            return false;
        }

        /**
        * GetStudents()
        *
        * Retrieve a List object containing all the Student objects
        */
        public List<Student> GetStudents()
        {
            return null;
        }
    }
}
