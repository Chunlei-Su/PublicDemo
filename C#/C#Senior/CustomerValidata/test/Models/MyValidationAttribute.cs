using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class MyValidationAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => "您的输入有误！";

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="value">输入的值</param>
        /// <param name="validationContext">验证上下文</param>
        /// <returns>成功返回Success，失败返回Result对象，可以通过遍历获取错误信息</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == "12")
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}

