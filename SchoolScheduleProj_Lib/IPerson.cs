using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    public interface IPerson
    {
        /** Person's first name */
        String FirstName
        {
            get;
            set;
        }

        /** Person's last name */
        String LastName
        {
            get;
            set;
        }

        /** Person's full name */
        String Name
        {
            get;
        }
    }
}
