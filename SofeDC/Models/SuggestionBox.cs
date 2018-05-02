using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SofeDC.Models
{
    public enum IsReadEnum
    {
        是,否
    }
    public class SuggestionBox
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        [Required]
        [Display(Name = "我的名字")]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "用户不存在！")]
        public string FromUser { get; set; }

        [Required]
        [Display(Name = "我的学号")]
        [StringLength(13, ErrorMessage = "请正确填写学号，以便给您反馈！")]
        public string FromUserNum { get; set; }

        [Required]
        [Display(Name = "我的建议")]
        public string SuggesContent { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1, ErrorMessage = "不符合规范！")]
        public string IsRad { get; set; }

        [Required]
        [Url]
        public string FromWhere { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SuggesDate { get; set; }

        public User User { get; set; }
    }
}
