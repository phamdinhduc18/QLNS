using AutoMapper;
using QLNS.Repositories;
using QLNS.DTOs;
using QLNS.Helpers;
using QLNS.Models;
using MimeKit.Utils;
using System.Threading.Tasks;
using static QLNS.Helpers.Constants;
using HR.Helpers;
using System;

namespace QLNS.Services
{
    public class RequestApprovalService : GenericService<RequestApprovals>, IRequestApprovalService
    {
        private readonly RequestApprovalRepository _repo;
        private readonly IMapper _mapper;
        private readonly EmployeeRepository _eprepo;
        private readonly NotificationRepository _ntrepo;

        public RequestApprovalService(RequestApprovalRepository rqrepo, IMapper mapper, EmployeeRepository eprepo, NotificationRepository ntrepo):base(rqrepo)
        {
            _repo = rqrepo;
            _mapper = mapper;
            _eprepo = eprepo;
            _ntrepo = ntrepo;
        }

        public async Task<RequestApprovals> AddRqApproval(RequestApprovalDTO radto)
        {
            var newRqApproval = _mapper.Map<RequestApprovals>(radto);
            Employees ep = await _eprepo.GetAsync(radto.EmployeeId);
            if (ep == null) return null;
            newRqApproval.UserApprovalId = ep.ManagerId;
            newRqApproval.ApproverId = ep.DepartmentId;
            newRqApproval.CreateDate = DateTime.Now;
            var result1 =  await _repo.CreateAsync(newRqApproval);
            Employees manager = await _eprepo.GetAsync(ep.ManagerId);
            if(manager != null)
            {
                sendMailService(ApprovalMail.SENDERNAME, ApprovalMail.SENDEROFMAIL, ApprovalMail.SENDERPW, manager.FullName, manager.Email, string.Format(BodyMessage.MessApprovalEmail(manager), MimeUtils.GenerateMessageId()), ApprovalMail.SUBJECT, Constants.ApprovalMail.URLIMAGELOGO);
            }
            await _ntrepo.CreateAsync(new Notifications
            {
                //LeaderId=EmployeeId
                EmployeeId = ep.ManagerId,
                Title = "New Approval request !",
                Content = "New Approval request !",
                CreatDateTime = DateTime.Now,
                LinkRelated = "/RequestApproval/Detail/" + newRqApproval.Id
            });

            return result1;
        }

        public async Task UpdateStateAsync()
        {
            var list = await _repo.GetsAsync();
            foreach (var item in list)
            {
                var createdDate = item.CreateDate;
                if (createdDate.AddHours(16) < DateTime.Now && item.Status == 0)
                {
                    item.Status = 1;
                    item.Type = "NKP";
                    await _repo.UpdateAsync(item.Id, item);
                }
            }
        }
    }
}
