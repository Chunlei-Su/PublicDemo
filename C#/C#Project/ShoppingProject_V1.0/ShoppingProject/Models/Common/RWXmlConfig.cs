using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ShoppingProject.Models.Common
{
    /// <summary>
    /// 用于xml配置文件的读取于写入
    /// </summary>
    public class RWXmlConfig : IRWXmlConfig
    {
        private string xmlPath = string.Empty;
        public RWXmlConfig(IConfiguration configuration)
        {
            //从配置文件中读取xml文件的路径
            xmlPath = configuration["XmlPath"];
        }

        /// <summary>
        /// 读取数xml数据
        /// </summary>
        /// <typeparam name="T">返回值</typeparam>
        public T ReadXmlData<T>(Func<XmlReader, T> operation)
        {
            XmlReader xmlReader = null;
            if (File.Exists(xmlPath))
                xmlReader = XmlReader.Create(xmlPath);
            else
                throw new Exception("xml文件未找到！");

            if (xmlReader.HasValue)
                throw new Exception("Xml文件为空！");
            return operation.Invoke(xmlReader);
        }

        /// <summary>
        /// 写入xml数据
        /// </summary>
        /// <param name="xmlnodeName">节点名</param>
        /// <param name="dataStrings">数据集，每一条字符串的内容为：属性名+逗号+属性值</param>
        /// <returns></returns>
        public bool WriteXmlData(string xmlnodeName, string[] dataStrings)
        {
            //获取要写入的条数
            byte sum = (byte)dataStrings.Length;
            XmlDocument xmlDocument = new XmlDocument();
            if (File.Exists(xmlPath))
                xmlDocument.Load(xmlPath);
            else
                throw new Exception("xml文件未找到！");
            try
            {
                //删除旧节点

                foreach (XmlNode node in xmlDocument)
                {
                    if (node.Name == xmlnodeName)
                    {
                        node.RemoveAll();
                        sum--;
                    }
                    if (sum == 0)
                        break;
                }
                //创建节点
                XmlElement element = xmlDocument.CreateElement(xmlnodeName);
                for (byte i = 0; i < (byte)dataStrings.Length; i++)
                {
                    string[] data = dataStrings[i].Split('|');
                    element.SetAttribute(data[0], data[1]);
                }

                xmlDocument.DocumentElement.AppendChild(element);
                xmlDocument.Save(xmlPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;

        }
    }
}
