using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FADemo.Models;
using FADemo.Models.FixedAsset;
using Microsoft.AspNetCore.Authorization;

namespace FADemo.Controllers
{
    /// <summary>
    /// Asset明细
    /// </summary>
    [Authorize(Roles = "Admin,BaseInfoAdmin,GeneralUser")]
    public class AssetUpdateDetailsController : Controller
    {
        private readonly ApplicationDbContext context;

        public AssetUpdateDetailsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: AssetUpdateDetails
        /// <summary>
        /// 更新明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int? id)
        {
            //var applicationDbContext = context.AssetUpdateDetails.Include(a => a.AssetAlterMode).Include(a => a.AssetCreateBase).Include(a => a.AssetPosition).Include(a => a.AssetStatus).Include(a => a.Department).Include(a => a.Employee);
            //return View(await applicationDbContext.ToListAsync());
            var applicationDbContext = context.AssetUpdateDetails.Include(a => a.AssetAlterMode)
                .Include(a => a.AssetCreateBase)
                .Include(a => a.AssetPosition)
                .Include(a => a.AssetStatus)
                .Include(a => a.Department)
                .Include(a => a.Employee)
                .Where(m => m.AssetId == id);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
