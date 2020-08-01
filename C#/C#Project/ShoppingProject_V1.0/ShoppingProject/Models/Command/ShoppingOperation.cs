using System;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShoppingProject.Models.Common;
using ShoppingProject.Models.TableModules;


namespace ShoppingProject.Models.Command
{
    public class ShoppingOperation : IShoppingOperation
    {
        //记录日志
        private ILogger<ShoppingOperation> _sLogger;
        private readonly IRWXmlConfig _xmlConfig;
        private string connectionString;
        private readonly byte pageshowcount;
        private readonly string _rootPath;

        public ShoppingOperation(ILogger<ShoppingOperation> sLogger, IConfiguration configuration, IRWXmlConfig xmlConfig, IHostEnvironment environment)
        {
            _sLogger = sLogger;
            _xmlConfig = xmlConfig;
            connectionString = configuration.GetConnectionString("DefaultString");
            //从配置文件中读取页面显示商品卡数量
            pageshowcount = Convert.ToByte(configuration["PageShowSize"]);
            _rootPath = environment.ContentRootPath;
        }

        #region 登录和注册

        /// <summary>
        /// 执行注册
        /// </summary>
        /// <param name="customerBase">注册时必须的四个信息</param>
        /// <returns>返回执行结果和动态生成的用户帐号</returns>
        public List<object> ToRegister(CustomerBase customerBase)
        {
            List<object> result = new List<object>();

            //生成用户编号
            customerBase.CustomerNumber = CustomerNumberProvider();
            result.Add(customerBase.CustomerNumber);

            WriteLog("执行了一次注册");
            string sqlstring =
                "insert into CustomerInfo (CustomerNumber,CustomerTel, CustomerName, CustomerPassword, LostPasswordKey) values(@CustomerNumber,@CustomerTel, @CustomerName, @CustomerPassword, @LostPasswordKey)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerNumber", customerBase.CustomerNumber),
                new SqlParameter("@CustomerTel", customerBase.CustomerTel),
                new SqlParameter("@CustomerName", customerBase.CustomerName),
                new SqlParameter("@CustomerPassword", customerBase.CustomerPassword),
                new SqlParameter("@LostPasswordKey", customerBase.LostPasswordKey)
            };
            result.Add(ToDataBase(sqlstring, parameters, command => command.ExecuteNonQuery() > 0));
            return result;

        }

        /// <summary>
        /// 执行登录
        /// </summary>
        /// <param name="custnumber">用户名</param>
        /// <param name="custpwd">密码</param>
        /// <param name="custlostkey">丢失码</param>
        /// <returns>bool</returns>
        public bool ToLogin(string custnumber, string custpwd, string? custlostkey)
        {
            WriteLog($"用户名：{custnumber}，尝试登录。");
            string sqlstring = string.Empty;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@CustomerNumber", custnumber),
                new SqlParameter("@CustomerPassword", custpwd)
            };


            //如果传入丢失码，执行两步操作，先检查用户名和丢失码是否存在，存在就修改密码，然后登录成功
            if (custlostkey != null)
            {
                parameters.Add(new SqlParameter("@LostPasswordKey", custlostkey));

                sqlstring = "update CustomerInfo " +
                            "set CustomerPassword = @CustomerPassword " +
                            "where CustomerNumber = (" +
                                "select CustomerNumber " +
                                "from CustomerInfo " +
                                "where CustomerNumber = @CustomerNumber " +
                                "and LostPasswordKey = @LostPasswordKey)";
                //如果受影响的行数为1，说明就登录成功
                return ToDataBase(sqlstring, parameters.ToArray(), comm => comm.ExecuteNonQuery() > 0);
            }

            sqlstring = "select CustomerID from CustomerInfo " +
                        "where CustomerNumber=@CustomerNumber " +
                        "and CustomerPassword=@CustomerPassword ";
            //如果hasrows,登录成功
            return ToDataBase(sqlstring, parameters.ToArray(), comm => comm.ExecuteReader().HasRows);

        }

        /// <summary>
        /// 检查新注册的名字是否唯一
        /// </summary>
        /// <param name="custName">用户名</param>
        /// <returns>bool</returns>
        public bool CheckCustomerName(string custName)
        {
            WriteLog("检查了一次名字");
            string sqlstring = "select CustomerName from CustomerInfo where CustomerName=@CustomerName";
            SqlParameter[] parameters = { new SqlParameter("@CustomerName", custName) };
            return ToDataBase(sqlstring, parameters, comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                return reader.HasRows;
            });
        }

        /// <summary>
        /// 从数据库中找到最大的编号，生成新的编号
        /// </summary>
        /// <returns>新的编号</returns>
        public string CustomerNumberProvider()
        {
            string sqlstring = "select TOP 1 CustomerNumber FROM CustomerInfo ORDER BY CustomerNumber DESC";
            string maxNumber = ToDataBase(sqlstring, null, comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }

                return string.Empty;
            });

            return "C" + (Convert.ToInt32(maxNumber.Split('C')[1]) + 1).ToString().PadLeft(9, '0');
        }

        #endregion

        #region 主页相关

        /// <summary>
        /// 获取当前登录用户的昵称
        /// </summary>
        /// <param name="custNumber">用户帐号</param>
        /// <returns>昵称</returns>
        public string[] GetCustomerNameAndHead(string custNumber)
        {
            string sqlstring = "select CustomerName,CustomerHead from CustomerInfo where CustomerNumber=@CustomerNumber";
            SqlParameter[] parameters = { new SqlParameter("@CustomerNumber", custNumber) };
            return ToDataBase(sqlstring, parameters, comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    string[] info = new string[2];
                    reader.Read();
                    info[0] = reader.GetString(0);
                    info[1] = reader.GetString(1);
                    return info;
                }

                return null;
            });
        }

        /// <summary>
        /// 获取所有的商品类别
        /// </summary>
        /// <returns>名称集</returns>
        public List<string[]> GetCommodityClassName()
        {
            string sqlstring = "select ClassName,ClassID from CommodityClassInfo";
            return ToDataBase(sqlstring, null, comm =>
            {
                List<string[]> result = new List<string[]>();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new[] { reader.GetString(0), reader.GetString(1) });
                    }

                    return result;
                }

                return null;
            });
        }

        /// <summary>
        /// 从配置文件中读取主页标签栏要显示的数据
        /// </summary>
        /// <returns>四个标签数据集合</returns>
        public List<object> GetIndexTabsData()
        {
            WriteLog("读取了一次XML文档");
            List<object> tabsDataList = new List<object>();
            //今日上新
            tabsDataList.Add(
                _xmlConfig.ReadXmlData(XmlReader =>
                    {
                        string[,] data = new string[5, 4];
                        byte i = 0;
                        while (XmlReader.Read())
                        {
                            if (XmlReader.Name == "nav")
                            {
                                data[i, 0] = XmlReader.GetAttribute("commodityname");
                                data[i, 1] = XmlReader.GetAttribute("title");
                                data[i, 2] = XmlReader.GetAttribute("content");
                                data[i, 3] = XmlReader.GetAttribute("sellernumber");
                                i++;
                            }
                        }
                        XmlReader.Close();
                        XmlReader.Dispose();
                        return data;
                    }));
            //今日名言
            tabsDataList.Add(
                _xmlConfig.ReadXmlData(XmlReader =>
                    {
                        string[,] data = new string[5, 3];
                        byte i = 0;
                        while (XmlReader.Read())
                        {
                            if (XmlReader.Name == "sentence")
                            {
                                data[i, 0] = XmlReader.GetAttribute("preview");
                                data[i, 1] = XmlReader.GetAttribute("content");
                                data[i, 2] = XmlReader.GetAttribute("name");
                                i++;
                            }
                        }
                        XmlReader.Close();
                        XmlReader.Dispose();
                        return data;
                    }));
            //热搜
            tabsDataList.Add(GetHotTopFive());
            //网站公告
            tabsDataList.Add(
                _xmlConfig.ReadXmlData(XmlReader =>
                    {
                        string[] data = new string[2];
                        while (XmlReader.Read())
                        {
                            if (XmlReader.Name == "notice")
                            {
                                data[0] = XmlReader.GetAttribute("title");
                                data[1] = XmlReader.GetAttribute("content");
                            }
                        }
                        XmlReader.Close();
                        XmlReader.Dispose();
                        return data;
                    }));
            return tabsDataList;
        }

        /// <summary>
        /// 获取首页要展示的商品卡信息
        /// </summary>
        /// <returns>结果集</returns>
        public List<CommodityBase>[] GetIndexCommodityCardInfo()
        {
            //查找某一类的商品前四个（按照新旧程度排名）
            string sqlstring =
                "select Top 4 CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName,SellerInfo.SellerNumber from CommodityInfo inner join SellerInfo on CommodityInfo.SellerNumber=SellerInfo.SellerNumber where CommodityClass in (select ClassID from CommodityClassInfo where ClassName=@classname and CommodityStats=@CommodityStats) order by CommodityNumber desc";
            List<CommodityBase>[] commoditydatas = new List<CommodityBase>[4];
            commoditydatas[0] = GetInfoShowCommodity(sqlstring, new SqlParameter[] { new SqlParameter("@classname", "精品男装"), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) });
            commoditydatas[1] = GetInfoShowCommodity(sqlstring, new SqlParameter[] { new SqlParameter("@classname", "魅力女装"), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) });
            commoditydatas[2] = GetInfoShowCommodity(sqlstring, new SqlParameter[] { new SqlParameter("@classname", "电子数码"), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) });
            commoditydatas[3] = GetInfoShowCommodity(sqlstring, new SqlParameter[] { new SqlParameter("@classname", "美味零食"), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) });
            return commoditydatas;
        }

        #endregion

        #region 搜索页

        /// <summary>
        /// 搜索商品，或根据条件，顺序
        /// </summary>
        /// <param name="commoditySearch">关键字</param>
        /// <param name="price">价格区间</param>
        /// <param name="browse">热度区间</param>
        /// <param name="orders">排序规则</param>
        /// <param name="symbol">指示当前是搜索还是查看商品分类，它们有不同的sql语句</param>
        /// <returns>一组元组，包含匹配的某一页的商品数据，和该关键词对应的商品页码</returns>
        public Tuple<List<CommodityBase>, int> SearchPageCommodityInfoWithFilterOrOrders(string commoditySearch, string price, string browse, string orders, int currentpage, int symbol = 1)
        {
            //查询该关键字对应的商品页码总数
            int pagecount = GetPageCount(SearchOperationSqlQueryBuilderForPage(price, browse, symbol), new[] { new SqlParameter("@CommoditySearch", $"%{commoditySearch}%"), new SqlParameter("@classname", commoditySearch), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) });
            //修正页码
            currentpage = currentpage > pagecount ? pagecount : currentpage;
            int show = (currentpage - 1) * pageshowcount + 1;

            //获取到生成后的sql语句
            string sqlstring = SearchOperationSqlQueryBuilderForCommodity(price, browse, orders, show, show + pageshowcount - 1, symbol);
            List<CommodityBase> daCommodityBases = new List<CommodityBase>();

            daCommodityBases = ToDataBase(sqlstring, new[] { new SqlParameter("@commoditySearch", $"%{commoditySearch}%"), new SqlParameter("@classname", commoditySearch), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) }, comm =>
                 {
                     List<CommodityBase> daCommodityBases = new List<CommodityBase>();
                     SqlDataReader reader = comm.ExecuteReader();
                     if (reader.HasRows)
                     {
                         while (reader.Read())
                         {
                             string pics = reader.GetString(3);
                             daCommodityBases.Add(new CommodityBase
                             {
                                 CommodityNumber = reader.GetString(0),
                                 CommodityName = reader.GetString(1),
                                 CommodityClass = reader.GetString(2),
                                 CommodityPic = pics.Split(','),
                                 CommodityPrice = reader.GetInt32(4),
                                 ShopName = reader.GetString(5),
                                 SellerNumber = reader.GetString(6)
                             });
                         }

                         return daCommodityBases;
                     }
                     return null;
                 });

            return new Tuple<List<CommodityBase>, int>(daCommodityBases, pagecount);
        }

        #endregion

        #region 店铺页

        /// <summary>
        /// 获取店铺信息
        /// </summary>
        public SellerInfo GetSellerInfo(string SellerNumber)
        {
            string sqlstring = "select SellerNumber, ShopName, SellerLogo, SellerPic, ExclusiveWeb, SellerVisit,SalesVolume from SellerInfo where SellerNumber=@SellerNumber";
            SqlParameter[] parameters ={
                new SqlParameter("@SellerNumber",SellerNumber)
            };
            return ToDataBase(sqlstring, parameters, comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return new SellerInfo
                    {
                        SellerNumber = reader.GetString(0),
                        ShopName = reader.GetString(1),
                        SellerLogo = reader.GetString(2),
                        SellerPic = reader.GetString(3),
                        ExclusiveWeb = reader.GetString(4),
                        SellerVisit = reader.GetString(5),
                        SalesVolume = reader.GetString(6)
                    };
                }

                return null;
            });
        }
        /// <summary>
        /// 店铺信息重载
        /// </summary>
        public SellerInfo GetSellerInfo(string sellernumber, int a = 0)
        {
            string sqlstring = "select SellerNumber, ShopName, SellerLogo, SellerPic, ExclusiveWeb, SellerVisit,SalesVolume,ShopAddress from SellerInfo where SellerNumber=@SellerNumber";
            SqlParameter[] parameters ={
                new SqlParameter("@SellerNumber",sellernumber)
            };
            return ToDataBase(sqlstring, parameters, comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string a = reader.GetString(3).Split(',')[0];
                    return new SellerInfo
                    {
                        SellerNumber = reader.GetString(0),
                        ShopName = reader.GetString(1),
                        SellerLogo = reader.GetString(2),
                        SellerPic = reader.GetString(3),
                        ExclusiveWeb = reader.GetString(4),
                        SellerVisit = reader.GetString(5),
                        SalesVolume = reader.GetString(6),
                        ShopAddress = reader.GetString(7)
                    };
                }

                return null;
            });
        }

        /// <summary>
        /// 获取店铺最新的三个商品信息
        /// </summary>
        public List<CommodityBase> GetSellerNewCommodity(string sellername)
        {
            string sqlstring =
                "select top 3 CommodityName, CommodityPic, CommodityPrice from CommodityInfo c inner join SellerInfo s on c.SellerNumber=s.SellerNumber where ShopName=@sellername and CommodityStats=@CommodityStats  order by CommodityNumber desc";
            return SellerCommodirtyInfoProvider(sellername, sqlstring, new[] { new SqlParameter("@sellername", sellername), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) });
        }

        /// <summary>
        /// 获取店铺热度最高的商品
        /// </summary>
        public List<CommodityBase> GetSellerHotCommodity(string sellername)
        {
            string sqlstring =
                "select top 8 CommodityName, CommodityPic, CommodityPrice from CommodityInfo c inner join SellerInfo s on c.SellerNumber=s.SellerNumber where ShopName=@sellername and CommodityStats=@CommodityStats order by CommodityBrowse desc ";
            return SellerCommodirtyInfoProvider(sellername, sqlstring, new[] { new SqlParameter("@sellername", sellername), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) });
        }

        /// <summary>
        /// 分页显示该店铺的关键字查询的信息,店铺后台也用到了这个方法
        /// </summary>
        /// <param name="sellername">店铺名</param>
        /// <param name="keyword">关键字</param>
        /// <param name="page">当前页</param>
        /// <returns>返回数据和总页码数</returns>
        public Tuple<List<CommodityBase>, int> GetSellerKeyWordCommodity(string sellername, string keyword, int page)
        {

            int pagesize = 12;
            string sqlpage =
                "select count(CommodityNumber) from CommodityInfo inner join SellerInfo on CommodityInfo.SellerNumber=SellerInfo.SellerNumber where ShopName=@shopname and CommodityStats=@CommodityStats and CommodityName like @keyword";
            if (keyword.Trim() == "")
            {
                sqlpage =
                    "select count(CommodityNumber) from CommodityInfo inner join SellerInfo on CommodityInfo.SellerNumber=SellerInfo.SellerNumber where ShopName=@shopname and CommodityStats=@CommodityStats";
            }
            //查到该关键词该店铺所匹配到的商品页码总数
            int allpagecount = GetPageCount(sqlpage, new[] { new SqlParameter("@shopname", sellername), new SqlParameter("@keyword", $"%{keyword}%"), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) }, pagesize);
            page = page > allpagecount ? allpagecount : page;
            page = page < 1 ? 1 : page;
            //计算该页显示的数据范围
            int show = (page - 1) * pagesize + 1;
            string sqlstring =
               $"select CommodityName, CommodityPic, CommodityPrice,CommodityNumber from(select CommodityName, CommodityPic, CommodityPrice,CommodityNumber,row_number() over(order by CommodityID) rn from CommodityInfo c inner join SellerInfo s on c.SellerNumber = s.SellerNumber where ShopName = @sellername and CommodityStats=@CommodityStats and CommodityName like @keyword) t where rn between {show} and {show + pagesize - 1} order by CommodityName desc";
            if (keyword.Trim() == "")
            {
                sqlstring =
                    $"select CommodityName, CommodityPic, CommodityPrice,CommodityNumber from(select CommodityName, CommodityPic, CommodityPrice,CommodityNumber,row_number() over(order by CommodityID) rn from CommodityInfo c inner join SellerInfo s on c.SellerNumber = s.SellerNumber where ShopName = @sellername and CommodityStats=@CommodityStats) t where rn between {show} and {show + pagesize - 1} order by CommodityName desc";
            }
            //获取数据
            var item1 = ToDataBase(sqlstring,
                new[]{
                        new SqlParameter("@sellername", sellername),
                        new SqlParameter("@keyword", $"%{keyword}%"),
                        new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online)
                    },
                comm =>
                    {
                        List<CommodityBase> data = new List<CommodityBase>();
                        SqlDataReader reader = comm.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                data.Add(new CommodityBase
                                {
                                    CommodityName = reader.GetString(0),
                                    CommodityPic = reader.GetString(1).Split(','),
                                    CommodityPrice = reader.GetInt32(2),
                                    CommodityNumber = reader.GetString(3)
                                });
                            }

                            return data;
                        }

                        return null;
                    });
            return new Tuple<List<CommodityBase>, int>(item1, allpagecount);
        }

        //封装公用的代码
        private List<CommodityBase> SellerCommodirtyInfoProvider(string sellername, string sqlstring, SqlParameter[] parameters)
        {
            return ToDataBase(sqlstring, parameters, comm =>
           {
               List<CommodityBase> commodityBases = new List<CommodityBase>();
               SqlDataReader reader = comm.ExecuteReader();
               if (reader.HasRows)
               {
                   while (reader.Read())
                   {
                       commodityBases.Add(new CommodityBase
                       {
                           CommodityName = reader.GetString(0),
                           CommodityPic = reader.GetString(1).Split(','),
                           CommodityPrice = reader.GetInt32(2)
                       });
                   }

                   return commodityBases;
               }

               return null;
           });
        }


        #endregion

        #region 商品详情页

        /// <summary>
        /// 获取某个商品的代码
        /// </summary>
        /// <param name="commodityname">商品名称</param>
        public CommodityModules GetSomeoneCommodity(string commodityname)
        {
            string sqlstring =
                "select CommodityNumber, CommodityName, CommoditySize, CommodityColor, CommodityPic, CommodityInventory, CommodityIntroduce, CommodityPrice, ShopName,CommodityBrowse,s.SellerNumber from CommodityInfo c inner join SellerInfo s on c.SellerNumber=s.SellerNumber where CommodityName=@commodityName and CommodityStats=@CommodityStats ";
            return ToDataBase(sqlstring, new[] { new SqlParameter("@commodityName", commodityname), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) }, comm =>
              {
                  SqlDataReader reader = comm.ExecuteReader();
                  if (reader.HasRows)
                  {
                      reader.Read();
                      return new CommodityModules
                      {
                          CommodityNumber = reader.GetString(0),
                          CommodityName = reader.GetString(1),
                          CommoditySize = reader.GetString(2).Split(','),
                          CommodityColor = reader.GetString(3).Split(','),
                          CommodityPic = reader.GetString(4).Split(','),
                          CommodityInventory = reader.GetInt32(5),
                          CommodityIntroduce = reader.GetString(6),
                          CommodityPrice = reader.GetInt32(7),
                          ShopName = reader.GetString(8),
                          CommodityBrowse = reader.GetString(9),
                          SellerNumber = reader.GetString(10)
                      };
                  }

                  return null;
              });
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="commoditynumber"></param>
        /// <returns></returns>
        public CommodityModules GetCommodityInfo(string commoditynumber)
        {
            string sqlstring =
                "select CommodityNumber, CommodityName, CommoditySize, CommodityColor, CommodityPic, CommodityInventory, CommodityIntroduce, CommodityPrice, ShopName,CommodityBrowse,s.SellerNumber,CommodityClass from CommodityInfo c inner join SellerInfo s on c.SellerNumber=s.SellerNumber where CommodityNumber=@CommodityNumber and CommodityStats=@CommodityStats ";
            return ToDataBase(sqlstring, new[] { new SqlParameter("@CommodityNumber", commoditynumber), new SqlParameter("@CommodityStats", (int)EnumCommodityStats.online) }, comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return new CommodityModules
                    {
                        CommodityNumber = reader.GetString(0),
                        CommodityName = reader.GetString(1),
                        CommoditySize = reader.GetString(2).Split(','),
                        CommodityColor = reader.GetString(3).Split(','),
                        CommodityPic = reader.GetString(4).Split(','),
                        CommodityInventory = reader.GetInt32(5),
                        CommodityIntroduce = reader.GetString(6),
                        CommodityPrice = reader.GetInt32(7),
                        ShopName = reader.GetString(8),
                        CommodityBrowse = reader.GetString(9),
                        SellerNumber = reader.GetString(10),
                        CommodityClass=reader.GetString(11)
                    };
                }

                return null;
            });
        }

        /// <summary>
        /// 添加浏览量
        /// </summary>
        public void BrowserAdd(string commdoitynumber)
        {
            string sqlstring = "update CommodityInfo set CommodityBrowse+=1 where CommodityNumber=@CommodityNumber";
            ToDataBase(sqlstring, new[] { new SqlParameter("@CommodityNumber", commdoitynumber), },
                comm => comm.ExecuteNonQuery());
        }

        /// <summary>
        /// 收藏店铺
        /// </summary>
        public bool CollectionSeller(string customernumber, string shopname, bool iscancel)
        {
            string sqlstring = "insert into CustomerCollection values(@customernumber,@shopname) ";
            if (iscancel)
                sqlstring =
                    "delete CustomerCollection where CustomerNumber=@customernumber and ShopName=@shopname";
            return ToDataBase(sqlstring, new[]
            {
                new SqlParameter("@customernumber",customernumber),
                new SqlParameter("@shopname",shopname)
            }, comm =>
            {
                return comm.ExecuteNonQuery() > 0;
            });
        }

        /// <summary>
        /// 查询店铺是否收藏
        /// </summary>
        public bool CheckSellerCollection(string customernumber, string shopname)
        {
            string sqlstring = "select count(CustomerNumber) from [CustomerCollection] where CustomerNumber=@customernumber and ShopName=@sellernumber ";
            return ToDataBase(sqlstring, new[]
            {
                new SqlParameter("@customernumber",customernumber),
                new SqlParameter("@sellernumber",shopname)
            }, comm =>
            {
                return (int)comm.ExecuteScalar() > 0;
            });
        }

        /// <summary>
        /// 查找某个商品的评论(未加图片，有时间再做)
        /// </summary>
        public List<string[]> GetComments(string sellername, string commditynumber, int page)
        {
            int size = 8;
            int show = (page - 1) * 8 + 1;
            string sqlstring = $"select  CustomerNumber, FeedbackContent from(select  CustomerNumber, FeedbackContent ,row_number() over(order by FeedbackID) rn from CommodityFeedback where ShopName=@shopname and CommodityNumber=@commoditynumber ) t where rn between {show}and {show + size - 1} ";
            return ToDataBase(sqlstring, new[]
            {
                new SqlParameter("@shopname", sellername),
                new SqlParameter("@commoditynumber", commditynumber)
            }, comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    List<string[]> dataList = new List<string[]>();
                    while (reader.Read())
                    {
                        dataList.Add(new[] { reader.GetString(0), reader.GetString(1) });
                    }

                    return dataList;
                }

                return null;
            });
        }

        #endregion

        #region 结算页

        /// <summary>
        /// 添加一条新的数据
        /// </summary>
        public bool BuilderNewDeal(string custnumber, string commnumber, string sellernumber, string commsize, string commcolor, int commcount, int commmoney, bool istocar)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustomerNumber", custnumber));
            parameters.Add(new SqlParameter("@CommodityNumber", commnumber));
            parameters.Add(new SqlParameter("@SellerNumber", sellernumber));

            //判断是否是加入购物车的选项
            if (istocar)
                parameters.Add(new SqlParameter("@NowStats", (int)EnumDealStats.AddCar));
            else
                parameters.Add(new SqlParameter("@NowStats", (int)EnumDealStats.DealBuild));

            parameters.Add(new SqlParameter("@DealCount", commcount));
            parameters.Add(new SqlParameter("@CommoditySize", commsize));
            parameters.Add(new SqlParameter("@CommodityColor", commcolor));
            parameters.Add(new SqlParameter("@DealKey", Guid.NewGuid()));

            string sqlstring = string.Empty;

            //如果数据库中有订单，但是用户有买了一个一模一样的，就直接在原订单数量加上新买的数即可
            if (!CheckDeal(custnumber, commnumber, sellernumber, commsize, commcolor, istocar))
            {
                sqlstring =
                   "insert into " +
                   "DealInfo(CustomerNumber, CommodityNumber, CommoditySize, CommodityColor, SellerNumber, DealCount, NowStats, OrdersTime, OneMoeny,DealKey) " +
                   "values(@CustomerNumber, @CommodityNumber, @CommoditySize, @CommodityColor, @SellerNumber, @DealCount, @NowStats, @OrdersTime, @OneMoeny,@DealKey)";
                parameters.Add(new SqlParameter("@OrdersTime", DateTime.Now));
                parameters.Add(new SqlParameter("@OneMoeny", commmoney));
            }
            else
            {
                sqlstring =
                   "update DealInfo set DealCount+=@DealCount " +
                   "where CustomerNumber=@CustomerNumber " +
                   "and CommodityNumber=@CommodityNumber " +
                   "and SellerNumber=@SellerNumber " +
                   "and NowStats=@NowStats " +
                   "and CommoditySize=@CommoditySize " +
                   "and CommodityColor=@CommodityColor";
            }

            //执行事物，添加或更新dealinfo表中的数据，商品表中对应的商品数量要相应改变
            string sqlstringsecond =
                "update CommodityInfo set CommodityInventory-=@DealCount where CommodityNumber=@CommodityNumber and SellerNumber=@SellerNumber";

            return ToDataBaseWithTransaction(new[] { sqlstring, sqlstringsecond }, parameters.ToArray()) > 0;
        }

        /// <summary>
        /// 获取用户的地址
        /// </summary>
        public string GetCustomerAddress(string customernumber)
        {
            string sqlstring = "select CustomerAddress from CustomerInfo where CustomerNumber=@cunumber";
            return ToDataBase(sqlstring, new[] { new SqlParameter("@cunumber", customernumber) }, comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader[0].ToString();
                }
                return "";
            });
        }

        /// <summary>
        /// 获取商品交易数据
        /// </summary>
        public List<DealInfoBase> GetDealInfo(string commoditynumber, string sellernumber, string customernumber, bool istocar, Guid[] guids, bool needall)
        {
            if (needall)
            {
                if (guids==null||guids.Length==0)
                {
                    return null;
                }
                guids = GetDealInfoWithCustomer(customernumber).ToArray();
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sqlstring = string.Empty;
            if (istocar)
            {
                sqlstring = "select CommodityName, d.CommoditySize,d.CommodityColor, DealCount,CommodityInventory,CommodityPic,OneMoeny,DealKey from DealInfo d inner join CommodityInfo c on d.CommodityNumber =c.CommodityNumber where ";
                for (int i = 0; i < guids.Length; i++)
                {
                    parameters.Add(new SqlParameter($"@guid{i}", guids[i]));
                    sqlstring = sqlstring + $"DealKey=@guid{i}";
                    if (i == guids.Length - 1)
                        break;
                    sqlstring = sqlstring + " or ";
                }
            }
            else
            {
                sqlstring = "select  CommodityName, d.CommoditySize,d.CommodityColor, DealCount,CommodityInventory,CommodityPic,OneMoeny,DealKey from DealInfo d inner join CommodityInfo c on d.CommodityNumber =c.CommodityNumber where CustomerNumber=@CustomerNumber and d.SellerNumber=@SellerNumber and d.CommodityNumber=@CommodityNumber and d.NowStats=@stats";

                parameters.Add(new SqlParameter("@CustomerNumber", customernumber));
                parameters.Add(new SqlParameter("@SellerNumber", sellernumber));
                parameters.Add(new SqlParameter("@CommodityNumber", commoditynumber));
                parameters.Add(new SqlParameter("@stats", (int)EnumDealStats.DealBuild));
            }

            return ToDataBase(sqlstring, parameters.ToArray(), comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    List<DealInfoBase> dataList = new List<DealInfoBase>();
                    while (reader.Read())
                    {
                        dataList.Add(new DealInfoBase
                        {
                            CommodityName = reader.GetString(0),
                            CommoditySize = reader.GetString(1),
                            CommodityColor = reader.GetString(2),
                            DealCount = reader.GetInt32(3),
                            CommodityInventory = reader.GetInt32(4),
                            CommodityPic = reader.GetString(5).Split(','),
                            OneMoeny = reader.GetInt32(6),
                            DealKey = reader.GetGuid(7)

                        });
                    }

                    return dataList;
                }
                return null;
            });

        }

        /// <summary>
        /// 检查数据库中是否有相同卖家，商家和种类的下单未确认的商品订单
        /// </summary>
        public bool CheckDeal(string customerNumber, string commodityNumber, string sellerNumber, string commsize, string commcolor, bool istocar)
        {
            string sqlstring =
                "select count(DealID) from DealInfo where CustomerNumber=@CustomerNumber and CommodityNumber=@CommodityNumber and SellerNumber=@SellerNumber and NowStats=@stats and CommoditySize=@CommoditySize and CommodityColor =@CommodityColor";
            EnumDealStats enumDeal;
            //判断是否是加入购物车的选项
            if (istocar)
                enumDeal = EnumDealStats.AddCar;
            else
                enumDeal = EnumDealStats.DealBuild;
            SqlParameter[] parameters ={
                new SqlParameter("@CustomerNumber", customerNumber),
                new SqlParameter("@CommodityNumber", commodityNumber),
                new SqlParameter("@SellerNumber", sellerNumber),
                new SqlParameter("@stats", (int)enumDeal),
                new SqlParameter("@CommoditySize", commsize),
                new SqlParameter("@CommodityColor", commcolor)
            };
            return ToDataBase(sqlstring, parameters, comm => (int)comm.ExecuteScalar() > 0);
        }

        /// <summary>
        /// 订单界面修订购买的商品数量
        /// </summary>
        public bool ChangeDealCount(Guid guid, string commnumber, string sellernumber, string operater, bool istocar)
        {
            string sqlstring =
                $"update DealInfo set DealCount{operater}=1" +
                "where Dealkey=@dealkey ";
            EnumDealStats enumDeal;
            //if (istocar)
            //    enumDeal = EnumDealStats.AddCar;
            //else
            //    enumDeal = EnumDealStats.DealBuild;
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (commnumber != null)
            {
                parameters.Add(new SqlParameter("@CommodityNumber", commnumber));
                parameters.Add(new SqlParameter("@SellerNumber", sellernumber));
            }
            parameters.Add(new SqlParameter("@dealkey", guid));

            operater = operater == "-" ? "+" : "-";

            //string sqlstringsecond =
            //    $"update CommodityInfo set CommodityInventory{operater}=1 where CommodityNumber=@CommodityNumber and SellerNumber=@SellerNumber";

            return ToDataBaseWithTransaction(new[] { sqlstring, /*sqlstringsecond*/ }, parameters.ToArray()) > 0;
        }

        /// <summary>
        /// 提交订单，下一步付款
        /// </summary>
        public bool NotarizeDeal(string address, Guid[] guids)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sqlstring = "update DealInfo set " +
                               "NowStats=@NowStats ,OrdersTime=@ordertime ,CustomerAddress=@address " +
                               "where ";
            parameters.Add(new SqlParameter("@address", address));
            parameters.Add(new SqlParameter("@NowStats", EnumDealStats.Order));
            parameters.Add(new SqlParameter("@ordertime", DateTime.Now));
            for (int i = 0; i < guids.Length; i++)
            {
                parameters.Add(new SqlParameter($"@guid{i}", guids[i]));
                sqlstring = sqlstring + $"DealKey=@guid{i}";
                if (i == guids.Length - 1)
                    break;
                sqlstring = sqlstring + " or ";
            }
            return ToDataBase(sqlstring, parameters.ToArray(), comm => comm.ExecuteNonQuery() > 0);
        }

        /// <summary>
        /// 获取购物车中的商品数据
        /// </summary>
        public Tuple<List<DealInfoBase>, List<string>> GetShoppingCarInfo(string customernumber)
        {
            List<string> sellername = new List<string>();
            string sqlstring = "select CommodityName,d.CommoditySize, d.CommodityColor,DealCount,CommodityInventory,CommodityPic,OneMoeny, ShopName,d.SellerNumber,d.CommodityNumber,d.CustomerNumber,DealKey " +
                               "from CommodityInfo c inner join DealInfo d on c.CommodityNumber=d.CommodityNumber inner join SellerInfo s on d.SellerNumber=s.SellerNumber  " +
                               "where CustomerNumber =@CustomerNumber and d.NowStats=@stats";

            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerNumber", customernumber),
                new SqlParameter("@stats", (int)EnumDealStats.AddCar)
            };
            List<DealInfoBase> dealInfo = ToDataBase(sqlstring, parameters, comm =>
             {
                 SqlDataReader reader = comm.ExecuteReader();
                 if (reader.HasRows)
                 {
                     List<DealInfoBase> dataList = new List<DealInfoBase>();
                     while (reader.Read())
                     {
                         dataList.Add(new DealInfoBase
                         {
                             CommodityName = reader.GetString(0),
                             CommoditySize = reader.GetString(1),
                             CommodityColor = reader.GetString(2),
                             DealCount = reader.GetInt32(3),
                             CommodityInventory = reader.GetInt32(4),
                             CommodityPic = reader.GetString(5).Split(','),
                             OneMoeny = reader.GetInt32(6),
                             ShopName = reader.GetString(7),
                             SellerNumber = reader.GetString(8),
                             CommodityNumber = reader.GetString(9),
                             CustomerNumber = reader.GetString(10),
                             DealKey = reader.GetGuid(11)
                         });
                     }
                     return dataList;
                 }
                 return null;
             });
            if (dealInfo == null)
            {
                return new Tuple<List<DealInfoBase>, List<string>>(null, null);
            }
            //获取店铺名
            foreach (var item in dealInfo)
            {
                if (!sellername.Contains(item.ShopName))
                {
                    sellername.Add(item.ShopName);
                }
            }
            return new Tuple<List<DealInfoBase>, List<string>>(dealInfo, sellername);
        }

        /// <summary>
        /// 删除购物车中的一组或者多组数据（开发环境是真的删除，生产环境一般将状态改为）
        /// </summary>
        public bool DelSomeCommodityInCar(Guid[] guids)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            //Product Environment
            //string sql = "update DealInfo set Nowstats=@stats where ";
            //parameters.Add(new SqlParameter("@stats", EnumDealStats.DealCancel));

            string sqlstring = "delete DealInfo where ";
            for (int i = 0; i < guids.Length; i++)
            {
                parameters.Add(new SqlParameter($"@guid{i}", guids[i]));
                sqlstring = sqlstring + $"DealKey=@guid{i}";
                if (i == guids.Length - 1)
                    break;
                sqlstring = sqlstring + " or ";
            }
            return ToDataBase(sqlstring, parameters.ToArray(), comm => comm.ExecuteNonQuery() > 0);
        }

        #endregion

        #region 付款页

        /// <summary>
        /// 计算商品总价
        /// </summary>
        public int GetDealAllMoney(string[] guids)
        {
            string sqlstring = "select SUM(DealCount*OneMoeny) from DealInfo where DealKey=@dealkey";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@dealkey", new Guid(guids[0])));
            //处理数据
            for (int i = 1; i < guids.Length; i++)
            {
                parameters.Add(new SqlParameter($"@dealkey{i}", new Guid(guids[i])));
                sqlstring += $" or DealKey=@dealkey{i}";
            }

            return ToDataBase(sqlstring, parameters.ToArray(), comm => (int)comm.ExecuteScalar());
        }

        /// <summary>
        /// 执行付款
        /// </summary>
        public bool PayDeal(string[] guids)
        {
            string sqlstring = "update DealInfo set NowStats=@NowStats,PayTime=@PayTime where DealKey=@dealkey";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@dealkey", new Guid(guids[0])));
            //处理数据
            for (int i = 1; i < guids.Length; i++)
            {
                parameters.Add(new SqlParameter($"@dealkey{i}", new Guid(guids[i])));
                sqlstring += $" or DealKey=@dealkey{i}";
            }
            parameters.Add(new SqlParameter("@NowStats", EnumDealStats.PayOver));
            parameters.Add(new SqlParameter("@PayTime", DateTime.Now));
            return ToDataBase(sqlstring, parameters.ToArray(), comm => comm.ExecuteNonQuery() > 0);
        }

        #endregion

        #region 个人界面

        /// <summary>
        /// 获取用户的信息
        /// </summary>
        public CustomerModules GetCustomerInfo(string customernumber)
        {
            string sqlstring = "select CustomerNumber, CustomerName, CustomerHead, CustomerTel, CustomerAddress,SellerNumber from CustomerInfo  where CustomerNumber=@CustomerNumber";
            return ToDataBase(sqlstring, new[] { new SqlParameter("@CustomerNumber", customernumber) }, comm =>
             {
                 SqlDataReader reader = comm.ExecuteReader();
                 if (!reader.HasRows)
                     return null;
                 reader.Read();
                 return new CustomerModules
                 {
                     CustomerNumber = reader.GetString(0),
                     CustomerName = reader.GetString(1),
                     CustomerHead = reader.GetString(2),
                     CustomerTel = reader.GetString(3),
                     CustomerAddress = reader[4] is DBNull ? null : reader[4].ToString().Split(','),
                     SellerNumber = reader[5] is DBNull ? string.Empty : reader.GetString(5)
                 };
             });
        }

        /// <summary>
        /// 修改用户的信息
        /// </summary>
        public bool ChangeCustomerInfo(string headdata, string imgext, string CustomerName, string CustomerTel, string customernumber)
        {
            string sqlstring = "update CustomerInfo set CustomerName=@CustomerName, CustomerTel=@CustomerTel";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustomerName", CustomerName));
            parameters.Add(new SqlParameter("@CustomerTel", CustomerTel));
            if (headdata != null)
            {
                if (!Base64ImageUpload.OperationImageWithBase64(headdata, imgext, _rootPath + @"\wwwroot\images\Customerhead\", customernumber))
                    return false;
                parameters.Add(new SqlParameter("@CustomerHead", $"/images/Customerhead/{customernumber}.{imgext}"));
                sqlstring += ",CustomerHead=@CustomerHead ";
            }
            parameters.Add(new SqlParameter("@CustomerNumber", customernumber));
            sqlstring += "where CustomerNumber=@CustomerNumber";

            return ToDataBase(sqlstring, parameters.ToArray(), comm => comm.ExecuteNonQuery() > 0);
        }

        /// <summary>
        /// 查询购物车中的数量和订单数量
        /// </summary>
        /// <return>返回数组[购物车商品数量，下单商品数量]</return>
        public int[] GetCountOfCarAndDeal(string customernumber)
        {
            SqlParameter customer = new SqlParameter("@CustomerNumber", customernumber);
            SqlParameter nowstats = new SqlParameter("@NowStats", EnumDealStats.AddCar);
            int[] count = new int[2];
            string sqlstring = "select COUNT(CustomerNumber) from DealInfo where CustomerNumber=@CustomerNumber and NowStats=@NowStats";
            count[0] = ToDataBase(sqlstring, new[] { customer, nowstats }, comm => (int)comm.ExecuteScalar());
            SqlParameter customer2 = new SqlParameter("@CustomerNumber", customernumber);
            SqlParameter nowstats2 = new SqlParameter("@NowStats", EnumDealStats.Order);
            count[1] = ToDataBase(sqlstring, new[] { customer2, nowstats2 }, comm => (int)comm.ExecuteScalar());
            return count;
        }

        /// <summary>
        /// 更新地址
        /// </summary>
        /// <param name="addressbase">新的地址数组</param>
        public bool ChangeOrDelAddress(string addressbase, string customernumber)
        {
            string sqlstring =
                "update CustomerInfo set CustomerAddress=@CustomerAddress where CustomerNumber=@CustomerNumber ";
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerAddress", addressbase),
                new SqlParameter("@CustomerNumber", customernumber)
            };
            return ToDataBase(sqlstring, parameters, comm => comm.ExecuteNonQuery() > 0);
        }

        /// <summary>
        /// 查找某个用户收藏的店铺
        /// </summary>
        /// <param name="customernumber"></param>
        /// <returns></returns>
        public List<string[]> GetCustomerSellerCollection(string customernumber)
        {
            string sqlstring = "select c.ShopName,SellerNumber from CustomerCollection c inner join SellerInfo s on c.ShopName=s.ShopName where CustomerNumber=@CustomerNumber ";
            return ToDataBase(sqlstring, new[] { new SqlParameter("@CustomerNumber", customernumber) }, comm =>
              {
                  SqlDataReader reader = comm.ExecuteReader();
                  if (reader.HasRows)
                  {
                      List<string[]> result = new List<string[]>();
                      while (reader.Read())
                      {
                          result.Add(new[] { reader.GetString(0), reader.GetString(1) });
                      }

                      return result;
                  }
                  return null;
              });
        }

        /// <summary>
        /// 更新店铺信息
        /// </summary>
        public bool UpdateSellerInfo(string logodata, string imgextlogo, string picdata, string imgextpic, string sellernumber, string shopname, string shopaddress)
        {
            string sqlstring =
                "update SellerInfo set ShopName=@ShopName ,ShopAddress=@ShopAddress";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ShopName", shopname));
            parameters.Add(new SqlParameter("@ShopAddress", shopaddress));
            if (logodata != null)
            {
                if (!Base64ImageUpload.OperationImageWithBase64(logodata, imgextlogo, _rootPath + @"\wwwroot\images\Seller\", $"{sellernumber}_logo"))
                    return false;
                parameters.Add(new SqlParameter("@SellerLogo", $"/images/Seller/{sellernumber}_logo.{imgextlogo}"));
                sqlstring += ",SellerLogo=@SellerLogo ";
            }
            if (picdata != null)
            {
                if (!Base64ImageUpload.OperationImageWithBase64(picdata, imgextpic, _rootPath + @"\wwwroot\images\Seller\", $"{sellernumber}_pic"))
                    return false;
                parameters.Add(new SqlParameter("@SellerPic", $"/images/Seller/{sellernumber}_pic.{imgextpic}"));
                sqlstring += ",SellerPic=@SellerPic ";
            }
            parameters.Add(new SqlParameter("@sellernumber", sellernumber));
            sqlstring += " where SellerNumber=@sellernumber";

            return ToDataBase(sqlstring, parameters.ToArray(), comm => comm.ExecuteNonQuery() > 0);
        }

        /// <summary>
        /// 添加或者更新商品信息
        /// </summary>
        /// <param name="isupdate">判断是否是更新商品</param>
        /// <returns></returns>
        public bool AddCommodity(string commodityname, string commodityclass, string commoditysize, string commoditycolor, int commodityinventory, int commodityprice, string commodityintroduce, string commoditypicdata, string sellernumber, string picext,string commoditynumber, bool isupdate = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string newcommmoditynumber = NewCommodityNumber();
            string sqlstring =
                "insert into CommodityInfo(CommodityNumber, CommodityName, CommodityClass, CommoditySize, CommodityColor, CommodityPic, CommodityInventory, CommodityIntroduce, CommodityPrice, SellerNumber, CommodiryAddTime)  " +
                "values(@CommodityNumber, @CommodityName, @CommodityClass, @CommoditySize, @CommodityColor, @CommodityPic, @CommodityInventory, @CommodityIntroduce, @CommodityPrice, @SellerNumber, @CommodiryAddTime)";
            if (isupdate)
            {
                newcommmoditynumber = commoditynumber;
                sqlstring =
                    "update CommodityInfo set CommodityName=@CommodityName, CommodityClass=@CommodityClass, CommoditySize=@CommoditySize, CommodityColor=@CommodityColor,  CommodityInventory=@CommodityInventory, CommodityIntroduce=@CommodityIntroduce, CommodityPrice=@CommodityPrice, SellerNumber= @SellerNumber  where CommodityNumber=@CommodityNumber";
                if (commoditypicdata != null)
                {
                    sqlstring = "update CommodityInfo set CommodityName=@CommodityName, CommodityClass=@CommodityClass, CommoditySize=@CommoditySize, CommodityColor=@CommodityColor,  CommodityInventory=@CommodityInventory, CommodityIntroduce=@CommodityIntroduce, CommodityPrice=@CommodityPrice, SellerNumber= @SellerNumber, CommodityPic=@CommodityPic  where CommodityNumber=@CommodityNumber ";
                    if (!Base64ImageUpload.OperationImageWithBase64(commoditypicdata, picext,
                        _rootPath + @"\wwwroot\images\commodity\", $"{newcommmoditynumber}_01"))
                        return false;
                    parameters.Add(new SqlParameter("@CommodityPic", commoditypicdata is null ? "/images/commodity/nopic.png" : $"/images/commodity/{newcommmoditynumber}_01.{picext},"));
                }
            }
            else
            {
                if (commoditypicdata != null)
                {
                    if (!Base64ImageUpload.OperationImageWithBase64(commoditypicdata, picext,
                        _rootPath + @"\wwwroot\images\commodity\", $"{newcommmoditynumber}_01"))
                        return false;
                    parameters.Add(new SqlParameter("@CommodityPic", commoditypicdata is null ? "/images/commodity/nopic.png" : $"/images/commodity/{newcommmoditynumber}_01.{picext},"));
                }

            }
            parameters.Add(new SqlParameter("@CommodityNumber", newcommmoditynumber));
            parameters.Add(new SqlParameter("@CommodityName", commodityname));
            parameters.Add(new SqlParameter("@CommodityClass", commodityclass));
            parameters.Add(new SqlParameter("@CommoditySize", commoditysize));
            parameters.Add(new SqlParameter("@CommodityColor", commoditycolor));
            parameters.Add(new SqlParameter("@CommodityInventory", commodityinventory));
            parameters.Add(new SqlParameter("@CommodityIntroduce", commodityintroduce));
            parameters.Add(new SqlParameter("@CommodityPrice", commodityprice));
            parameters.Add(new SqlParameter("@SellerNumber", sellernumber));
            parameters.Add(new SqlParameter("@CommodiryAddTime", DateTime.Now));

            return ToDataBase(sqlstring, parameters.ToArray(), comm => comm.ExecuteNonQuery() > 0);
        }

        /// <summary>
        /// 下架某个商品或者删除某个商品
        /// </summary>
        public bool DownCommodityOrDel(string commoditynumber, bool isdel)
        {
            string sqlstring = "update CommodityInfo set CommodityStats=@CommodityStats where CommodityNumber=@CommodityNumber";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@CommodityStats", (int)EnumCommodityStats.offline);
            if (isdel)
            {
                parameters[0] = new SqlParameter("@CommodityStats", (int)EnumCommodityStats.isdel);
            }
            parameters[1] = new SqlParameter("@CommodityNumber", commoditynumber);
            return ToDataBase(sqlstring, parameters, comm => comm.ExecuteNonQuery() > 0);
        }

        /// <summary>
        /// 返回一个新的商品号
        /// </summary>
        /// <returns></returns>
        private string NewCommodityNumber()
        {
            string sqlstring = "select top 1 CommodityNumber  from CommodityInfo  order by CommodityNumber desc";
            string maxvalue = ToDataBase(sqlstring, null, comm =>
            {
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return reader.GetString(0);
            });
            return $"S{DateTime.Now.Year}{(Convert.ToInt32(maxvalue.Substring(5)) + 1).ToString().PadLeft(5, '0')}";
        }

        /// <summary>
        /// 获取该用户的所有订单编号
        /// </summary>
        private List<Guid> GetDealInfoWithCustomer(string customernumber)
        {
            string sqlstring = "select DealKey  from DealInfo where CustomerNumber=@CustomerNumber";
            return ToDataBase(sqlstring, new[] { new SqlParameter("@CustomerNumber", customernumber) }, comm =>
              {
                  SqlDataReader reader = comm.ExecuteReader();
                  List<Guid> result = new List<Guid>();
                  if (reader.HasRows)
                  {
                      while (reader.Read())
                      {
                          result.Add(reader.GetGuid(0));
                      }
                      return result;
                  }
                  return null;
              });
        }

        #endregion

        #region 与数据库的操作

        /// <summary>
        /// 与数据库的增删改查操作
        /// </summary>
        /// <typeparam name="T">返回值</typeparam>
        /// <param name="commandString">sql语句</param>
        /// <param name="doFunc">自定义执行委托回调</param>
        /// <returns>T</returns>
        public T ToDataBase<T>(string commandString, SqlParameter[]? parameters, Func<SqlCommand, T> doFunc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    try
                    {
                        connection.Open();
                        if (parameters != null)
                            command.Parameters.AddRange(parameters);
                        return doFunc.Invoke(command);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 通过事务操作数据库(增删改)
        /// </summary>
        public int ToDataBaseWithTransaction(string[] commStrings, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //创建一个命令对象
                using (SqlCommand command = connection.CreateCommand())
                {
                    //创建一个事务对象
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            //传入连接对象
                            command.Connection = connection;
                            //传入事务对象
                            command.Transaction = transaction;
                            command.Parameters.AddRange(parameters);
                            //执行事务
                            for (int i = 0; i < commStrings.Length; i++)
                            {
                                command.CommandText = commStrings[i];

                                if (command.ExecuteNonQuery() == 0)
                                {
                                    throw new Exception("执行异常");
                                }
                            }

                            //没有问题直接提交事务
                            transaction.Commit();
                            return 1;
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            Console.WriteLine(e);
                            return 0;
                        }
                    }
                }
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="loggerstring">日志信息</param>
        public void WriteLog(string loggerstring)
        {
            _sLogger.Log(LogLevel.Information, $"{loggerstring}");
        }

        /// <summary>
        /// 从数据库中获取浏览量top5的商品数据
        /// </summary>
        /// <returns>数据集</returns>
        public string[] GetHotTopFive()
        {
            string sqlstring = "select top 5 CommodityName from CommodityInfo where CommodityStats=@CommodityStats  order by CommodityBrowse desc";
            return ToDataBase(sqlstring, new []{new SqlParameter("@CommodityStats",(int)EnumCommodityStats.online) }, comm =>
            {
                string[] data = new string[5];
                SqlDataReader reader = comm.ExecuteReader();
                for (byte i = 0; i < 5; i++)
                {
                    reader.Read();
                    data[i] = reader.GetString(0);
                }
                return data;
            });
        }

        /// <summary>
        /// 获取商品卡要展示的信息
        /// </summary>
        /// <param name="sqlstring">商品</param>
        /// <returns></returns>
        public List<CommodityBase> GetInfoShowCommodity(string sqlstring, SqlParameter[] parameterarray)
        {
            SqlParameter[] parameters = null;
            if (parameterarray != null)
            {
                parameters = parameterarray;
            }
            return ToDataBase(sqlstring, parameters, comm =>
            {
                List<CommodityBase> result = null;
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    result = new List<CommodityBase>();
                    while (reader.Read())
                    {
                        string pics = reader.GetString(3);
                        result.Add(new CommodityBase
                        {
                            CommodityNumber = reader.GetString(0),
                            CommodityName = reader.GetString(1),
                            CommodityClass = reader.GetString(2),
                            CommodityPic = pics.Split(','),
                            CommodityPrice = reader.GetInt32(4),
                            ShopName = reader.GetString(5),
                            SellerNumber = reader.GetString(6)
                        });
                    }
                    return result;
                }

                return null;
            });
        }

        /// <summary>
        /// 根据条件生成sql语句-商品专用
        /// </summary>
        private string SearchOperationSqlQueryBuilderForCommodity(string price, string browse, string orders, int pagemin, int pagemax, int symbol)
        {
            var filtersql = string.Empty;
            var orderstring = string.Empty;

            #region 拼接

            if (price != "" && price != null)
            {
                //如果是all,说明不筛选，直接下一步
                if (price == "all")
                    goto Next1;
                if (price.Split("~")[1] == "+")
                {
                    filtersql += "and CommodityPrice>1000";
                    goto Next1;
                }
                filtersql += $"and CommodityPrice between {price.Split("~")[0]} and {price.Split("~")[1]} ";
            }
        Next1: if (browse != "" && browse != null)
            {
                if (browse == "all")
                    goto Next2;
                if (browse.Split("~")[1] == "+")
                {
                    filtersql += "and CommodityBrowse>1000";
                    goto Next2;
                }
                filtersql += $"and CommodityBrowse between {browse.Split("~")[0]} and {browse.Split("~")[1]} ";
            }
        Next2: switch (orders)
            {
                case "priceasc":
                    orderstring = "order by CommodityPrice  asc"; break;
                case "pricedesc": orderstring = "order by CommodityPrice  desc"; break;
                case "browseasc": orderstring = "order by CommodityBrowse  asc"; break;
                case "browsedesc": orderstring = "order by CommodityBrowse  desc"; break;
                case "new": orderstring = "order by CommodityNumber  desc"; break;
            }
            #endregion

            if (symbol == 1)
            {
                return $"select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName,SellerNumber from (select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName,SellerInfo.SellerNumber, CommodityBrowse,row_number() over(order by CommodityID) rn from CommodityInfo inner join SellerInfo on CommodityInfo.SellerNumber = SellerInfo.SellerNumber where CommodityStats=@CommodityStats and CommodityName like @commoditySearch {filtersql}) t where rn between {pagemin} and {pagemax} {orderstring}";
            }

            return $"select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName,SellerNumber from (select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName,CommodityBrowse,Classname,s.SellerNumber,row_number() over(order by CommodityID) rn from SellerInfo s inner join CommodityInfo c on c.SellerNumber = s.SellerNumber inner join CommodityClassInfo i on c.CommodityClass = i.ClassID where  CommodityStats=@CommodityStats and ClassName = @classname {filtersql}) t where rn between {pagemin} and {pagemax} {orderstring}";

        }

        /// <summary>
        /// 根据条件生成sql语句-生成页码专用
        /// </summary>
        private string SearchOperationSqlQueryBuilderForPage(string price, string browse, int symbol)
        {
            string filtersql = String.Empty;
            #region 拼接

            if (price != "" && price != null)
            {
                //如果是all,说明不筛选，直接下一步
                if (price == "all")
                    goto Next1;
                if (price.Split("~")[1] == "+")
                {
                    filtersql += "and CommodityPrice>1000";
                    goto Next1;
                }
                filtersql += $"and CommodityPrice between {price.Split("~")[0]} and {price.Split("~")[1]} ";
            }
        Next1: if (browse != "" && browse != null)
            {
                if (browse == "all")
                    goto Next2;
                if (browse.Split("~")[1] == "+")
                {
                    filtersql += "and CommodityBrowse>1000";
                    goto Next2;
                }
                filtersql += $"and CommodityBrowse between {browse.Split("~")[0]} and {browse.Split("~")[1]} ";

            }

        #endregion

        Next2: if (symbol == 1)
            {
                return $"select COUNT(CommodityNumber) from CommodityInfo where CommodityName like @CommoditySearch {filtersql}";
            }

            return
                $"select COUNT(CommodityNumber) from CommodityInfo c inner join CommodityClassInfo i on c.CommodityClass = i.ClassID where ClassName = @classname and CommodityStats=@CommodityStats {filtersql}";
        }

        /// <summary>
        /// 获取总页码
        /// </summary>
        private int GetPageCount(string sqlquery, SqlParameter[] parameters, int pageshowsize = 0)
        {
            if (pageshowsize != 0)
            {
                return ToDataBase(sqlquery, parameters, comm =>
                {
                    int sum = (int)comm.ExecuteScalar();
                    return sum % pageshowsize == 0 ? sum / pageshowsize : sum / pageshowsize + 1;
                });
            }
            return ToDataBase(sqlquery, parameters, comm =>
            {
                int sum = (int)comm.ExecuteScalar();
                return sum % pageshowcount == 0 ? sum / pageshowcount : sum / pageshowcount + 1;
            });
        }

        #endregion

    }
}
