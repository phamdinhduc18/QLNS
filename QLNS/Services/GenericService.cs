using MimeKit;
using MimeKit.Utils;
using QLNS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using QLNS.Helpers;

namespace QLNS.Services
{
    public abstract class GenericService<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        protected GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual T Create(T data) => _repository.Create(data);

        public virtual Task<T> CreateAsync(T data) => _repository.CreateAsync(data);

        public virtual T Delete(object Id) => _repository.Delete(Id);

        public virtual Task<T> DeleteAsync(object Id)=>_repository.DeleteAsync(Id);

        public virtual T Get(object Id) => _repository.Get(Id);

        public virtual Task<T> GetAsync(object Id) => _repository.GetAsync(Id);

        public virtual IEnumerable<T> Gets() => _repository.Gets();

        public virtual Task<IEnumerable<T>> GetsAsync() => _repository.GetsAsync();

        public virtual T Update(object Id, T data) => _repository.Update(Id, data);

        public virtual Task<T> UpdateAsync(object Id, T data) => _repository.UpdateAsync(Id, data);

        //public virtual Task<T> UpdateStatus(object Id) => _repository.UpdateStatus(Id);
        public void sendMailService(string senderName, string senderMail, string senderPassword, string receiverName, string receiverMail, string bodyMessage, string subject, string urlLogo)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(senderName, senderMail));
            message.To.Add(new MailboxAddress(receiverName, receiverMail));
            message.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            var image = bodyBuilder.LinkedResources.Add(urlLogo);
            image.ContentId = MimeUtils.GenerateMessageId();
            bodyBuilder.HtmlBody = string.Format(bodyMessage, image.ContentId);
            message.Body = bodyBuilder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                client.Connect(Constants.ProfileMail.HOSTEMAIL, Constants.ProfileMail.PORTEMAIL, false);
                client.Authenticate(senderMail, senderPassword);
                client.Send(message);
                client.Disconnect(true);
            }

        }
    }
}