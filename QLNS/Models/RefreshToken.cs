using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class RefreshToken
    {
        public int EmployeeId { get; set; }
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }
        public string ReplacedByToken { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
