using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SofeDC.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "学号")]
        [StringLength(13, ErrorMessage = "请正确输入学号！")]
        public string UserNum { get; set; }

        [Required]
        [Display(Name = "姓名")]
        [StringLength(32, ErrorMessage = "名字也太长了吧！")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "性别")]
        [StringLength(4, ErrorMessage = "有点常识没有！")]
        public string UserSex { get; set;}

        [Required]
        [Display(Name = "密码")]
        [StringLength(32, ErrorMessage = "密码不符合规范！")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required]
        [Display(Name = "专业及班级")]
        [StringLength(32, ErrorMessage = "名字也太长了吧！")]
        public string UserClass { get; set; }

        [Required]
        [Display(Name = "学院")]
        [StringLength(64, ErrorMessage = "不符合规范！")]
        public string UserAcademy { get; set; }

        [Required]
        [Display(Name = "所属小组")]
        [StringLength(32, ErrorMessage = "请不要编造小组名称！", MinimumLength = 2)]
        public string UserGroup { get; set; }

        [Phone]
        [StringLength(11, ErrorMessage = "请填写有效的电话号码！", MinimumLength = 3)]
        [Display(Name = "电话")]
        public string UserPhone { get; set; }

        [Display(Name = "QQ")]
        [StringLength(12, ErrorMessage = "无法识别您的QQ号码", MinimumLength = 8)]
        public string QQ { get; set; }

        [Display(Name = "微信")]
        [StringLength(16, ErrorMessage = "无法识别您的微信账号！",MinimumLength =3)]
        public string WeChat { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(32, ErrorMessage = "无法识别您的Email地址，请填入的Email地址！")]
        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "职位类型")]
        [StringLength(16, ErrorMessage = "请勿随便编造职位类型！")]
        //[NotMapped] //这可以防止EntityFramework将列表映射到模型。由于它不是模型数据库的一部分，因此不需要主键。
        public string UserPositionType { get; set; }

        [Required]
        [Display(Name = "职位名称")]
        [StringLength(64, ErrorMessage = "不符合规范！")]
        public string  UserPosition { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "不符合规范！")]
        [Display(Name = "用户状态")]
        public string UserStatus { get; set; }

        [Display(Name = "师傅")]
        [StringLength(32, ErrorMessage = "不符合规范！")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "暂无")]
        public string UserMaster { get; set; }

        [Display(Name = "徒弟")]
        [StringLength(32, ErrorMessage = "不符合规范！")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "暂无")]
        public string UserApprentice { get; set; }

        [Required]
        [Display(Name = "届级")]
        [DisplayFormat(NullDisplayText = "未选择")]
        [StringLength(16, ErrorMessage = "不符合规范！")]
        public string UserLable { get; set; }

        //[Display(Name = "个人近期照片")]
        //[FileExtensions(Extensions = ".jpg,.png", ErrorMessage = "图片格式错误")]
        //public IFormFile PersonalImage { get; set; }

        [Display(Name = "个人简介")]
        public string PersonalIntroduction{ get; set; }

        [Display(Name = "工作属性")]
        [StringLength(16, MinimumLength = 1, ErrorMessage = "不符合规范！")]
        public string WorkType { get; set; }

        [Display(Name = "工作单位")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "字数受限制！")]
        public string WorkPlace { get; set; }

        [Display(Name = "工作职位")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "字数受限制！")]
        public string WorkPosition { get; set; }

        [Display(Name = "所在学校")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "字数受限制！")]
        public string University { get; set; }

        [Display(Name = "专业方向")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "字数受限制！")]
        public string Professional { get; set; }

        [Display(Name = "寄语及留言")]
        public string Message { get; set; }

        [Display(Name = "加入时间")]
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }//录入信息时间

        public ICollection<BorrowRecord> BorrowRecords { get; set; }
        public SuggestionBox SuggestionBox { get; set; }
    }
}
