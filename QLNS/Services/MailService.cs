using QLNS.Models;
using System.Net;
using System.Net.Mail;

namespace QLNS.Services
{
    internal class MailService : IMailService
    {
        public bool SendMailToUser(Employees user, string password)
        {
            var email = user.Email;
            var fromAddress = new MailAddress("baytv01289@gmail.com", "Vinh Tran Van (admin)");
            var toAddress = new MailAddress(email, user.FullName);
            var fromPassword = "Tranvanvinh01289";
            string subject = "Reset password for you :v";
            string body = GenarateContent(user,password);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }


            return true;
        }

        private string GenarateContent(Employees user, string password)
        {
            var result = $"Hello {user.FullName}\n" +
                $"You new password is: {password}\n\n" +
                $"Have a nice day <3 <3 <3";


            return result;
        }
    }
}