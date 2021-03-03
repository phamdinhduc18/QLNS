using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
