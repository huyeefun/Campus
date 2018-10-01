using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Campus.Models
{
    public class HomeworkInputModel
    {
        [Required(ErrorMessage = "标题不能为空！")]
        [MinLength(1, ErrorMessage = "标题长度不能少于1个字符")]
        [MaxLength(100, ErrorMessage = "标题长度不能大于100个字符！")]
        public string Title { get; set; }
        [Required(ErrorMessage = "内容不能为空！")]
        [MinLength(1, ErrorMessage = "内容长度不能少于1个字符")]
        public string Content { get; set; }
    }
}
