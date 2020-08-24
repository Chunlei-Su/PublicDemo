using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class PersonData:IValidatableObject
    {
        [StringLength(3)]
        [MyValidation]
        public string Name { get; set; }

        [Range(0, 100)]
        [Required]
        public int Age { get; set; }

        //public override string ToString()
        //{
        //    return Name + "   " + Age;
        //}

        /// <summary>
        /// 自身验证
        /// </summary>
        /// <param name="validationContext">验证上下文</param>
        /// <returns>错误列表</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Age==24)
            {
                yield return new ValidationResult(
                    $"您的输入有误 ", new []{nameof(Age)});
            }
        }
    }
}
