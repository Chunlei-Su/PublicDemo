using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingProject.Models.Command;
using ShoppingProject.Models.Filter;

namespace ShoppingProject.Controllers
{
    /// <summary>
    /// 服务于后端的控制器
    /// </summary>
    public class ShoppigBackEndController : Controller
    {
        private readonly ILogger<ShoppigBackEndController> _logger;
        private readonly IShoppingBackEnd _shoppingBackEnd;

        public ShoppigBackEndController(ILogger<ShoppigBackEndController> logger, IShoppingBackEnd shoppingBackEnd)
        {
            _logger = logger;
            _shoppingBackEnd = shoppingBackEnd;
        }

        #region 界面

        /// <summary>
        /// 后台主页
        /// </summary>
        //[Nologin_adminFilter]
        public IActionResult Index()
        {
            ViewBag.AdminAccount = HttpContext.Session.GetString("CurrentAdminAccount");

            return View();
        }

        /// <summary>
        /// 登录页
        /// </summary>
        public IActionResult AdminLogin(int stats = 0)
        {
            ViewBag.Stats = stats;
            return View();
        }

        #endregion

        #region 操作

        /// <summary>
        /// 执行管理员登录
        /// </summary>
        [HttpPost]
        public IActionResult AdminLoginCheck(string adminaccount, string adminpwd)
        {
            if (_shoppingBackEnd.AdminLogin(adminaccount, adminpwd))
            {
                HttpContext.Session.SetString("CurrentAdminAccount",adminaccount);
                return RedirectToAction("Index");
            }
            return RedirectToAction("AdminLogin", new { stats = -1 });
        }

        #endregion

    }
}
