using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models.TableModules
{
    public class CustomerModules : CustomerBase
    {
        public string CustomerHead { get; set; }
        public string[] CustomerAddress { get; set; }
        public string SellerNumber { get; set; }
    }
}
