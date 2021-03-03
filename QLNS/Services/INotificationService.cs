using QLNS.DTOs;
using QLNS.Models;
using System.Threading.Tasks;
using System;

namespace QLNS.Services
{
    public interface INotificationService: IService<Notifications>
    {
        public Task<Notifications> AddNotification(NotificationDTO notificationDto);
        public Task<Notifications> DeleteNotification(int id);
    }
}