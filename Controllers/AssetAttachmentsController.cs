using FADemo.Models;
using FADemo.Models.FixedAsset;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FADemo.Controllers
{
    [Authorize(Roles = "Admin,BaseInfoAdmin,GeneralUser")]
    public class AssetAttachmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetAttachmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据assetid查询附件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assetCreateBase"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int? id, AssetCreateBase assetCreateBase)
        {
            TempData["assetid"] = id;
            var asshashcode = _context.AssetCreateBases.FirstOrDefault(a => a.AssetId == id).AttachmentHashCode.ToString();
            var attachment = _context.AssetAttachments.Where(b => b.AttachmentHashCode == asshashcode);
            return View(await attachment.ToListAsync());
        }

        public async Task<IActionResult> ShowFile(int id)
        {
            var file = await _context.AssetAttachments.FirstOrDefaultAsync(f => f.AttachmentId == id);
            {
                return File(file.Data, file.ContentType);
            }
            return View(file);
        }

        public async Task<IActionResult> DownloadFile(int id)
        {
            var file = await _context.AssetAttachments.FirstOrDefaultAsync(f => f.AttachmentId == id);
            return File(file.Data, file.ContentType, file.Description + file.Extension);
        }

        public async Task<IActionResult> DeleteFile(int id)
        {

            var file = await _context.AssetAttachments.Where(d => d.AttachmentId == id).FirstOrDefaultAsync();
            _context.AssetAttachments.Remove(file);
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = TempData["assetid"] });
        }

        private bool AssetAttachmentExists(int id)
        {
            return (_context.AssetAttachments?.Any(e => e.AttachmentId == id)).GetValueOrDefault();
        }
    }
}
