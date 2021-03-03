using AutoMapper;
using QLNS.DTOs;
using QLNS.Models;
using QLNS.Repositories;
using System.Threading.Tasks;

namespace QLNS.Services
{
    public class NotificationService : GenericService<Notifications>, INotificationService
    {
        private readonly NotificationRepository _repo;
        private readonly IMapper _mapper;

        public NotificationService(NotificationRepository repo, IMapper mapper) : base(repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Notifications> AddNotification(NotificationDTO notificationDto)
        {
            var newN = _mapper.Map<Notifications>(notificationDto);
            var result = await _repo.CreateAsync(newN);
            return result;
        }

        public async Task<Notifications> DeleteNotification(int id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}
