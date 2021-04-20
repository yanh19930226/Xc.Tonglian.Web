using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xc.Tonglian.Web.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false),
                    CusId = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    Nature = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    CardorBook = table.Column<string>(nullable: true),
                    BicCode = table.Column<string>(nullable: true),
                    Addr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false),
                    RegId = table.Column<string>(nullable: true),
                    CusId = table.Column<string>(nullable: true),
                    MerName = table.Column<string>(nullable: true),
                    AreaCode = table.Column<string>(nullable: true),
                    OrganId = table.Column<string>(nullable: true),
                    Products = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false),
                    StId = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Exists = table.Column<string>(nullable: true),
                    SellerId = table.Column<string>(nullable: true),
                    Monthamt = table.Column<int>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    StoreName = table.Column<string>(nullable: true),
                    Weburl = table.Column<string>(nullable: true),
                    Categroy = table.Column<string>(nullable: true),
                    Runtime = table.Column<int>(nullable: false),
                    AuthToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
