using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class TimeSheets
    {
        public TimeSheets()
        {
            DayWorks = new HashSet<DayWorks>();
        }

        public int TimeSheetId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool? Status { get; set; }
        public int EmployeeId { get; set; }
        public int TotalDayOfMonth { get; set; }
        public int TotalDay { get; set; }
        public int TotalWeekendDay { get; set; }
        public int TotalLeaveDay { get; set; }
        public int TotalOffDay { get; set; }
        public int TotalHoliday { get; set; }
        public int TotalNoCheck { get; set; }
        public DateTime UploadTime { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual ICollection<DayWorks> DayWorks { get; set; }
    }
}
