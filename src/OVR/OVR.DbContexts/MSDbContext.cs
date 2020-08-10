using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OVR.Common.Security;
using OVR.Entities;
using OVR.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OVR.DbContexts
{
    public class MSDbContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Logrecord> Logrecords { get; set; }


        //Add-Migration InitialCreate
        //Update-Database InitialCreate
        public MSDbContext(DbContextOptions<MSDbContext> options)
           : base(options)
        {
        }
        //此处用微软原生的控制台日志记录，如果使用NLog很可能数据库还没创建，造成记录日志到数据库性能下降（一直在尝试连接数据库，但是数据库还没创建）
        //此处使用静态实例，这样不会为每个上下文实例创建新的 ILoggerFactory 实例，这一点非常重要。 否则会导致内存泄漏和性能下降。
        //此处使用了Debug和console两种日志输出，会输出到控制台和调试窗口
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddDebug().AddConsole());
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            long rootUserId = 1219490056771866624;
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1219490056771866625,
                Name = "SuperAdmin",
                DisplayName = "超级管理员",
                Remark = "系统内置超级管理员",
                Creator = rootUserId,
                CreateTime = DateTime.Now
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = rootUserId,
                Account = "admin",
                Name = "admin",
                RoleId = 1219490056771866625,
                StatusCode = StatusCode.Enable,
                Creator = rootUserId,
                CreateTime = DateTime.Now,
            });
            modelBuilder.Entity<UserLogin>().HasData(new UserLogin
            {
                UserId = rootUserId,
                Account = "admin",
                HashedPassword = Crypto.HashPassword("admin"),//默认密码同账号名
                IsLocked = false
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
