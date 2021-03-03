using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class BlogTags
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }

        public virtual Blogs Blog { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
