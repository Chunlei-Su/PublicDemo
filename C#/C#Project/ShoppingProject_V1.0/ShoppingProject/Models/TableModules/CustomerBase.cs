using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models.TableModules
{
    public class CustomerBase
    {
        public string CustomerNumber { get; set; }
        public string CustomerTel { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPassword { get; set; }
        public string LostPasswordKey { get; set; }
    }
}
