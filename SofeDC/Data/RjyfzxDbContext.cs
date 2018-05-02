using System;
using Microsoft.EntityFrameworkCore;
using SofeDC.Models;

namespace SoftDC.Data

{
    public class RjyfzxDbContext: DbContext
    {
        //数据库中的所有表
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OurActivity> OurActivities { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<SuggestionBox> SuggestionBoies { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }

        public RjyfzxDbContext(DbContextOptions<RjyfzxDbContext> options)
    : base(options)
        {
            //Migration - create Tables
            try
            {
                ///注意！
                ///EnsureDeleted()方法和EnsureCreated()方法用于第一次连接数据库，完成对应实体的表的建立。正式使用时应注释掉，不然每次调用数据上下文都会删除原有数据库，再重新创建数据库，导致页面不显示录入结果。
                ///
                //this.Database.EnsureDeleted();//检查数据库是否存在，如果存在删除该数据库，如果不存在，跳过该动作事件。

                //this.Database.EnsureCreated();//检查数据库是否创建，如果未创建，创建该数据库，如果已创建，跳过该动作事件。
                //this.Database.Migrate();// 数据迁移
            }
            catch (Exception ex)
            {
            }
        }

        //根据实体ID同步数据
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().Property(b => b.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(b => b.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<OurActivity>().Property(b => b.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Meeting>().Property(b => b.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<SuggestionBox>().Property(b => b.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Notice>().Property(b => b.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property(b => b.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<BorrowRecord>().Property(b => b.ID).ValueGeneratedOnAdd();

        }
    }
}
