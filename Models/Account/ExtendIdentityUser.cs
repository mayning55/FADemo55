using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace FADemo.Models.Account
{
    public class ExtendIdentityUser : IdentityUser
    {
        public bool IsDisabled { get; set; }

        public DateTime CreateDatetime { get; set; }

        public int? DepartmentId { get; set; }
    }
}
