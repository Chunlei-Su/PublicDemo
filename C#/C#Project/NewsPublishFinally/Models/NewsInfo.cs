using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPublishFinally.Models
{
    //使用此类接收添加评论页面的数据
    public class NewsInfo
    {
        public string title { get; set; }
        public string classname { get; set; }
        public string time { get; set; }
        public string comment { get; set; } 

    }
}
