using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FADemo.Models;
using FADemo.Models.FixedAsset;
using Microsoft.AspNetCore.Identity;
using FADemo.Models.Account;
using Microsoft.AspNetCore.Authorization;

namespace FADemo.Controllers
{
    /// <summary>
    /// Asset管理，在创建时时添加指定字段的增加记录，后续变更同样记录。
    /// </summary>
    [Authorize(Roles = "Admin,BaseInfoAdmin,GeneralUser")]
    public class AssetCreateBasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly SignInManager<ExtendIdentityUser> signInManager;

        public AssetCreateBasesController(ApplicationDbContext context, SignInManager<ExtendIdentityUser> signInManager)
        {
            _context = context;
            this.signInManager = signInManager;
        }

        // GET: AssetCreateBases
        /// <summary>
        /// Index首页显示Asset列表，带名称，类型，数量，状态，部门，位置和使用人信息
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssetCreateBases.Include(a => a.AssetAlterMode).Include(a => a.AssetDeprmetHod).Include(a => a.AssetPosition).Include(a => a.AssetStatus).Include(a => a.AssetType).Include(a => a.Department).Include(a => a.Employee);
            return View(await applicationDbContext.ToListAsync());
        }
        /// <summary>
        /// 点击AssetNumber，列出具体的明细信息，包含修改记录页和附件瑞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: AssetCreateBases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetCreateBase = await _context.AssetCreateBases
                .Include(a => a.AssetAlterMode)
                .Include(a => a.AssetDeprmetHod)
                .Include(a => a.AssetPosition)
                .Include(a => a.AssetStatus)
                .Include(a => a.AssetType)
                .Include(a => a.Department)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AssetId == id);
            if (assetCreateBase == null)
            {
                return NotFound();
            }

            return View(assetCreateBase);
        }
        /// <summary>
        ///获取部门列表，在修改明细时，变更部门，使用人也跟随变更
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return Json(new SelectList(departments, "DepartmentId", "DepartmentName"));
        }

        [HttpGet]
        public IActionResult GetEmployees(int departmentId)
        {
            var employees = _context.Employees.Where(x => x.DepartmentId == departmentId).ToList();
            return Json(new SelectList(employees, "EmployeeId", "EmployeeName"));
        }

        // GET: AssetCreateBases/Create
        public IActionResult Create()
        {
            ViewData["AssetAlterModeId"] = new SelectList(_context.AssetAlterModes, "AssetAlterModeId", "AssetAlterName");
            ViewData["AssetDeprmetHodId"] = new SelectList(_context.AssetDeprmetHods, "AssetDeprmetHodId", "AssetDeprmetName");
            ViewData["AssetPositionId"] = new SelectList(_context.AssetPositions, "AssetPositionId", "AssetPositionName");
            ViewData["AssetStatusId"] = new SelectList(_context.AssetStatuses, "AssetStatusId", "AssetStatusName");
            ViewData["AssetTypeId"] = new SelectList(_context.AssetTypes, "AssetTypeId", "AssetTypeName");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["EmployeeReferenceId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: AssetCreateBases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetId,AssetNumber,AssetName,AssetRecordUser,AssetRecordDate,AssetTypeId,Unit,Quantity,Price,AssetDeprmetHodId,LastDeprmetHodDate,AssetAlterModeId,Manufacturer,Vendor,Specification,Description,AssetStatusId,BeginUseDate,DepartmentId,AssetPositionId,EmployeeReferenceId")] AssetCreateBase assetCreateBase, List<IFormFile> files, AssetUpdateDetail assetUpdateDetail)
        {
            var attachmentHashCode = Guid.NewGuid().ToString();

            if (files.Count > 5)
            {
                ViewData["UploadValidation"] = "File selected more than 5.";
                return View("UploadValidation");
            }
            foreach (var fileValidation in files)
            {
                var permittedExtensions = new[] { ".jpg", ".png", ".pdf" };
                var extension = Path.GetExtension(fileValidation.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                {
                    ViewData["UploadValidation"] = "Invalid file type,Filetype include jpg,png,pdf";
                    return View("UploadValidation");
                }
                var mimeType = fileValidation.ContentType;
                var permittedMimeTypes = new[] { "image/jpeg", "image/png", "application/pdf" };
                if (!permittedMimeTypes.Contains(mimeType))
                {
                    ViewData["UploadValidation"] = "Invalid MIME type.";
                    return View("UploadValidation");
                }
                if (fileValidation.Length > 10000000)
                {
                    ViewData["UploadValidation"] = "Limit to 10 MB.";
                    return View("UploadValidation");
                }
            }


            if (ModelState.IsValid)
            {
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        var description = Path.GetFileNameWithoutExtension(file.FileName);
                        var extension = Path.GetExtension(file.FileName);
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);

                        var assetAttachment = new AssetAttachment
                        {
                            Description = description,
                            FileName = uniqueFileName,
                            Length = file.Length,
                            ContentType = file.ContentType,
                            AttachmentHashCode = attachmentHashCode,
                            AttachmentUploadDate = DateTime.Now,
                            AttachmentUploadUser = User.Identity.Name,
                            Extension = extension,
                            IsAdd = "add",
                        };
                        using (var dataStream = new MemoryStream())
                        {
                            await file.CopyToAsync(dataStream);
                            assetAttachment.Data = dataStream.ToArray();
                        }

                        _context.AssetAttachments.Add(assetAttachment);
                        _context.SaveChanges();
                    }
                    assetCreateBase.AttachmentHashCode = attachmentHashCode;
                }
                assetCreateBase.AssetRecordDate = DateTime.Now;
                assetCreateBase.AssetRecordUser = User.Identity.Name;
                _context.Add(assetCreateBase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetAlterModeId"] = new SelectList(_context.AssetAlterModes, "AssetAlterModeId", "AssetAlterModeName", assetCreateBase.AssetAlterModeId);
            ViewData["AssetDeprmetHodId"] = new SelectList(_context.AssetDeprmetHods, "AssetDeprmetHodId", "AssetDeprmetName", assetCreateBase.AssetDeprmetHodId);
            ViewData["AssetPositionId"] = new SelectList(_context.AssetPositions, "AssetPositionId", "AssetPositionName", assetCreateBase.AssetPositionId);
            ViewData["AssetStatusId"] = new SelectList(_context.AssetStatuses, "AssetStatusId", "AssetStatusName", assetCreateBase.AssetStatusId);
            ViewData["AssetTypeId"] = new SelectList(_context.AssetTypes, "AssetTypeId", "AssetTypeName", assetCreateBase.AssetTypeId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", assetCreateBase.DepartmentId);
            ViewData["EmployeeReferenceId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", assetCreateBase.EmployeeReferenceId);
            return View(assetCreateBase);
        }

        // GET: AssetCreateBases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetCreateBase = await _context.AssetCreateBases.FindAsync(id);
            if (assetCreateBase == null)
            {
                return NotFound();
            }
            ViewData["AssetAlterModeId"] = new SelectList(_context.AssetAlterModes, "AssetAlterModeId", "AssetAlterName", assetCreateBase.AssetAlterModeId);
            ViewData["AssetDeprmetHodId"] = new SelectList(_context.AssetDeprmetHods, "AssetDeprmetHodId", "AssetDeprmetName", assetCreateBase.AssetDeprmetHodId);
            ViewData["AssetPositionId"] = new SelectList(_context.AssetPositions, "AssetPositionId", "AssetPositionName", assetCreateBase.AssetPositionId);
            ViewData["AssetStatusId"] = new SelectList(_context.AssetStatuses, "AssetStatusId", "AssetStatusName", assetCreateBase.AssetStatusId);
            ViewData["AssetTypeId"] = new SelectList(_context.AssetTypes, "AssetTypeId", "AssetTypeName", assetCreateBase.AssetTypeId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", assetCreateBase.DepartmentId);
            ViewData["EmployeeReferenceId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", assetCreateBase.EmployeeReferenceId);
            return View(assetCreateBase);
        }

        // POST: AssetCreateBases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, AssetCreateBase assetCreateBase, AssetUpdateDetail assetUpdateDetail, List<IFormFile> editFiles)
        {
            if (editFiles.Count > 5)
            {
                ViewData["EditUploadValidation"] = "File selected more than 5.";
                return View("EditUploadValidation");
            }
            foreach (var editFilesValidation in editFiles)
            {
                var permittedExtensions = new[] { ".jpg", ".png", ".pdf" };
                var extension = Path.GetExtension(editFilesValidation.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                {
                    ViewData["EditUploadValidation"] = "Invalid file type,Filetype include jpg,png,pdf";
                    return View("EditUploadValidation");
                }
                var mimeType = editFilesValidation.ContentType;
                var permittedMimeTypes = new[] { "image/jpeg", "image/png", "application/pdf" };
                if (!permittedMimeTypes.Contains(mimeType))
                {
                    ViewData["EditUploadValidation"] = "Invalid MIME type.";
                    return View("EditUploadValidation");
                }
                if (editFilesValidation.Length > 10000000)
                {
                    ViewData["EditUploadValidation"] = "Limit to 10 MB.";
                    return View("EditUploadValidation");
                }
            }

            var assetContext = await _context.AssetCreateBases.FirstOrDefaultAsync(a => a.AssetId == id);
            var asupdetailContext = await _context.AssetUpdateDetails.FirstOrDefaultAsync(a => a.AssetId == id);
            if (asupdetailContext == null)
            {
                var createDetailRecord = new AssetUpdateDetail();
                createDetailRecord.AssetId = assetContext.AssetId;
                createDetailRecord.AssetAlterModeId = assetContext.AssetAlterModeId;
                createDetailRecord.AssetStatusId = assetContext.AssetStatusId;
                createDetailRecord.AssetPositionId = assetContext.AssetPositionId;
                createDetailRecord.DepartmentId = assetContext.DepartmentId;
                createDetailRecord.EmployeeReferenceId = assetContext.EmployeeReferenceId;
                createDetailRecord.AssetUpdateUser = assetContext.AssetRecordUser;
                createDetailRecord.AssetUpdateTime = assetContext.AssetRecordDate;
                createDetailRecord.AttachmentHashCode = assetContext.AttachmentHashCode;
                createDetailRecord.IsUpdate = "Create";
                _context.Add(createDetailRecord);
                await _context.SaveChangesAsync();
            }

            using var context = _context;
            var asset = await context.AssetCreateBases.FirstOrDefaultAsync(a => a.AssetId == id);
            if (editFiles.Count >= 1)
            {
                foreach (var editFile in editFiles)
                {
                    var description = Path.GetFileNameWithoutExtension(editFile.FileName);
                    var extension = Path.GetExtension(editFile.FileName);
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(editFile.FileName);
                    //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);

                    var assetAttachment = new AssetAttachment
                    {
                        Description = description,
                        FileName = uniqueFileName,
                        Length = editFile.Length,
                        ContentType = editFile.ContentType,
                        AttachmentHashCode = asset.AttachmentHashCode,
                        AttachmentUploadDate = DateTime.Now,
                        AttachmentUploadUser = User.Identity.Name,
                        Extension = extension,
                        IsAdd = "Update",
                    };
                    using (var dataStream = new MemoryStream())
                    {
                        await editFile.CopyToAsync(dataStream);
                        assetAttachment.Data = dataStream.ToArray();
                    }

                    context.AssetAttachments.Add(assetAttachment);
                    context.SaveChanges();
                }
            }

            if (asset == null)
            {
                return View("NotFound");
            }
            else
            {
                asset.AssetAlterModeId = assetCreateBase.AssetAlterModeId;
                asset.AssetStatusId = assetCreateBase?.AssetStatusId;
                asset.DepartmentId = assetCreateBase.DepartmentId;
                asset.AssetPositionId = assetCreateBase.AssetPositionId;
                asset.EmployeeReferenceId = assetCreateBase.EmployeeReferenceId;
                assetUpdateDetail.AssetId = assetCreateBase.AssetId;
                assetUpdateDetail.AssetAlterModeId = assetCreateBase.AssetAlterModeId;
                assetUpdateDetail.AssetStatusId = assetCreateBase.AssetStatusId;
                assetUpdateDetail.AssetPositionId = assetCreateBase.AssetPositionId;
                assetUpdateDetail.DepartmentId = assetCreateBase.DepartmentId;
                assetUpdateDetail.EmployeeReferenceId = assetCreateBase.EmployeeReferenceId;
                assetUpdateDetail.AssetUpdateUser = User.Identity.Name;
                assetUpdateDetail.AssetUpdateTime = DateTime.Now;
                assetUpdateDetail.AttachmentHashCode = asset.AttachmentHashCode;
                assetUpdateDetail.IsUpdate = "Update";
                context.Add(assetUpdateDetail);
                context.Update(asset);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["AssetAlterModeId"] = new SelectList(_context.AssetAlterModes, "AssetAlterModeId", "AssetAlterName", assetCreateBase.AssetAlterModeId);
            ViewData["AssetDeprmetHodId"] = new SelectList(_context.AssetDeprmetHods, "AssetDeprmetHodId", "AssetDeprmetName", assetCreateBase.AssetDeprmetHodId);
            ViewData["AssetPositionId"] = new SelectList(_context.AssetPositions, "AssetPositionId", "AssetPositionName", assetCreateBase.AssetPositionId);
            ViewData["AssetStatusId"] = new SelectList(_context.AssetStatuses, "AssetStatusId", "AssetStatusName", assetCreateBase.AssetStatusId);
            ViewData["AssetTypeId"] = new SelectList(_context.AssetTypes, "AssetTypeId", "AssetTypeName", assetCreateBase.AssetTypeId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", assetCreateBase.DepartmentId);
            ViewData["EmployeeReferenceId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", assetCreateBase.EmployeeReferenceId);
            return View(assetCreateBase);
        }

        // GET: AssetCreateBases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetCreateBase = await _context.AssetCreateBases
                .Include(a => a.AssetAlterMode)
                .Include(a => a.AssetDeprmetHod)
                .Include(a => a.AssetPosition)
                .Include(a => a.AssetStatus)
                .Include(a => a.AssetType)
                .Include(a => a.Department)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AssetId == id);
            if (assetCreateBase == null)
            {
                return NotFound();
            }

            return View(assetCreateBase);
        }

        // POST: AssetCreateBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetCreateBase = await _context.AssetCreateBases.FindAsync(id);
            var attachment = _context.AssetAttachments.Where(b => b.AttachmentHashCode == assetCreateBase.AttachmentHashCode.ToString());
            if (assetCreateBase != null)
            {
                _context.AssetCreateBases.Remove(assetCreateBase);
            }
            if (attachment != null)
            {
                foreach (var att in attachment)
                    _context.AssetAttachments.Remove(att);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetCreateBaseExists(int id)
        {
            return _context.AssetCreateBases.Any(e => e.AssetId == id);
        }
    }
}
