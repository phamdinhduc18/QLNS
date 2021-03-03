using AutoMapper;
using QLNS.DTOs;
using QLNS.Helpers.Models;
using QLNS.Models;

namespace QLNS.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employees, UserResponseDTO>()
                .ForMember(x => x.DepartmentName, opt => opt.MapFrom(x => x.Department.DepartmentName))
                .ForMember(x => x.Position, opt => opt.MapFrom(e => e.Role.RoleName))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.EmployeeId));
            CreateMap<RequestApprovalDTO, RequestApprovals>();
            CreateMap<NotificationDTO, Notifications>();
            CreateMap<CreateEmployeeDTO, Employees>()
     .ForMember(entity => entity.Email, opt => opt.MapFrom(dto => dto.Email.ToLower()))
     .AfterMap((dto, entity) => entity.Username = dto.Email.ToLower().Split('@')[0]);

            CreateMap<Employees, EmployeeBirthdayDTO>();
        }
    }
}
