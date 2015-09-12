using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            get
            {
                //return current size of the Dictionary
                return (UIntPtr) studentList.Count;
            }
        }

        /**
        * StudentList()
        *
        * StudentList Empty Constructor.
        */
        public StudentDictionary()
        {
            studentList = new Dictionary<String, Student>();
        }

        /**
        * AddStudent(newStudent)
        *
        * Add provided Student object to the Dictionary.
        */
        public bool AddStudent(Student newStudent)
        {
            bool returnVal = false;

            //Check that both portions of name are populated
            if ((0 < newStudent.firstName.Length) && (0 < newStudent.lastName.Length))
            {
                //Confirm Student isn't already in Dictionary
                if (!studentList.ContainsKey(newStudent.name))
                {
                    //Add the Student to dictionary
                    try
                    {
                        studentList.Add(newStudent.name, newStudent);
                        returnVal = true;
                    }
                    catch (Exception e)
                    {
                        //Handle exceptions?
                        Debug.WriteLine(e);
                    }
                }
            }

            return returnVal;
        }

        /**
        * GetStudent(studentName)
        *
        * Get Student from Dictionary by Name
        */
        public Student GetStudent(String studentName)
        {
            Student foundStudent = null;

            //Attempt to get the Student by name
            studentList.TryGetValue(studentName, out foundStudent);
            
            //foundStudent is either still null or now contains the student found
            return foundStudent;
        }

        /**
        * EmptyList()
        *
        * Remove all Students from the Dictionary.
        */
        public bool EmptyList()
        {
            //Clear the Dictionary
            studentList.Clear();

            return true;
        }

        /**
        * GetStudents()
        *
        * Retrieve a List object containing all the Student objects
        */
        public List<Student> GetStudents()
        {
            try
            {
                return studentList.Values.ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /**
        * RemoveStudent(oldStudent)
        *
        * Remove Student matching provided Student from the Dictionary.
        */
        public bool RemoveStudent(Student oldStudent)
        {
            bool returnVal = false;

            //Check that both portions of name are populated
            if ((0 < oldStudent.firstName.Length) && (0 < oldStudent.lastName.Length))
            {
                //Confirm Student is already in Dictionary
                returnVal = studentList.Remove(oldStudent.name);
            }

            return returnVal;
        }
    }
}
