using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class PositionHistory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Position { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
