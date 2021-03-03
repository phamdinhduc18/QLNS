namespace QLNS.DTOs
{
    public class ChangPasswordDTO
    {
        public int id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}