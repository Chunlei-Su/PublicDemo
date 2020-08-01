using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models.TableModules
{
    public class DealInfoBase
    {
        public string CommodityName { get; set; }
        public string CustomerNumber { get; set; }
        public string CommodityNumber { get; set; }
        public string CommoditySize { get; set; }
        public string CommodityColor { get; set; }
        public string SellerNumber { get; set; }
        public int DealCount { get; set; }
        public int NowStats { get; set; }
        public int OneMoeny { get; set; }
        public int CommodityInventory { get; set; }
        public string[] CommodityPic { get; set; }
        public string ShopName { get; set; }
        
        public Guid DealKey { get; set; }

    }
}
