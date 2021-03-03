using System.Text.Json.Serialization;

namespace QLNS.Helpers.Models
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string DepartmentName { get; set; }
        [JsonIgnore]
        public string Position { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int RoleId { get; set; }
        public int? DepartmentId { get; set; }
    }
}