using FADemo.Models;
using FADemo.Models.FixedAsset;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FADemo.Controllers
{
    /// <summary>
    /// 附件管理
    /// </summary>
    [Authorize(Roles = "Admin,BaseInfoAdmin,GeneralUser")]
    public class AssetAttachmentsController : Controller
    {
        private readonly ApplicationDbContext context;

        public AssetAttachmentsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 根据AssetID明细的AttachmentHashCode查询附件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assetCreateBase"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int? id, AssetCreateBase assetCreateBase)
        {
            TempData["assetid"] = id;
            var asshashcode = context.AssetCreateBases.FirstOrDefault(a => a.AssetId == id).AttachmentHashCode.ToString();
            var attachment = context.AssetAttachments.Where(b => b.AttachmentHashCode == asshashcode);
            return View(await attachment.ToListAsync());
        }
        /// <summary>
        /// 读取附件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ShowFile(int id)
        {
            var file = await context.AssetAttachments.FirstOrDefaultAsync(f => f.AttachmentId == id);
            {
                return File(file.Data, file.ContentType);
            }
            return View(file);
        }
        /// <summary>
        /// 附件下载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DownloadFile(int id)
        {
            var file = await context.AssetAttachments.FirstOrDefaultAsync(f => f.AttachmentId == id);
            return File(file.Data, file.ContentType, file.Description + file.Extension);
        }
        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteFile(int id)
        {

            var file = await context.AssetAttachments.Where(d => d.AttachmentId == id).FirstOrDefaultAsync();
            context.AssetAttachments.Remove(file);
            context.SaveChanges();
            return RedirectToAction("Index", new { id = TempData["assetid"] });
        }

        private bool AssetAttachmentExists(int id)
        {
            return (context.AssetAttachments?.Any(e => e.AttachmentId == id)).GetValueOrDefault();
        }
    }
}
