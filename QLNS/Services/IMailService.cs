using QLNS.Models;

namespace QLNS.Services
{
    public interface IMailService
    {
        public bool SendMailToUser(Employees user, string password);
    }
}