using FADemo.Models.FixedAsset;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FADemo.Models.Organization
{
    /// <summary>
    /// 人员信息
    /// </summary>
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeNumber { get; set; }

        public string EmployeeName { get; set; }

        public string Position { get; set; }

        public DateTime CreateDatetime { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        [ForeignKey("EmployeeReferenceId")]
        public List<AssetCreateBase>? AssetCreateBase { get; set; }

        [ForeignKey("EmployeeReferenceId")]
        public List<AssetUpdateDetail>? AssetUpdateDetail { get; set; }
    }
}
