using System.ComponentModel.DataAnnotations;

namespace HA_Ossooll.Data.DTOs
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}