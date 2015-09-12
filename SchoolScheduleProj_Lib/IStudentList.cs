using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public interface IStudentList
    {
        /**
        * Fields
        */
        //Size of Student List
        UIntPtr size
        {
            get;
        }

        /**
        * Methods
        */
        //Add Student to the Student List
        bool AddStudent(Student newStudent);
        //Retrieve Student from Student List by name
        Student GetStudent(String studentName);
        //Clear Student List
        bool EmptyList();
        //Get Student List as List object
        List<Student> GetStudents();
        //Remove Student from Student List
        bool RemoveStudent(Student oldStudent);
    }
}
