using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FADemo.Models;
using FADemo.Models.BaseInformation;
using Microsoft.AspNetCore.Authorization;


namespace FADemo.Controllers
{
    /// <summary>
    /// 各基础属性的创建，包含类型（是否禁用），状态，存放位置，折旧方法，变动方式
    /// </summary>
    [Authorize(Roles = "Admin,BaseInfoAdmin")]
    public class BaseInformationsController : Controller
    {
        private readonly ApplicationDbContext context;

        public BaseInformationsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> AssetTypeIndex()
        {
            return View(await context.AssetTypes.ToListAsync());
        }
        [HttpGet]
        public IActionResult AssetTypeCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AssetTypeCreate([Bind("AssetTypeId,AssetTypeNumber,AssetTypeName,AssetTypeCreateDatetime,AssetTypeDescription,AssetTypeIsDisabled")] AssetType assettype)
        {
            if (ModelState.IsValid)
            {
                assettype.AssetTypeCreateDatetime = DateTime.Now;
                context.Add(assettype);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetTypeIndex));
            }
            return View(assettype);
        }

        public async Task<IActionResult> AssetTypeDisable(int Id)
        {
            var item = context.AssetTypes.FirstOrDefault(x => x.AssetTypeId == Id);

            if (item == null)
            {
                return View("item NotFound");
            }
            else
            {
                if (item.AssetTypeIsDisabled == false)
                {
                    item.AssetTypeIsDisabled = true;
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(AssetTypeIndex));
                }
                else
                {
                    item.AssetTypeIsDisabled = false;
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(AssetTypeIndex));
                }
            }
        }

        public async Task<IActionResult> AssetStatusIndex()
        {
            return View(await context.AssetStatuses.ToListAsync());
        }
        [HttpGet]
        public IActionResult AssetStatusCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssetStatusCreate([Bind("AssetStatusId,AssetStatusNumber,AssetStatusName,AssetStatusDescription,CreateDatetime")] AssetStatus assetstatus)
        {
            if (ModelState.IsValid)
            {
                assetstatus.CreateDatetime = DateTime.Now;
                context.Add(assetstatus);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetStatusIndex));
            }
            return View(assetstatus);
        }

        public async Task<IActionResult> AssetPositionIndex()
        {
            return View(await context.AssetPositions.ToListAsync());
        }

        [HttpGet]
        public IActionResult AssetPositionCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssetPositionCreate([Bind("AssetPositionId,AssetPositionName,AssetPositionDescription")] AssetPosition assetposition)
        {
            if (ModelState.IsValid)
            {
                context.Add(assetposition);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetPositionIndex));
            }
            return View(assetposition);
        }

        public async Task<IActionResult> AssetDeprmetHodIndex()
        {
            return View(await context.AssetDeprmetHods.ToListAsync());
        }

        [HttpGet]
        public IActionResult AssetDeprmetHodCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssetDeprmetHodCreate([Bind("AssetDeprmetHodId,AssetDeprmetName,AssetDeprmetDescription,AssetDeproption")] AssetDeprmetHod assetdeprmethod)
        {
            if (ModelState.IsValid)
            {
                context.Add(assetdeprmethod);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetDeprmetHodIndex));
            }
            return View(assetdeprmethod);
        }

        public async Task<IActionResult> AssetAlterModeIndex()
        {
            return View(await context.AssetAlterModes.ToListAsync());
        }

        [HttpGet]
        public IActionResult AssetAlterModeCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssetAlterModeCreate([Bind("AssetAlterModeId,AssetAlterName,AssetAlterDescription,IsAdd")] AssetAlterMode assetaltermode)
        {
            if (ModelState.IsValid)
            {
                context.Add(assetaltermode);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetAlterModeIndex));
            }
            return View(assetaltermode);
        }
    }


}
