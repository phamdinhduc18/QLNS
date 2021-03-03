using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class DayWorks
    {
        public int DayWorkId { get; set; }
        public DateTime DateOfWork { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string DayInfo { get; set; }
        public bool? Status { get; set; }
        public int TimeSheetId { get; set; }

        public virtual TimeSheets TimeSheet { get; set; }
    }
}
