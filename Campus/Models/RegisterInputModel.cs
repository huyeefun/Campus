using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Campus.Models
{
    public class RegisterInputModel
    {
        [Required(ErrorMessage ="用户名不能为空！")]
        [MinLength(2,ErrorMessage ="用户名长度不能少于2个字符")]
        [MaxLength(20,ErrorMessage ="用户名长度不能大于20个字符！")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="密码不能为空!")]
        [MinLength(8,ErrorMessage ="密码长度不能小于8个字符！")]
        [MaxLength(20,ErrorMessage ="密码长度不能大于20个字符！")]
        public string Password { get; set; }
        public bool IsTeacher { get; set; }
    }
}
