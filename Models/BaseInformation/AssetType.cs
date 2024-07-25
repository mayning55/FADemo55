using FADemo.Models.FixedAsset;
using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.BaseInformation
{
    public class AssetType
    {
        [Key]
        public int AssetTypeId { get; set; }

        public string AssetTypeNumber { get; set; }

        public string AssetTypeName { get; set; }

        public DateTime AssetTypeCreateDatetime { get; set; }

        [Display(Name = "Description")]
        public string AssetTypeDescription { get; set; }

        [Display(Name = "IsDisabled")]
        public bool AssetTypeIsDisabled { get; set; }

        public List<AssetCreateBase>? AssetCreateBase { get; set; }

    }
}
