using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models.Common
{
    public interface IRWXmlConfig
    {
        //读
        T ReadXmlData<T>(Func<XmlReader,T> operation);

        //写
        bool WriteXmlData(string xmlnodeName, string[] dataStrings);
    }
}
