using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class RequestApprovals
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string TypeTimeOff { get; set; }
        public string Reason { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string RejectedReason { get; set; }
        public int EmployeeId { get; set; }
        public int ApproverId { get; set; }
        public int UserApprovalId { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
