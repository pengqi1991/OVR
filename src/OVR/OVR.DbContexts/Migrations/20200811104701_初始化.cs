using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OVR.DbContexts.Migrations
{
    public partial class 初始化 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logrecords",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogDate = table.Column<DateTime>(nullable: false),
                    LogLevel = table.Column<string>(nullable: true),
                    Logger = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true),
                    MachineName = table.Column<string>(nullable: true),
                    MachineIp = table.Column<string>(nullable: true),
                    NetRequestMethod = table.Column<string>(nullable: true),
                    NetRequestUrl = table.Column<string>(nullable: true),
                    NetUserIsauthenticated = table.Column<string>(nullable: true),
                    NetUserAuthtype = table.Column<string>(nullable: true),
                    NetUserIdentity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logrecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysMenus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    MenuIcon = table.Column<string>(nullable: true),
                    MenuUrl = table.Column<string>(nullable: true),
                    MenuSort = table.Column<int>(nullable: true),
                    MenuType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    isSuperAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMenus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SysMenuId = table.Column<long>(nullable: false),
                    UserLoginId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMenus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SysMenus",
                columns: new[] { "Id", "MenuIcon", "MenuName", "MenuSort", "MenuType", "MenuUrl", "ParentId" },
                values: new object[,]
                {
                    { 1L, "fa fa-home", "单位组织", 1, 1, null, null },
                    { 2L, "fa fa-gear", "系统管理", 2, 1, null, null },
                    { 10L, null, "部门管理", 1, 2, "OrganizationManage/Department/DepartmentIndex", 1L },
                    { 11L, null, "角色管理", 1, 2, "SystemManage/LogOperate/LogOperateIndex", 2L },
                    { 12L, null, "菜单管理", 2, 2, "SystemManage/LogOperate/LogOperateIndex", 2L },
                    { 13L, null, "系统日志", 3, 2, "SystemManage/LogOperate/LogOperateIndex", 2L },
                    { 14L, null, "定时任务", 4, 2, "SystemManage/LogOperate/LogOperateIndex", 2L }
                });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "Id", "Account", "Name", "Password", "isSuperAdmin" },
                values: new object[,]
                {
                    { 1L, "admin", "管理员", "admin", true },
                    { 2L, "user", "普通用户", "user", false }
                });

            migrationBuilder.InsertData(
                table: "UserMenus",
                columns: new[] { "Id", "SysMenuId", "UserLoginId" },
                values: new object[,]
                {
                    { 1L, 1L, 2L },
                    { 2L, 10L, 2L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logrecords");

            migrationBuilder.DropTable(
                name: "SysMenus");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserMenus");
        }
    }
}
