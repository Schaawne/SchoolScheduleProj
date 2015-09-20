using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleProj_Lib
{
    class SchoolScheduleProjComparers : IComparer<TimeHHMM>, IComparer<ScheduleItem>
    {
        //TimeHHMM Compare
        public int Compare(TimeHHMM item1, TimeHHMM item2)
        {
            //Check nulls
            if((null == (object)item1) || (null == (object)item2))
            {
                return 0;
            }

            return (int) ((item2 - item1).TotalMinutes);
        }

        //ScheduleItem Compare
        public int Compare(ScheduleItem item1, ScheduleItem item2)
        {
            //Check nulls
            if ((null == (object)item1) || (null == (object)item2))
            {
                return 0;
            }

            return (int)((item2.StartTime - item1.StartTime).TotalMinutes);
        }
    }
}
