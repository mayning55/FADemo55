using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FADemo.Models;
using FADemo.Models.BaseInformation;
using Microsoft.AspNetCore.Authorization;


namespace FADemo.Controllers
{
    [Authorize(Roles = "Admin,BaseInfoAdmin")]
    public class BaseInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AssetTypeIndex()
        {
            return View(await _context.AssetTypes.ToListAsync());
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
                _context.Add(assettype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetTypeIndex));
            }
            return View(assettype);
        }

        public async Task<IActionResult> AssetTypeDisable(int Id)
        {
            var item = _context.AssetTypes.FirstOrDefault(x => x.AssetTypeId == Id);

            if (item == null)
            {
                return View("item NotFound");
            }
            else
            {
                if (item.AssetTypeIsDisabled == false)
                {
                    item.AssetTypeIsDisabled = true;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(AssetTypeIndex));
                }
                else
                {
                    item.AssetTypeIsDisabled = false;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(AssetTypeIndex));
                }
            }
        }

        public async Task<IActionResult> AssetStatusIndex()
        {
            return View(await _context.AssetStatuses.ToListAsync());
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
                _context.Add(assetstatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetStatusIndex));
            }
            return View(assetstatus);
        }

        public async Task<IActionResult> AssetPositionIndex()
        {
            return View(await _context.AssetPositions.ToListAsync());
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
                _context.Add(assetposition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetPositionIndex));
            }
            return View(assetposition);
        }

        public async Task<IActionResult> AssetDeprmetHodIndex()
        {
            return View(await _context.AssetDeprmetHods.ToListAsync());
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
                _context.Add(assetdeprmethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetDeprmetHodIndex));
            }
            return View(assetdeprmethod);
        }

        public async Task<IActionResult> AssetAlterModeIndex()
        {
            return View(await _context.AssetAlterModes.ToListAsync());
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
                _context.Add(assetaltermode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AssetAlterModeIndex));
            }
            return View(assetaltermode);
        }
    }


}
