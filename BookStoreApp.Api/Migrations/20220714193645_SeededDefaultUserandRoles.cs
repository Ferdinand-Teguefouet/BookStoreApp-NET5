using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Api.Migrations
{
    public partial class SeededDefaultUserandRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44b0c237-c427-48f4-93b6-5144cabd9a1f", "3826c27e-fb4c-456d-b36a-f7831033f7c8", "User", "USER" },
                    { "46c9b085-f259-479d-8fe6-f754eae48d74", "10fa3254-a3b2-4e2e-932b-0f057c2556a4", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30e613d1-072e-4d99-9927-ef001984de46", 0, "e01c7106-c854-4c37-a39d-019e5a4562cf", "admi@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEJ9ohQ681dQrjVC6cENeye/WFew2B7Z9iWIx9CYLAToCnl/YwYUBVN05KGMgxjUjHA==", null, false, "34244726-58e0-4e17-bee6-2c8892a9ffad", false, "admin@bookstore.com" },
                    { "366df5be-b4f8-4018-9f32-2ec5df2031b2", 0, "be6794fa-ac0d-43b3-853f-0087f0e6a316", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEPmb1/IOY14rqxoaqMyE6vh1eBAKDXR0iK7LJf/Tx+JklDt6giOM43lHvkdzn35JlQ==", null, false, "cdbb4012-349f-4de5-a058-daaf93a510a8", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "44b0c237-c427-48f4-93b6-5144cabd9a1f", "366df5be-b4f8-4018-9f32-2ec5df2031b2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46c9b085-f259-479d-8fe6-f754eae48d74", "30e613d1-072e-4d99-9927-ef001984de46" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46c9b085-f259-479d-8fe6-f754eae48d74", "30e613d1-072e-4d99-9927-ef001984de46" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "44b0c237-c427-48f4-93b6-5144cabd9a1f", "366df5be-b4f8-4018-9f32-2ec5df2031b2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b0c237-c427-48f4-93b6-5144cabd9a1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46c9b085-f259-479d-8fe6-f754eae48d74");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30e613d1-072e-4d99-9927-ef001984de46");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "366df5be-b4f8-4018-9f32-2ec5df2031b2");
        }
    }
}
