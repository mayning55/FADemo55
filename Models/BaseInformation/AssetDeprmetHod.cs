using FADemo.Models.FixedAsset;
using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.BaseInformation
{
    /// <summary>
    /// 折旧方式
    /// </summary>
    public class AssetDeprmetHod
    {
        [Key]
        public int AssetDeprmetHodId { get; set; }

        public string AssetDeprmetName { get; set; }

        [Display(Name = "Description")]
        public string? AssetDeprmetDescription { get; set; }

        public char? AssetDeproption { get; set; }

        public bool? IsDisabled { get; set; }

        public List<AssetCreateBase>? AssetCreateBase { get; set; }
    }
}
