using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SofeDC.Models
{
    public enum BookIsBorrowedEnum
    {
        是,否
    }
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "书名超过限制！")]
        public string BookName { get; set; }//书名

        public string BookPublisher { get; set; }//出版社

        public string BookAuthor { get; set; }//作者

        public string BookSummary { get; set; }//摘要，简介

        public string BookISBN { get; set; }//图书ISBN编号

        [Url]
        public string BookImage { get; set; }//图书图片地址

        public string BookBinding { get; set; }//装订版本

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookPublishDate { get; set; }//出版时间

        public string BookAuthorInfo { get; set; }//作者简介

        public string BookType { get; set; }//图书分类

        [Required]
        public string BookIsBorrowed { get; set; }//借阅情况

        public string BookTranslator { get; set; }//翻译者

        public float BookPrice { get; set; }//图书价格

        [DataType(DataType.Date)]
        public DateTime BookAddDate { get; set; }//图书录入时间

        public ICollection<BorrowRecord> BorrowRecords { get; set; }
    }
}
