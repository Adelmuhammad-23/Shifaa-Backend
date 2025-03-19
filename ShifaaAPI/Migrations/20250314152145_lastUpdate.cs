using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShifaaAPI.Migrations
{
    /// <inheritdoc />
    public partial class lastUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "age",
                table: "Patients",
                newName: "Age");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1c5186d4-20bf-42e5-b75f-611bcdc32a82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "52bc66d4-63d9-489a-a77f-731d04b94c99");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8d4e70aa-07ac-4c46-a0b4-21019128e8d4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "e6fcfc09-fa81-4467-8c74-b24aec8b3804");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "5c0edd0e-1ed6-434c-8a24-6d355b1b39ca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "e60cb94c-a0be-4480-87d2-0eddbc419a87");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "f9e34fab-e805-4287-aeb0-bbc4631cbcb6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "44c6a3c0-9924-4851-8586-0038058d6c97");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "aa71f5e9-75a0-45b1-a77a-30ea22051d06");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "cb8b2c28-9f02-40e3-864d-52de6444537d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "bf17974f-51e5-432b-8949-3a1b1a6ccf6e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "f893701e-7734-4ca2-b489-98205ee94632");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "63d2501f-4dcb-40ca-85e0-c69c78943f01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "cd38a193-174c-4335-ba14-84429c3fc2ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "de2a1d6d-2ac5-4c1e-b1b6-c2ba5e1a4ff1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "14792f62-f10d-443c-9b2a-f90972cc0dd4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "0f432a61-21da-475d-b4d3-701558304728");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "2c66aa35-b503-4ece-b0dc-1ff71cfd6291");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "1e91d884-145d-4829-af68-aed077358301");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "db031a2f-aeef-49b7-b7b0-53c2051e0469");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "4f047a08-ebe8-48a3-9137-25c096daf3e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "73badd1d-fc96-4824-9372-1e66c61aa6e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "ConcurrencyStamp",
                value: "b3510d6b-4182-4772-ae40-f128ead29f32");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "ConcurrencyStamp",
                value: "fc0605c5-25a1-4cc0-ae14-72e1b4f1cd2b");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Patients",
                newName: "age");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "17695fdc-7792-4949-b006-982ccef41dcb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "35d0bd86-b269-4ed4-81a3-03fc478facde");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "31c26307-0c7c-4e90-9acd-ef7764bb1b9e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "1664ec7b-699c-4865-be88-00b657710841");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "e4eab79b-855b-4d92-aec8-f4986910cbb8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "6397f9e8-a72d-4b59-84c0-44b4cca7824f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "02c3332f-ae9d-4b29-82e9-e7085c9c7f01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "176fb3db-73c9-47c7-98ab-0018bbdb7f04");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "42690b7a-af65-4512-84ed-1877cb47585a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "e7a8345c-c2cc-43e8-9be3-7eff537bc848");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "a506a546-ddf3-4342-9a72-f00f8df704e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "b97ef50b-160d-43a7-a3e3-ceced1194659");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "e73079f9-85cd-47ab-a6f6-75e500c2e063");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "fa3b335f-7b6d-4ee7-b5d8-0753fe645477");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "903892a2-301e-4b63-9f2a-83f5ff339982");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "1e78c76b-6527-40cb-9f22-b7dfb5d45f76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "693e3aab-db5e-4c78-871b-9a0e2d7e4d5d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "61332d72-db5d-4a2e-bcc6-069cececcbce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "694fbcce-05bc-468f-b6dc-f732f3344e72");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "5d7858de-7da2-49b2-bc7f-d6d1266ea532");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "e35a3a02-24fe-4a49-b586-29efce3eacde");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "2168896f-b7c1-4b73-960b-87417b5bc9d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "ConcurrencyStamp",
                value: "7afb984c-8ba8-4f77-b0f6-ed0c8d23d98a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "ConcurrencyStamp",
                value: "486ee8fa-ffaa-4cc8-b671-a123005653f8");
        }
    }
}
