using FADemo.Models.FixedAsset;
using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.BaseInformation
{
    public class AssetPosition
    {
        [Key]
        public int AssetPositionId { get; set; }

        [Display(Name = "PositionName")]
        public string AssetPositionName { get; set; }

        [Display(Name = "Description")]
        public string? AssetPositionDescription { get; set; }

        public List<AssetCreateBase>? AssetCreateBase { get; set; }

        public List<AssetUpdateDetail>? AssetUpdateDetail { get; set; }
    }
}
