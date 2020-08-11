﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OVR.DbContexts;

namespace OVR.DbContexts.Migrations
{
    [DbContext(typeof(MSDbContext))]
    partial class MSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OVR.Entities.Logrecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetRequestMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetRequestUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetUserAuthtype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetUserIdentity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetUserIsauthenticated")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logrecords");
                });

            modelBuilder.Entity("OVR.Entities.SysMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MenuIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenuSort")
                        .HasColumnType("int");

                    b.Property<int?>("MenuType")
                        .HasColumnType("int");

                    b.Property<string>("MenuUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("SysMenus");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            MenuIcon = "fa fa-home",
                            MenuName = "单位组织",
                            MenuSort = 1,
                            MenuType = 1
                        },
                        new
                        {
                            Id = 2L,
                            MenuIcon = "fa fa-gear",
                            MenuName = "系统管理",
                            MenuSort = 2,
                            MenuType = 1
                        },
                        new
                        {
                            Id = 10L,
                            MenuName = "部门管理",
                            MenuSort = 1,
                            MenuType = 2,
                            MenuUrl = "OrganizationManage/Department/DepartmentIndex",
                            ParentId = 1L
                        },
                        new
                        {
                            Id = 11L,
                            MenuName = "角色管理",
                            MenuSort = 1,
                            MenuType = 2,
                            MenuUrl = "SystemManage/LogOperate/LogOperateIndex",
                            ParentId = 2L
                        },
                        new
                        {
                            Id = 12L,
                            MenuName = "菜单管理",
                            MenuSort = 2,
                            MenuType = 2,
                            MenuUrl = "SystemManage/LogOperate/LogOperateIndex",
                            ParentId = 2L
                        },
                        new
                        {
                            Id = 13L,
                            MenuName = "系统日志",
                            MenuSort = 3,
                            MenuType = 2,
                            MenuUrl = "SystemManage/LogOperate/LogOperateIndex",
                            ParentId = 2L
                        },
                        new
                        {
                            Id = 14L,
                            MenuName = "定时任务",
                            MenuSort = 4,
                            MenuType = 2,
                            MenuUrl = "SystemManage/LogOperate/LogOperateIndex",
                            ParentId = 2L
                        });
                });

            modelBuilder.Entity("OVR.Entities.UserLogin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isSuperAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("UserLogins");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Account = "admin",
                            Name = "管理员",
                            Password = "admin",
                            isSuperAdmin = true
                        },
                        new
                        {
                            Id = 2L,
                            Account = "user",
                            Name = "普通用户",
                            Password = "user",
                            isSuperAdmin = false
                        });
                });

            modelBuilder.Entity("OVR.Entities.UserMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("SysMenuId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserLoginId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserMenus");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            SysMenuId = 1L,
                            UserLoginId = 2L
                        },
                        new
                        {
                            Id = 2L,
                            SysMenuId = 10L,
                            UserLoginId = 2L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
