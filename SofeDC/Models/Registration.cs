using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SofeDC.Models
{
    public class Registration
    {
        //[NotMapped]
        //public List<string> UserLables { get; set; }

        public int ID { get; set; }

        [NotMapped]
        [Display(Name = "兴趣方向")]
        public IEnumerable<SelectListItem> Intersts { get; set; }

        [Required]
        [Display(Name ="学号")]
        [StringLength(13, ErrorMessage = "请正确输入学号！")]
        public string UserNum { get; set; }

        [Required]
        [Display(Name = "姓名")]
        [StringLength(32, ErrorMessage = "名字也太长了吧！")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "性别")]
        [StringLength(8, ErrorMessage = "不符合规范！")]
        public string UserSex { get; set; }

        [Required]
        [Display(Name = "学院")]
        [StringLength(64, ErrorMessage = "不符合规范！")]
        public string UserAcademy { get; set; }

        [Required]
        [Display(Name = "专业及班级")]
        [StringLength(32, ErrorMessage = "不符合规范！")]
        public string UserClass { get; set; }

        [Phone]
        [StringLength(11, ErrorMessage = "请填写有效的电话号码！", MinimumLength = 7)]
        [Display(Name = "电话")]
        public string UserPhone { get; set; }

        [Display(Name = "QQ")]
        [StringLength(12, ErrorMessage = "无法识别您的QQ号码", MinimumLength = 8)]
        public string QQ { get; set; }

        [Display(Name = "微信")]
        [StringLength(16, ErrorMessage = "无法识别您的微信账号！", MinimumLength = 3)]
        public string WeChat { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(32, ErrorMessage = "无法识别您的Email地址，请填入的Email地址！")]
        public string UserEmail { get; set; }

        [Display(Name = "兴趣方向")]
        [DisplayFormat(NullDisplayText = "未选择")]
        public string Interest { get; set; }

        [Required]
        [Display(Name = "届级")]
        [StringLength(16, ErrorMessage = "不符合规范！")]
        public string UserLable { get; set; }


    }
}
