using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public interface IStudentList
    {
        bool AddStudent(Student newStudent);
        bool RemoveStudent(Student oldStudent);
        bool EmptyList();
        List<Student> GetStudents();
        UIntPtr size
        {
            get;
        }
    }
}
