using FADemo.Models.FixedAsset;
using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.BaseInformation
{
    /// <summary>
    /// Asset变更类型
    /// </summary>
    public class AssetAlterMode
    {
        [Key]
        public int AssetAlterModeId { get; set; }

        [Display(Name = "AlterName")]
        public string AssetAlterName { get; set; }

        [Display(Name = "Description")]
        public string? AssetAlterDescription { get; set; }

        public bool? IsDisabled { get; set; }

        public bool IsAdd { get; set; }//判断是新增还是变更

        public List<AssetCreateBase>? AssetCreateBase { get; set; }

        public List<AssetUpdateDetail>? AssetUpdateDetail { get; set; }
    }
}
