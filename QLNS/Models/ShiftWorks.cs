using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class ShiftWorks
    {
        public ShiftWorks()
        {
            Employees = new HashSet<Employees>();
        }

        public int ShiftWorkId { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
