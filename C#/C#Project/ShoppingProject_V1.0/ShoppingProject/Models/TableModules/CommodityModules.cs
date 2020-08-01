using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models.TableModules
{
    public class CommodityModules:CommodityBase
    {
        public string[] CommoditySize { get; set; }
        public string[] CommodityColor { get; set; }
        public int CommodityInventory { get; set; }
        public string CommodityIntroduce { get; set; }
        public string CommodityBrowse { get; set; }
	}
}
