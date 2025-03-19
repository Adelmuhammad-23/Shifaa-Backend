using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShifaaAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Chats",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4aa063fe-b27b-4884-8819-4022d4234294");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2e715928-cc3d-43b6-ba7e-0c0080fa56e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a5cc1346-86d0-4c87-870e-4bc1846a685b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "83c643cd-e710-4ded-b266-b3576bec1389");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "f19ef6a6-3059-4664-bb39-fe2ac549d10f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "68b9ea44-ab75-462b-bdf7-ede6d4bc4440");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "e2de8a3a-4d1a-4072-978c-4c3e4d9b9d77");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "0ff770d3-2950-4ea6-a5e6-417e3af96f20");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "aa45bd93-a5c8-4350-97ad-fa3c24bed8b2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "f2df5a1c-d24e-4b39-b226-80675888e764");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "0472dd96-a5b8-44cb-ab1e-3ad83ba95a4a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "fa721d9e-8bfe-4b35-bbdb-9d72daa2d391");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "b2e7122d-0992-453f-80b7-b1d3c80abbea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "c1122608-dc70-4ba9-83c9-0b9b10bfa263");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "92e81871-8b32-4af5-be43-41d42a99f30b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "b6821cf6-b848-4e9f-9224-1757b2c22f8c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "9e6ce5df-694e-421f-9335-0ab11a19b617");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "ecea96c0-7825-47f7-945e-b84653c7049f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "8fd61505-bbaa-42c5-8846-cd29d4f3f3e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "24e5071a-3bd0-4270-b405-35c84bd02cce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "4de3a2de-9a7a-431b-b095-08b116a67e8e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "efee344f-2572-40b5-9a4f-4664f5839f0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "ConcurrencyStamp",
                value: "669bac73-f488-42b3-b459-e9f605bbb497");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "ConcurrencyStamp",
                value: "fb0e31f1-923c-4510-8e68-56a83afca2a5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Chats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3dd81d80-e513-4c27-99d3-7471c207a5d4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f489fca0-a78a-4a56-a835-2b64950e6017");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "de34d11a-aeb7-4590-923e-5153edf12c4a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "947daaa7-e1f7-4273-8bd4-509153ad4768");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "cf9a1805-42f3-4795-90ee-cf9de8786696");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "525a0e22-0da0-44ae-9cb2-b29d010a577e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "8f35b01f-95b9-49c6-a892-7cd1c87d50d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "2a837563-1042-494f-b8de-14523522aa20");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "36bf145d-f3a8-45d5-a34b-8981b3575850");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "ff2f98f1-e449-4984-ac5d-79d7502368d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "e52cd13a-fda4-4b7a-ac9c-d925a5ca6af4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "54cacb89-b957-4a5a-9a5d-11cb20a47771");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "ae44cadd-c71d-4437-8243-1821b4885e09");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "cc11b6e3-395e-46e6-8458-188538d272cf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "724ea922-f956-4260-84a1-97cb4554fb8d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "3368abd4-64e9-474a-b337-838fd24f9e91");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "b6a8c70a-1d07-4fcf-917f-67dafb64ed5d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "29d02f38-63bf-4681-868b-4bb6a8a9ea5e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "ddc2d5cc-69fd-4806-aa6d-a303292faa0c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "7a294bc6-e5e5-4b33-9cb7-3df1b4afe1fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "6a77c99f-293c-4cbf-bad4-a533a5aa6039");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "fc104a92-11e2-49a0-af61-a71ec73bde68");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "ConcurrencyStamp",
                value: "dc274259-15b1-43d2-933a-cae3dc7980cc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "ConcurrencyStamp",
                value: "4d3c0e09-4459-43ed-b1a9-25ac4c932202");
        }
    }
}
