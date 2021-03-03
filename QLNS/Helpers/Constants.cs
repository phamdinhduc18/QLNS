using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Helpers
{
    public class Constants
    {
        public const string PASSWORD = "12345678";
        public const string JSONRESPONSE = "application/json";
        public static class CustomClaims
        {
            public const string DEPARTMENT = "Department";
            public const string ROLE = "Role";
        }

        public static class ProfileMail
        {
            public const string SENDERNAME = "TMT Solutions System Adminstrator";
            public const string SENDEROFMAIL = "tmtsolution1@gmail.com";
            public const string SENDERPW = "Admin@123";
            public const string SUBJECT = "Reset Your Password";
            public const string NEWFORMSUBJECT = "";
            public const string UPDATEFORMSUBJECT = "";
            public const string URLIMAGELOGO = @"ClientApp\images\logo.png";
            public const string HOSTEMAIL = "smtp.gmail.com";
            public const int PORTEMAIL = 587;
        }

        public static class ApprovalMail
        {
            public const string SENDERNAME = "TMT Solutions System Adminstrator";
            public const string SENDEROFMAIL = "tmtsolution1@gmail.com";
            public const string SENDERPW = "Admin@123";
            public const string SUBJECT = "Approval request";
            public const string URLIMAGELOGO = @"ClientApp\images\logo.png";
            public const string HOSTEMAIL = "smtp.gmail.com";
            public const int PORTEMAIL = 587;
        }

    }
}
