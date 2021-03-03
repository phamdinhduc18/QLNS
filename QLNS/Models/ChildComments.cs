using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class ChildComments
    {
        public int ChildCommentId { get; set; }
        public string Content { get; set; }
        public DateTime DateComment { get; set; }
        public bool? Status { get; set; }
        public int? CommentId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Comments Comment { get; set; }
        public virtual Employees Employee { get; set; }
    }
}
