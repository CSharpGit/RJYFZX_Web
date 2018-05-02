using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SofeDC.Models
{
    public class Meeting
    {
        public int ID { get; set; }

        [Required]
        [Display(Name ="会议名称")]
        [StringLength(64,MinimumLength =1,ErrorMessage = "会议名称需要精简！")]
        public string MettingName { get; set; }

        [Required]
        [Display(Name = "会议摘要")]
        public string MettingSummary { get; set; }

        [Required]
        [Display(Name = "会议总结")]
        [Url]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "未提交")]
        public string MettingDetailsUrl { get; set; }

        [Required]
        [Display(Name = "发言人")]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "名字不符合规范！")]
        public string Spokesman { get; set; }

        [Required]
        [Display(Name = "参与者")]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "不符合规范！")]
        public string AttendUser { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "开始时间")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "结束时间")]
        public DateTime EndTime { get; set; }
    }
}
