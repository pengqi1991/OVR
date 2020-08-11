using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OVR.DbContexts.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logrecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<int>(nullable: false),
                    Creator = table.Column<long>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<long>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<int>(nullable: false),
                    Creator = table.Column<long>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Modifier = table.Column<long>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Account = table.Column<string>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    HashedPassword = table.Column<string>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    LockedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Account);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateTime", "Creator", "DisplayName", "Modifier", "ModifyTime", "Name", "Remark", "StatusCode" },
                values: new object[] { 1219490056771866625L, new DateTime(2020, 8, 11, 15, 44, 13, 329, DateTimeKind.Local).AddTicks(8814), 1219490056771866624L, "超级管理员", null, null, "SuperAdmin", "系统内置超级管理员", 0 });

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
                table: "Users",
                columns: new[] { "Id", "Account", "CreateTime", "Creator", "Email", "Modifier", "ModifyTime", "Name", "Phone", "RoleId", "StatusCode" },
                values: new object[] { 1219490056771866624L, "admin", new DateTime(2020, 8, 11, 15, 44, 13, 330, DateTimeKind.Local).AddTicks(3004), 1219490056771866624L, null, null, null, "admin", null, 1219490056771866625L, 0 });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "Account", "AccessFailedCount", "HashedPassword", "IsLocked", "LastLoginTime", "LockedTime", "UserId" },
                values: new object[] { "admin", 0, "admin", false, null, null, 1219490056771866624L });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
