using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SofeDC.Models
{
    public class Notice
    {
        public int ID { get; set; }

        [Required]
        [Display(Name="通知标题")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "通知标题需要精简！")]
        public string Title { get; set; }

        [Url]
        [Required]
        public string ContentUrl { get; set; }

        [Required]
        [Display(Name = "发布者")]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "不符合规范！")]
        public string AnnouncedUser { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "发布日期")]
        public DateTime AnnouncedDate { get; set; }
    }
}
