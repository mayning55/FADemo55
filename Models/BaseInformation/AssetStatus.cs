using FADemo.Models.FixedAsset;
using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.BaseInformation
{
    public class AssetStatus
    {
        [Key]
        public int AssetStatusId { get; set; }

        public string AssetStatusNumber { get; set; }

        [Display(Name = "AssetStatus")]
        public string AssetStatusName { get; set; }

        [Display(Name = "Description")]
        public string AssetStatusDescription { get; set; }

        public DateTime CreateDatetime { get; set; }

        public bool IsDisabled { get; set; }

        public List<AssetCreateBase>? AssetCreateBase { get; set; }

        public List<AssetUpdateDetail>? AssetUpdateDetail { get; set; }
    }
}
