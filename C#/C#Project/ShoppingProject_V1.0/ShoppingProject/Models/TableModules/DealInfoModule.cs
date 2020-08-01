using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models.TableModules
{
    public class DealInfoModule:DealInfoBase
    {
        public DateTime AddCarTime { get; set; }
        public DateTime OrdersTime { get; set; }
        public DateTime PayTime { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime DealOverTime { get; set; }
        public string CustomerAddress { get; set; }
    }
}
