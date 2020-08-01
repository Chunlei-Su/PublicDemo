using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager
{
   public class NewCatalog
    {
        public NewCatalog(string catalogId, string catalogName)
        {
            this.catalogId = catalogId;
            this.catalogName = catalogName;
        }

        public string catalogId { get; set; }
        public string catalogName { get; set; }
        public int quantity { get; set; }
    }
}
