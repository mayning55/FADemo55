using FADemo.Models.BaseInformation;
using FADemo.Models.Organization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.FixedAsset
{
    public class AssetCreateBase
    {
        [Key]
        public int AssetId { get; set; }

        public string AssetNumber { get; set; }

        public string AssetName { get; set; }

        [Display(Name = "RecordUser")]
        public string? AssetRecordUser { get; set; }

        [Display(Name = "RecordDate")]
        public DateTime? AssetRecordDate { get; set; }
        [Display(Name = "AssetType")]
        public int AssetTypeId { get; set; }

        public AssetType? AssetType { get; set; }

        public string Unit { get; set; }

        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal? Price { get; set; }

        [Display(Name = "DeprmetHod")]
        public int? AssetDeprmetHodId { get; set; }

        public AssetDeprmetHod? AssetDeprmetHod { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastDeprmetHodDate { get; set; }

        [Display(Name = "GetSource")]
        public int? AssetAlterModeId { get; set; }
        public AssetAlterMode? AssetAlterMode { get; set; }
        public string? Manufacturer { get; set; }

        public string? Vendor { get; set; }

        public string? Specification { get; set; }

        public string? Description { get; set; }
        [Display(Name = "Status")]
        public int? AssetStatusId { get; set; }
        public AssetStatus? AssetStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BeginUseDate { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

        [Display(Name = "Position")]
        public int? AssetPositionId { get; set; }
        public AssetPosition? AssetPosition { get; set; }

        [Display(Name = "Users")]
        public int? EmployeeReferenceId { get; set; }

        public Employee? Employee { get; set; }

        public string? AttachmentHashCode { get; set; }

        //public string? UploadFileName { get; set; }

        //public byte[]? UploadData { get; set; }

        //public long? UploadLength { get; set; }

        //public string? UploadContentType { get; set; }

        public List<AssetUpdateDetail>? AssetUpdateDetails { get; set; }
    }
}
