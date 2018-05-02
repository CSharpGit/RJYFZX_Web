using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SofeDC.Models
{
    public class OurActivity
    {
        public int ID { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "标题名称需要精简！")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "活动说明")]
        public string Summary { get; set; }

        [Required]
        [Url]
        public string ContentUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "开始日期")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "结束日期")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "组织者")]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "不符合规范！")]
        public string Organizer { get; set; }
    }
}
