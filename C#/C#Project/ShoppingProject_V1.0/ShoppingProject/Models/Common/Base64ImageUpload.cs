using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace ShoppingProject.Models.Common
{
    public static class Base64ImageUpload
    {
        /// <summary>
        /// 将base64文件保存到本地
        /// </summary>
        /// <param name="image">图片base64文件</param>
        /// <param name="imgext">图片原始扩展名</param>
        /// <param name="environmentpath">当前环境的根路径</param>
        /// <param name="customernumber">文件名</param>
        /// <returns></returns>
        public static bool OperationImageWithBase64(string image,string imgext,string environmentpath,string filename)
        {
            //检测文件
            if (image == null)
                return false;
            int index = image.IndexOf("base64,");
            if (index==-1)
                return false;
            try
            {
                index += 7;
                //转换数据
                var imgbit = Convert.FromBase64String(image.Substring(index));
                string imgname = $"{filename}.{imgext}";
                using (Image Imager=Image.FromStream(new MemoryStream(imgbit)))
                {
                   Imager.Save(environmentpath+imgname);
                }

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
