using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Notifications
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LinkRelated { get; set; }
        public bool IsRead { get; set; }
        public bool IsSaw { get; set; }
        public string DataUser { get; set; }
        public DateTime CreatDateTime { get; set; }
        public int TotalNotification { get; set; }
        public string ThumbNailImage { get; set; }
        public int EmployeeId { get; set; }
    }
}
