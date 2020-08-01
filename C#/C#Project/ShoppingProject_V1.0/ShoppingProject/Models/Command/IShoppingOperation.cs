using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingProject.Models.TableModules;

namespace ShoppingProject.Models.Command
{
    public interface IShoppingOperation
    {
        //注册
        List<object> ToRegister(CustomerBase customerBase);

        //登录
        bool ToLogin(string custnumber, string custpwd, string? custlostkey);

        //检查名字是否合格
        bool CheckCustomerName(string custName);

        //通过帐号获取用户名和头像
        string[] GetCustomerNameAndHead(string custNumber);

        //获取所有的商品类别
        List<string[]> GetCommodityClassName();

        //从配置文件中读取主页标签栏要显示的数据
        List<object> GetIndexTabsData();

        //首页商品分类显示
        List<CommodityBase>[] GetIndexCommodityCardInfo();

        //查询页的商品信息
        Tuple<List<CommodityBase>, int> SearchPageCommodityInfoWithFilterOrOrders(string CommoditySearch, string price,
            string browse, string orders, int currentpage, int symbol = 1);

        //根据店铺名称获取店铺信息
        SellerInfo GetSellerInfo(string sellername);
        SellerInfo GetSellerInfo(string sellernumber, int a);

        //获取某店铺商品最新的三件商品
        List<CommodityBase> GetSellerNewCommodity(string sellername);

        //获取某店铺最新的八件商品
        List<CommodityBase> GetSellerHotCommodity(string sellername);

        //通过关键词查询店铺的商品
        Tuple<List<CommodityBase>, int> GetSellerKeyWordCommodity(string sellername, string keyword, int page);

        //查询单个商品信息
        CommodityModules GetSomeoneCommodity(string commodityname);
        CommodityModules GetCommodityInfo(string commoditynumber);

        //添加浏览量
        void BrowserAdd(string commdoitynumber);

        //收藏店铺
        bool CollectionSeller(string customernumber, string shopname, bool iscancel);

        //查询店铺是否收藏
        bool CheckSellerCollection(string customernumber, string shopname);

        //查找某个商品的评论(未加图片，有时间再做)
        List<string[]> GetComments(string sellername, string commditynumber, int page);

        //新建一个订单
        bool BuilderNewDeal(string custnumber, string commnumber, string sellernumber, string commsize,
            string commcolor, int commcount, int commmoney, bool istocar);

        //获取用户地址信息
        string GetCustomerAddress(string customernumber);

        //获取初始订单信息，进行进一步确认
        List<DealInfoBase> GetDealInfo(string commoditynumber, string sellernumber, string customernumber, bool istocar, Guid[] guid, bool needall);

        //订单界面修订购买的商品数量
        bool ChangeDealCount(Guid guid, string commnumber, string sellernumber, string operater, bool istocar);

        //提交订单，下一步付款
        bool NotarizeDeal(string address, Guid[] guids);

        //获取购物车中的数据
        Tuple<List<DealInfoBase>, List<string>> GetShoppingCarInfo(string customernumber);

        //删除购物车中的一组或者多组数据
        bool DelSomeCommodityInCar(Guid[] guids);

        //获取提交的订单的商品总价
        int GetDealAllMoney(string[] guids);
        
        //执行付款
        bool PayDeal(string[] guids);

        //获取用户的信息
        CustomerModules GetCustomerInfo(string customernumber);

        //修改用户的信息
        bool ChangeCustomerInfo(string headdata, string imgext, string CustomerName, string CustomerTel, string customernumber);

        //查询购物车中的数量和订单数量
        int[] GetCountOfCarAndDeal(string customernumber);

        //更新地址
        bool ChangeOrDelAddress(string addressbase, string customernumber);

        //查找某个用户收藏的店铺
        List<string[]> GetCustomerSellerCollection(string customernumber);

        //更新店铺信息
        bool UpdateSellerInfo(string logodata, string imgextlogo, string picdata, string imgextpic, string sellernumber, string shopname, string shopaddress);

        //添加商品
        bool AddCommodity(string commodityname, string commodityclass, string commoditysize,
            string commoditycolor, int commodityinventory, int commodityprice, string commodityintroduce,
            string commoditypicdata, string sellernumber, string picext, string commoditynumber, bool isupdate = false);

        //下架某个商品或者删除某个商品
        bool DownCommodityOrDel(string commoditynumber,bool isdel);

    }
}
