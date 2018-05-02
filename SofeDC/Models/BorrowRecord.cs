using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SofeDC.Models
{
    public class BorrowRecord
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int BookID { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 1, ErrorMessage = "请正确输入学号！")]
        public string UserNum { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "用户不存在！")]
        public string UserName { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "无法查阅到该记录！")]
        public string BookName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText ="未归还")]
        public DateTime ReturnDate { get; set; }

        [Required]
        public User User { get;set; }
        [Required]
        public Book Book { get; set;}
    }
}
