using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Comments
    {
        public Comments()
        {
            ChildComments = new HashSet<ChildComments>();
        }

        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime DateComment { get; set; }
        public int? EmployeeId { get; set; }
        public int? BlogId { get; set; }
        public bool? Status { get; set; }

        public virtual Blogs Blog { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual ICollection<ChildComments> ChildComments { get; set; }
    }
}
