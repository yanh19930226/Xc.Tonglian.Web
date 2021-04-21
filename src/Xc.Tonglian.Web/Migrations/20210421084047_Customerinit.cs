using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xc.Tonglian.Web.Migrations
{
    public partial class Customerinit : Migration
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
                    City = table.Column<string>(nullable: true),
                    CardorBook = table.Column<string>(nullable: true),
                    BicCode = table.Column<string>(nullable: true),
                    Addr = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
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
                    IsDel = table.Column<bool>(nullable: false),
                    CtId = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Belongbranch = table.Column<string>(nullable: true),
                    Areacode = table.Column<string>(nullable: true),
                    Flag = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Cuskind = table.Column<string>(nullable: true),
                    Businesskind = table.Column<string>(nullable: true),
                    Threcertflag = table.Column<string>(nullable: true),
                    Creditcode = table.Column<string>(nullable: true),
                    Organcode = table.Column<string>(nullable: true),
                    Buslicense = table.Column<string>(nullable: true),
                    Creditcodeexpire = table.Column<string>(nullable: true),
                    Legalidno = table.Column<string>(nullable: true),
                    Legal = table.Column<string>(nullable: true),
                    Legalidexpire = table.Column<string>(nullable: true),
                    Businessplace = table.Column<string>(nullable: true),
                    Websitecountry = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Tradingplatform = table.Column<string>(nullable: true),
                    Stafftotal = table.Column<string>(nullable: true),
                    Protocolexpire = table.Column<string>(nullable: true),
                    Tlinstcode = table.Column<string>(nullable: true),
                    Holdername = table.Column<string>(nullable: true),
                    Holderidno = table.Column<string>(nullable: true),
                    Holderexpire = table.Column<string>(nullable: true),
                    Bnfname = table.Column<string>(nullable: true),
                    Bnfidno = table.Column<string>(nullable: true),
                    Bnfexpire = table.Column<string>(nullable: true),
                    Bnfaddress = table.Column<string>(nullable: true),
                    Legalemail = table.Column<string>(nullable: true),
                    Mers = table.Column<string>(nullable: true),
                    Accts = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
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
                    Mtid = table.Column<string>(nullable: true),
                    CusId = table.Column<string>(nullable: true),
                    MerName = table.Column<string>(nullable: true),
                    AreaCode = table.Column<string>(nullable: true),
                    OrganId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
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
                    AuthToken = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
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
