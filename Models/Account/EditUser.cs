using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FADemo.Models.Account
{
    public class EditUser
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        public EditUser()
        {
            Roles = new List<string>();
        }

        public IList<string> Roles { get; set; }
    }
}
