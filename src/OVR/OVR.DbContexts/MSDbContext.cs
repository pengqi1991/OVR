using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using OVR.Entities;
using OVR.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OVR.DbContexts
{
    public class MSDbContext : DbContext
    {

        public DbSet<SysMenu> SysMenus { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }


        public DbSet<Logrecord> Logrecords { get; set; }

        public DbSet<UserMenu> UserMenus { get; set; }




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
            //菜单
            modelBuilder.Entity<SysMenu>().HasData(new List<SysMenu>()
            {
                new SysMenu{Id = 1,MenuName ="单位组织",MenuIcon ="fa fa-home",MenuSort=1,MenuType =1},
                new SysMenu{Id = 2,MenuName ="系统管理",MenuIcon ="fa fa-gear",MenuSort=2,MenuType =1},
              

                new SysMenu{Id = 10,MenuName ="部门管理",ParentId=1,MenuUrl="OrganizationManage/Department/DepartmentIndex",MenuSort=1,MenuType =2},
                new SysMenu{Id = 11,MenuName ="角色管理",ParentId=2,MenuUrl="SystemManage/LogOperate/LogOperateIndex",MenuSort=1,MenuType =2},
                new SysMenu{Id = 12,MenuName ="菜单管理",ParentId=2,MenuUrl="SystemManage/LogOperate/LogOperateIndex",MenuSort=2,MenuType =2},
                new SysMenu{Id = 13,MenuName ="系统日志",ParentId=2,MenuUrl="SystemManage/LogOperate/LogOperateIndex",MenuSort=3,MenuType =2},
                new SysMenu{Id = 14,MenuName ="定时任务",ParentId=2,MenuUrl="SystemManage/LogOperate/LogOperateIndex",MenuSort=4,MenuType =2},

            });

            //用户
            modelBuilder.Entity<UserLogin>().HasData(new List<UserLogin> {
                 new UserLogin{Id = 1,Name = "管理员",Account = "admin",Password = "admin",isSuperAdmin = true },
                 new UserLogin{Id = 2,Name = "普通用户",Account = "user",Password = "user",isSuperAdmin = false }
            });
            //用户拥有的菜单
            modelBuilder.Entity<UserMenu>().HasData(new List<UserMenu>
            {
                new UserMenu{ Id  = 1, UserLoginId = 2 ,SysMenuId  =  1},
                new UserMenu{ Id  = 2, UserLoginId = 2 ,SysMenuId  =  10},
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
