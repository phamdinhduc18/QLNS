using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Forms
    {
        public Forms()
        {
            FormVersions = new HashSet<FormVersions>();
        }

        public int FormId { get; set; }
        public string FormName { get; set; }
        public string FileName { get; set; }
        public int FormType { get; set; }

        public virtual ICollection<FormVersions> FormVersions { get; set; }
    }
}
