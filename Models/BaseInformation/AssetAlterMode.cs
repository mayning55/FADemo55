using FADemo.Models.FixedAsset;
using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.BaseInformation
{
    public class AssetAlterMode
    {
        [Key]
        public int AssetAlterModeId { get; set; }

        [Display(Name = "AlterName")]
        public string AssetAlterName { get; set; }

        [Display(Name = "Description")]
        public string? AssetAlterDescription { get; set; }

        public bool? IsDisabled { get; set; }

        public bool IsAdd { get; set; }

        public List<AssetCreateBase>? AssetCreateBase { get; set; }

        public List<AssetUpdateDetail>? AssetUpdateDetail { get; set; }
    }
}
