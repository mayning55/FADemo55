using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.Account
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
