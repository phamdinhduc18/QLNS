using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Blogs
    {
        public Blogs()
        {
            BlogRoles = new HashSet<BlogRoles>();
            BlogTags = new HashSet<BlogTags>();
            Comments = new HashSet<Comments>();
        }

        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Status { get; set; }
        public int EmployeeId { get; set; }
        public int BlogTypeId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual ICollection<BlogRoles> BlogRoles { get; set; }
        public virtual ICollection<BlogTags> BlogTags { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
