using QLNS.Models;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace HR.Helpers
{
    public class BodyMessage
    {
        public static string MessBodyEmail(Employees employee, string newPassword)
        {
            var mess = "<p style='margin-bottom:80px'>Hi " + employee.FullName + ".<br>We send you a new password as per your request. <br>Please do not disclose your password to anyone. <br>Your new password is: " + newPassword + @"</p> <hr> <h3>Liên lệ với chúng tôi</h3> <h4>SDT:0123456789</h4><h4>Email: dongdungdang@gmail.com</h4> <img src=""cid:{0}""> ";
            return mess;
        }
        public static string MessNewForm(Employees employee, string message)
        {
            var mess = "<p style='margin-bottom:80px'>Hi " + employee.FullName + ".<br>" + message;
            return mess;
        }
        public static string MessApprovalEmail(Employees employee)
        {
            var mess = "<p style='margin-bottom:80px'>Hi " + employee.FullName + ".<br>You have new requset Approval. <br>Please go to website to confirm <br></p> <hr> <h3>Liên lệ với chúng tôi</h3> <h4>SDT:0123456789</h4><h4>Email: dongdungdang@gmail.com</h4> <img src=" + "cid:{0}" + "> ";
            return mess;
        }
        public static string MessPromptForApprovalEmail(Employees employee)
        {
            var mess = "<p style='margin-bottom:80px'>Hi " + employee.FullName + ".<br>You have new Prompt for Approval. <br>Please go to website to confirm <br></p> <hr> <h3>Liên lệ với chúng tôi</h3> <h4>SDT:0123456789</h4><h4>Email: dongdungdang@gmail.com</h4> <img src=" + "cid:{0}" + "> ";
            return mess;
        }
        public static string MessApprovalRequestEmail(Employees employee)
        {
            var mess = "<p style='margin-bottom:80px'>Hi " + employee.FullName + ".<br>Yêu cầu xin nghỉ của bạn đã được chấp nhận.<br></p> <hr> <h3>Liên lệ với chúng tôi</h3> <h4>SDT:0123456789</h4><h4>Email: dongdungdang@gmail.com</h4> <img src=" + "cid:{0}" + "> ";
            return mess;
        }
        public static string MessRejectRequestEmail(Employees employee)
        {
            var mess = "<p style='margin-bottom:80px'>Hi " + employee.FullName + ".<br>Yêu cầu xin nghỉ của bạn đã bị từ chối. <br>Vào website để xem lý do <br></p> <hr> <h3>Liên lệ với chúng tôi</h3> <h4>SDT:0123456789</h4><h4>Email: dongdungdang@gmail.com</h4> <img src=" + "cid:{0}" + "> ";
            return mess;
        }
    }
}

