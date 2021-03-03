using QLNS.Data;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Repositories
{
    public class RequestApprovalRepository:GenericRepository<RequestApprovals>
    {
        public RequestApprovalRepository(DBContext context) : base(context)
        {
            
        }
    }
}
