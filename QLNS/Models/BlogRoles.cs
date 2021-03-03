using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class BlogRoles
    {
        public int RoleId { get; set; }
        public int BlogId { get; set; }

        public virtual Blogs Blog { get; set; }
        public virtual Roles Role { get; set; }
    }
}
