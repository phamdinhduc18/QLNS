using QLNS.DTOs;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Services
{
    public interface IRequestApprovalService:IService<RequestApprovals>
    {
        public Task<RequestApprovals> AddRqApproval(RequestApprovalDTO radto);
        public Task UpdateStateAsync();
    }
}
