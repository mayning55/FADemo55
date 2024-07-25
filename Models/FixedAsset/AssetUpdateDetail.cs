using FADemo.Models.BaseInformation;
using FADemo.Models.Organization;
using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.FixedAsset
{
    public class AssetUpdateDetail
    {
        [Key]
        public int AssetUpdateDeteailId { get; set; }

        public int AssetId { get; set; }

        public AssetCreateBase? AssetCreateBase { get; set; }

        [Display(Name = "GetSource")]
        public int? AssetAlterModeId { get; set; }

        public AssetAlterMode? AssetAlterMode { get; set; }

        [Display(Name = "Status")]
        public int? AssetStatusId { get; set; }

        public AssetStatus? AssetStatus { get; set; }

        [Display(Name = "Position")]
        public int? AssetPositionId { get; set; }

        public AssetPosition? AssetPosition { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

        [Display(Name = "User")]
        public int? EmployeeReferenceId { get; set; }

        public Employee? Employee { get; set; }

        [Display(Name = "UpdateUser")]
        public string? AssetUpdateUser { get; set; }

        public string? AttachmentHashCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "UpdateTime")]
        public DateTime? AssetUpdateTime { get; set; }

        public string? IsUpdate { get; set; }

        //public List<AssetAttachment>? AssetAttachments { get; set; }
    }
}
