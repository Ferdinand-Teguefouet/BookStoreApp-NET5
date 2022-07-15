using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Api.Migrations
{
    public partial class cls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b0c237-c427-48f4-93b6-5144cabd9a1f",
                column: "ConcurrencyStamp",
                value: "b41e0a8f-7da5-4412-b861-5d75dcf73df1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46c9b085-f259-479d-8fe6-f754eae48d74",
                column: "ConcurrencyStamp",
                value: "eeba46a4-0471-4c49-9ba8-3c06ef4230f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30e613d1-072e-4d99-9927-ef001984de46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ca80ea5-5721-46ae-928d-3fdb4c4e5771", "AQAAAAEAACcQAAAAEA9EyC5dbQCXVkoOdzrF/gm/d3QVbnA0rbMeTEFFZJovHiAAyxgn3GMqzpJRonN33g==", "183472df-2578-4a37-b08a-aa478ae2e281" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "366df5be-b4f8-4018-9f32-2ec5df2031b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53b914ef-18d5-44f1-b7fa-cef7c6424c52", "AQAAAAEAACcQAAAAENg0kwwIKaCxARsY4rMLITCrQ8rsHSVgPpSkjNaDUmukc9jCb6DAa2exTU7kEKczgg==", "671d6651-d407-452b-ab63-4b2f26cf1c5e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b0c237-c427-48f4-93b6-5144cabd9a1f",
                column: "ConcurrencyStamp",
                value: "3826c27e-fb4c-456d-b36a-f7831033f7c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46c9b085-f259-479d-8fe6-f754eae48d74",
                column: "ConcurrencyStamp",
                value: "10fa3254-a3b2-4e2e-932b-0f057c2556a4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30e613d1-072e-4d99-9927-ef001984de46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e01c7106-c854-4c37-a39d-019e5a4562cf", "AQAAAAEAACcQAAAAEJ9ohQ681dQrjVC6cENeye/WFew2B7Z9iWIx9CYLAToCnl/YwYUBVN05KGMgxjUjHA==", "34244726-58e0-4e17-bee6-2c8892a9ffad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "366df5be-b4f8-4018-9f32-2ec5df2031b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be6794fa-ac0d-43b3-853f-0087f0e6a316", "AQAAAAEAACcQAAAAEPmb1/IOY14rqxoaqMyE6vh1eBAKDXR0iK7LJf/Tx+JklDt6giOM43lHvkdzn35JlQ==", "cdbb4012-349f-4de5-a058-daaf93a510a8" });
        }
    }
}
