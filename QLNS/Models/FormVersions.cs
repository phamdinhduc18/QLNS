using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class FormVersions
    {
        public int FormVersionId { get; set; }
        public string VersionName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Status { get; set; }
        public int FormId { get; set; }

        public virtual Forms Form { get; set; }
    }
}
