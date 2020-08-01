using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingProject.Models;
using ShoppingProject.Models.Command;
using ShoppingProject.Models.Filter;
using ShoppingProject.Models.TableModules;

namespace ShoppingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShoppingOperation _shoppingOperation;

        public HomeController(ILogger<HomeController> logger, IShoppingOperation shoppingOperation)
        {
            _logger = logger;
            _shoppingOperation = shoppingOperation;

            //应该有一个后台程序，隔一会儿就开始清理过期订单
        }

        #region 界面

        /// <summary>
        /// 电商主页
        /// </summary>
        /// <param name="customernumber">如果登录了，通过此变量传递登录信息，没有登录直接返回未登录的页面</param>
        /// <returns></returns>
        public IActionResult Index()
        {
            //获取当前登录名
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            if (Cuser == null || Cuser == "")
                ViewBag.CustomerName = null;
            else
                ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);
            //获取商品类
            ViewBag.CommodityClassName = _shoppingOperation.GetCommodityClassName();
            //获取标签栏显示的信息
            var tabsAllData = _shoppingOperation.GetIndexTabsData();
            ViewBag.IndexTabsDataNav1 = tabsAllData[0];
            ViewBag.IndexTabsDataNav2 = tabsAllData[1];
            ViewBag.IndexTabsDataNav3 = tabsAllData[2];
            ViewBag.IndexTabsDataNav4 = tabsAllData[3];
            //获取要展示的商品信息
            var CommodityCardInfo = _shoppingOperation.GetIndexCommodityCardInfo();
            ViewBag.CommodityCardFirst = CommodityCardInfo[0];
            ViewBag.CommodityCardSecond = CommodityCardInfo[1];
            ViewBag.CommodityCardThird = CommodityCardInfo[2];
            ViewBag.CommodityCardFourth = CommodityCardInfo[3];
            return View();
        }

        #region 登录和注册

        /// <summary>
        /// 登录界面
        /// </summary>
        /// <param name="stats">指示登录状态，用与登录失败的界面显示</param>
        public IActionResult Login(int? stats)
        {
            if (stats != null)
            {
                if (stats == -1)
                {
                    ViewBag.Stats = 1;
                }
                else
                {
                    ViewBag.Stats = 0;
                }
            }
            else
            {
                ViewBag.Stats = 0;
            }

            return View();
        }

        /// <summary>
        /// 注册界面
        /// </summary>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 注册成功的反馈界面
        /// </summary>
        /// <param name="CustName">用户名</param>
        /// <param name="Number">帐号</param>
        /// <returns></returns>
        public IActionResult RegisterSuccess(string CustName, string Number)
        {
            if (CustName == "" || CustName == null)
                return RedirectToAction("Register");

            ViewBag.CustNumber = Number;
            ViewBag.CustName = CustName;
            return View();
        }

        #endregion

        #region 查询界面

        /// <summary>
        /// 模糊查询界面
        /// </summary>
        /// <param name="CommoditySearch">要查询的关键词</param>
        /// <param name="price">筛选价格</param>
        /// <param name="browse">筛选热度</param>
        /// <param name="orders">条件排序</param>
        public IActionResult ShowCommodityOfLike(string CommoditySearch, string price = "all", string browse = "all", string orders = "new", int currentpage = 1)
        {
            //获取当前登录名
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            if (Cuser == null || Cuser == "")
                ViewBag.CustomerName = null;
            else
                ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);
            CommoditySearch = CommoditySearch is null ? "" : CommoditySearch;
            //修正页码
            ViewBag.CurrentPageCount = currentpage < 1 ? 1 : currentpage;

            //保存关键词等信息
            ViewBag.SearchKeyWord = CommoditySearch;
            ViewBag.FilterPrice = price;
            ViewBag.FilterBrowse = browse;
            ViewBag.FilterOrders = orders;
            //获取商品数据和页码总数
            var result =
               _shoppingOperation.SearchPageCommodityInfoWithFilterOrOrders(CommoditySearch, price, browse, orders,
                   currentpage);
            ViewBag.CommodityCard = result.Item1;
            ViewBag.PageCount = result.Item2;

            ViewBag.CurrentPageCount = currentpage > result.Item2 ? result.Item2 : currentpage;
            return View();
        }

        /// <summary>
        /// 分类查询界面
        /// </summary>
        public IActionResult ShowCommodityOfClass(string CommoditySearch, string price = "all", string browse = "all", string orders = "new", int currentpage = 2)
        {
            //获取当前登录名
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            if (Cuser == null || Cuser == "")
                ViewBag.CustomerName = null;
            else
                ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);
            CommoditySearch = CommoditySearch is null ? "" : CommoditySearch;
            //修正页码
            ViewBag.CurrentPageCount = currentpage < 1 ? 1 : currentpage;

            //保存关键词等信息
            ViewBag.SearchKeyWord = CommoditySearch;
            ViewBag.FilterPrice = price;
            ViewBag.FilterBrowse = browse;
            ViewBag.FilterOrders = orders;
            //获取商品数据和页码总数
            var result =
                _shoppingOperation.SearchPageCommodityInfoWithFilterOrOrders(CommoditySearch, price, browse, orders,
                    currentpage, 2);
            ViewBag.CommodityCard = result.Item1;
            ViewBag.PageCount = result.Item2;

            ViewBag.CurrentPageCount = currentpage > result.Item2 ? result.Item2 : currentpage;
            return View();
        }

        #endregion

        #region 商品和店铺

        /// <summary>
        /// 商品详情界面
        /// </summary>
        /// <param name="commodityname">商品名称</param>
        public IActionResult CommodityContentPage(string commodityname)
        {
            var result = _shoppingOperation.GetSomeoneCommodity(commodityname);
            if (result == null)
            {
               return RedirectToAction("Index");
            }
            //获取当前登录名
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            ViewBag.CustomerNumber = Cuser;
            if (Cuser == null || Cuser == "")
            {
                ViewBag.CustomerName = null;
                ViewBag.CollectionStats = null;
            }
            else
            {
                ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);
                ViewBag.CollectionStats = _shoppingOperation.CheckSellerCollection(Cuser, result.ShopName);
            }

            ViewBag.SellerInfo = _shoppingOperation.GetSellerInfo(result.SellerNumber);


            return View(result);
        }

        /// <summary>
        /// 店铺详情界面
        /// </summary>
        /// <param name="sellername">店铺名称</param>
        public IActionResult SellerPage(string sellername, string sellernumber, string sellerSearch, int page = 1)
        {
            //获取当前登录名
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            if (Cuser == null || Cuser == "")
                ViewBag.CustomerName = null;
            else
                ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);
            ViewBag.SellerSearch = null;
            ViewBag.SellerName = sellername;
            ViewBag.SellerNumber = sellernumber;
            ViewBag.CurrentPageCount = page;
            //如果单纯的是进入店铺，就执行if，如果是搜本店的商品，就执行else
            if (sellerSearch == null || sellerSearch == "")
            {
                ViewBag.HotCommodity = _shoppingOperation.GetSellerHotCommodity(sellername);
                ViewBag.NewCommodity = _shoppingOperation.GetSellerNewCommodity(sellername);
            }
            else
            {
                sellerSearch = sellerSearch.Trim();    //去掉空格
                ViewBag.SellerSearch = sellerSearch;
                var result = _shoppingOperation.GetSellerKeyWordCommodity(sellername, sellerSearch, page);
                ViewBag.KeywordCommodity = result.Item1;
                ViewBag.PageCount = result.Item2;
            }
            //获取店铺信息
            return View(_shoppingOperation.GetSellerInfo(sellernumber));
        }

        /// <summary>
        /// 订单确认界面
        /// </summary>
        [NologinFilter]
        [HttpPost]
        public IActionResult DealNotarize(string commoditynumber, string sellernumber, Guid[] guids, bool istocar = false, bool needall = false)
        {
            //获取当前登录名
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            if (Cuser == null || Cuser == "")
                ViewBag.CustomerName = null;
            else
                ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);

            ViewBag.CustAddress = _shoppingOperation.GetCustomerAddress(Cuser).Split(',');
            ViewBag.DealInfo = _shoppingOperation.GetDealInfo(commoditynumber, sellernumber, Cuser, istocar, guids, needall);

            ViewBag.CommodityNumber = commoditynumber;
            ViewBag.SellerNumber = sellernumber;
            ViewBag.CustomerNumber = Cuser;

            if (guids.Length < 1&& ViewBag.DealInfo!=null)
            {
                string delakeys = ViewBag.DealInfo[0].DealKey.ToString();
                for (int i = 1; i < ViewBag.DealInfo.Count; i++)
                {
                    delakeys += $",{ViewBag.DealInfo[i].DealKey.ToString()}";
                }
                HttpContext.Session.SetString("DealKeys", string.Join(",", delakeys));
            }
            else
            {
                //将提交的订单编号保存下来
                HttpContext.Session.SetString("DealKeys", string.Join(",", guids));
            }

            return View();
        }

        /// <summary>
        /// 店铺后台界面
        /// </summary>
        [NologinFilter]
        public IActionResult SellerBackEnd(string sellername,string sellernumber, int page=1)
        {
            ViewBag.SellerName = sellername;
            ViewBag.SellerNumber = sellernumber;
            ViewBag.CurrentPageCount = page;
            ViewBag.CommodityClass = _shoppingOperation.GetCommodityClassName();
            var result = _shoppingOperation.GetSellerKeyWordCommodity(sellername, "", page);
            ViewBag.KeywordCommodity = result.Item1;
            ViewBag.PageCount = result.Item2;
            page = page > result.Item2 ? result.Item2 : page;
            page = page < 1 ? 1 : page;
            return View();
        }

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <returns></returns>
        [NologinFilter]
        public IActionResult SellerCommChangeInfo(string commoidtynumber,string sellernumber)
        {
            ViewBag.sn = sellernumber;
            ViewBag.CommodityNumber = commoidtynumber;
            ViewBag.CommodityClass = _shoppingOperation.GetCommodityClassName();
            ViewBag.CommodityData = _shoppingOperation.GetCommodityInfo(commoidtynumber);
            return View();
        }

        #endregion

        #region 购物车和结算

        /// <summary>
        /// 购物车界面
        /// </summary>
        /// <returns></returns>
        [NologinFilter]
        public IActionResult ShoppingCarPage()
        {
            //获取当前登录名
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);
            ViewBag.CustomerNumber = Cuser;
            var resulTuple = _shoppingOperation.GetShoppingCarInfo(Cuser);
            ViewBag.DealInfo = resulTuple.Item1;
            ViewBag.SellerName = resulTuple.Item2;
            return View();
        }

        /// <summary>
        /// 付款界面
        /// </summary>
        [NologinFilter]
        public IActionResult PayPage()
        {
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);
            string[] guids = HttpContext.Session.GetString("DealKeys").Split(",");
            ViewBag.DealAllMoney = _shoppingOperation.GetDealAllMoney(guids);
            ViewBag.count = guids.Length;
            return View();
        }

        #endregion

        #region 用户界面

        /// <summary>
        /// 用户界面（暂定完成）
        /// </summary>
        [NologinFilter]
        public IActionResult CustomerPage()
        {
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");

            ViewBag.CustomerInfo = _shoppingOperation.GetCustomerInfo(Cuser);
            ViewBag.AboutCount = _shoppingOperation.GetCountOfCarAndDeal(Cuser);
            ViewBag.CustomerAddress = _shoppingOperation.GetCustomerAddress(Cuser).Trim();
            ViewBag.SellerCollection = _shoppingOperation.GetCustomerSellerCollection(Cuser);
            ViewBag.SellerInfo = _shoppingOperation.GetSellerInfo(ViewBag.CustomerInfo.SellerNumber, 0);
            return View();
        }

        /// <summary>
        /// 用户信息修改界面
        /// </summary>
        /// <returns></returns>
        [NologinFilter]
        public IActionResult CustomerChangerInfo()
        {
            //获取当前登录名
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);
            ViewBag.usernumber = Cuser;
            ViewBag.CustomerInfo = _shoppingOperation.GetCustomerInfo(Cuser);
            return View();
        }

        /// <summary>
        /// 店铺信息修改界面
        /// </summary>
        [NologinFilter]
        public IActionResult SellerChangeInfo(string sellernumber)
        {
            string Cuser = HttpContext.Session.GetString("CurrentLoginUser");
            ViewBag.CustomerName = _shoppingOperation.GetCustomerNameAndHead(Cuser);
            ViewBag.SellerInfo = _shoppingOperation.GetSellerInfo(sellernumber, 0);
            return View();
        }

        #endregion

        /// <summary>
        /// 后台界面（未完成）
        /// </summary>
        [NologinFilter]
        public IActionResult AdminPage()
        {
            return View();
        }

        #endregion

        #region 操作

        /// <summary>
        /// 执行注册
        /// </summary>
        /// <returns>返回结果</returns>
        public JsonResult ToRegister([FromForm] CustomerBase customerBase)
        {
            List<object> result = _shoppingOperation.ToRegister(customerBase);
            return Json(new { stats = result[1], number = result[0] });
        }

        /// <summary>
        /// 执行登录
        /// </summary>
        /// <param name="custnumber">登录名</param>
        /// <param name="custpwd">密码</param>
        /// <param name="custlostkey">丢失码 nullable</param>
        /// <returns>bool</returns>
        [HttpPost]
        public IActionResult ToLogin(string custnumber, string custpwd, string? custlostkey, string stats)
        {
            if (_shoppingOperation.ToLogin(custnumber, custpwd, custlostkey))
            {
                this.HttpContext.Session.Remove("CurrentLoginUser");
                //登录成功，使用会话技术，记录当前登录用户
                this.HttpContext.Session.SetString("CurrentLoginUser", custnumber);
                if (stats == "commodity")
                {
                    return Json(1);
                }
                return RedirectToAction("Index");
            }

            return RedirectToAction("Login", new { stats = -1 });
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns>重定向到主页</returns>
        public IActionResult OutLogin()
        {
            HttpContext.Session.Remove("CurrentLoginUser");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 检查名字是否是唯一的
        /// </summary>
        /// <param name="CustName">用户名</param>
        /// <returns>bool</returns>
        public bool CheckCustomerName([FromForm] string CustName)
        {
            return _shoppingOperation.CheckCustomerName(CustName);
        }

        /// <summary>
        /// 收藏店铺
        /// </summary>
        [HttpPost]
        public bool CollectionSeller(string customernumber, string shopname, bool iscancel = false)
        {
            return _shoppingOperation.CollectionSeller(HttpContext.Session.GetString("CurrentLoginUser"), shopname, iscancel);
        }

        /// <summary>
        /// 获取评论
        /// </summary>
        [HttpPost]
        public JsonResult GetComments(string sellername, string commditynumber, int page = 1)
        {
            var result = _shoppingOperation.GetComments(sellername, commditynumber, page);
            return Json(result);
        }

        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="custnumber">用户ID</param>
        /// <param name="commnumber">商品ID</param>
        /// <param name="sellernumber">店铺ID</param>
        /// <param name="commsize">商品大小</param>
        /// <param name="commcolor">商品颜色</param>
        /// <param name="commcount">购买数量</param>
        /// <param name="commmoney">单价</param>
        [HttpPost]
        [NologinFilter]
        public bool AddNewDeal(string custnumber, string commnumber, string sellernumber, string commsize, string commcolor, int commcount, int commmoney, bool istocar = false)
        {
            return _shoppingOperation.BuilderNewDeal(custnumber, commnumber, sellernumber, commsize, commcolor, commcount, commmoney, istocar);
        }

        /// <summary>
        /// 订单界面修订购买的商品数量
        /// </summary>
        [HttpPost]
        [NologinFilter]
        public bool ChangeDealCount(Guid guids, string commnumber, string sellernumber, string operater, bool istocar = false)
        {
            return _shoppingOperation.ChangeDealCount(guids, commnumber, sellernumber, operater, istocar);
        }

        /// <summary>
        /// 提交订单，下一步付款
        /// </summary>
        [NologinFilter]
        public IActionResult NotarizeDeal(string address, Guid[] guids)
        {
            if (_shoppingOperation.NotarizeDeal(address, guids))
            {
                return RedirectToAction("PayPage");
            }

            return default;
        }

        /// <summary>
        /// 删除购物车中的一组或者多组数据
        /// </summary>
        /// <param name="guids">订单号</param>
        [HttpPost]
        public bool DelSomeCommodityInCar(Guid[] guids)
        {
            return _shoppingOperation.DelSomeCommodityInCar(guids);
        }

        /// <summary>
        /// 修改用户的基本信息
        /// </summary>
        /// <returns>重定向到信息修改页</returns>
        public IActionResult ChangeCustomerInfo(string headdata, string imgext, string CustomerName, string CustomerTel)
        {
            _shoppingOperation.ChangeCustomerInfo(headdata, imgext, CustomerName, CustomerTel,
                HttpContext.Session.GetString("CurrentLoginUser"));
            return RedirectToAction("CustomerChangerInfo");
        }

        /// <summary>
        /// 更新地址
        /// </summary>
        [HttpPost]
        public bool UpdateAddress(string address)
        {
            if (address == null)
                address = " ";
            return _shoppingOperation.ChangeOrDelAddress(address, HttpContext.Session.GetString("CurrentLoginUser"));
        }

        /// <summary>
        /// 添加商品的浏览量
        /// </summary>
        [HttpPost]
        public void BrowserAdd(string commoditynumber)
        {
            _shoppingOperation.BrowserAdd(commoditynumber);
        }

        /// <summary>
        /// 更新店铺信息
        /// </summary>
        /// <param name="logodata">base64logo数据</param>
        /// <param name="imgextlogo">logo扩展名</param>
        /// <param name="picdata">base64pic数据</param>
        /// <param name="imgextpic">pic扩展名</param>
        /// <param name="sellernumber">店铺号</param>
        /// <param name="shopname">名称</param>
        /// <param name="shopaddress">地址</param>
        public IActionResult UpdateSellerInfo(string logodata, string imgextlogo, string picdata, string imgextpic, string sellernumber, string shopname, string shopaddress)
        {
            _shoppingOperation.UpdateSellerInfo(logodata, imgextlogo, picdata, imgextpic, sellernumber, shopname, shopaddress);
            return RedirectToAction("SellerChangeInfo", new { sellernumber = sellernumber });
        }

        /// <summary>
        /// 付款
        /// </summary>
        public bool PayDeal(bool isorder)
        {
            if (!isorder)
                return false;
            string[] guids = HttpContext.Session.GetString("DealKeys").Split(",");
            return _shoppingOperation.PayDeal(guids);
        }

        /// <summary>
        /// 添加/更新商品
        /// </summary>
        [HttpPost]
        public bool AddCommodity(string commodityname, string commodityclass, string commoditysize,
             string commoditycolor, int commodityinventory, int commodityprice, string commodityintroduce,
             string commoditypicdata, string sellernumber, string picext, string commoditynumber, bool isupdate = false)
        {
            return _shoppingOperation.AddCommodity(commodityname, commodityclass, commoditysize, commoditycolor,
                commodityinventory, commodityprice, commodityintroduce, commoditypicdata, sellernumber, picext,commoditynumber,  isupdate);
        }

        /// <summary>
        /// 下架或者删除商品
        /// </summary>
        [HttpPost]
        public bool DownCommodityOrDel(string commoditynumber, bool isdel)
        {
            return _shoppingOperation.DownCommodityOrDel(commoditynumber, isdel);
        }



        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
