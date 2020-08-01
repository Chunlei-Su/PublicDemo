using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EDUC学生管理系统
{
    public class Check
    {
        /// <summary>
        /// 检查用户名和密码是否符合要求
        /// </summary>
        /// <returns>bool</returns>
        public bool CheckUserPsd(string user, string psd)
        {
            string patten1 = @"^[0-9a-zA-z]{6}$";
            if (!Regex.IsMatch(user.Trim(), patten1))
            {
                return false;
            }
            string patten2 = @"[0-9]{6}$";
            if (!Regex.IsMatch(psd.Trim(), patten2))
            {
                return false;
            }
            return true;
        }
        
        
        /// <summary>
        /// 检查插入数据的格式
        /// </summary>
        /// <param name="sid">学号</param>
        /// <param name="sname">姓名</param>
        /// <param name="AScores">成绩</param>
        /// <returns>说明字符串</returns>
        public string CheckInsertData(string sid,string sname,string AScores)
        {
            string patten = @"^[0-9]{10}$";
            if (!Regex.IsMatch(sid, patten))
            {
                return "学号为10位数字";
            }
            patten = "^[\u4e00-\u9fa5]{1,4}$";
            if (!Regex.IsMatch(sname, patten))
            {
                return "姓名最大为4个汉字";
            }
            patten = "^[0-9]+(.[0-9]{1}){1,3}$";
            if (!Regex.IsMatch(AScores, patten))
            {
                return "成绩精确到小数点后一位。";
            }
            if (Convert.ToDouble(AScores) > 750)
            {
                return "成绩超出最大值。";
            }
            return "true";
        }
    }
}
