using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.DTOs
{
    public class RequestApprovalDTO
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string TypeTimeOff { get; set; }
        public string Reason { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public string RejectedReason { get; set; }
        public int EmployeeId { get; set; }
        public int ApproverId { get; set; }
        public string EmployeeName { get; set; }
        public CreateEmployeeDTO Employee { get; set; }
        public int userApprovalID { get; set; }
    }
}
