using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models.TableModules
{
    public class CommodityBase
    {
        public string CommodityNumber { get; set; }
        public string CommodityName { get; set; }
        public string CommodityClass { get; set; }
        public string[] CommodityPic { get; set; }
        public int CommodityPrice { get; set; }
        public string SellerNumber { get; set; }
        public string ShopName { get; set; }
    }
}
