using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Roles
    {
        public Roles()
        {
            BlogRoles = new HashSet<BlogRoles>();
            Employees = new HashSet<Employees>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<BlogRoles> BlogRoles { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
