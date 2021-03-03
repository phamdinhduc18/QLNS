using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Tags
    {
        public Tags()
        {
            BlogTags = new HashSet<BlogTags>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<BlogTags> BlogTags { get; set; }
    }
}
