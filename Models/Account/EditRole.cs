using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.Account
{
    public class EditRole
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }

        public List<string>? Users { get; set; }
    }
}
