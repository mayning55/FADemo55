using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.FixedAsset
{
    /// <summary>
    /// 附件，
    /// </summary>
    public class AssetAttachment
    {
        [Key]
        public int AttachmentId { get; set; }

        public string? AttachmentHashCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "UploadDate")]
        public DateTime? AttachmentUploadDate { get; set; }

        [Display(Name = "UploadUser")]
        public string? AttachmentUploadUser { get; set; }

        public string? IsAdd { get; set; }

        public string Extension { get; set; }

        public string? Description { get; set; }

        public string FileName { get; set; }

        public byte[] Data { get; set; }

        public long Length { get; set; }

        public string ContentType { get; set; }
    }
}
