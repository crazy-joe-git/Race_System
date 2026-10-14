using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Race_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParticipantSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Participant",
                keyColumn: "ParticipantID",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Email", "FirstName", "LastName", "PasswordHash", "Phone" },
                values: new object[] { new DateTime(1999, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "sim.sim@gmail.com", "Simphiwe", "Mkhize", "$2a$11$D8D/x0Avn1v7cYDjXLTdVeSWwM04.F9Z8pihZ5x07MDGsTNWGwaPC", "0681237631" });

            migrationBuilder.UpdateData(
                table: "Participant",
                keyColumn: "ParticipantID",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Email", "FirstName", "LastName", "PasswordHash", "Phone" },
                values: new object[] { new DateTime(2000, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "somizij@gmail.com", "Julius", "Somizi", "$2a$11$D8D/x0Avn1v7cYDjXLTdVeSWwM04.F9Z8pihZ5x07MDGsTNWGwaPC", "0789754432" });

            migrationBuilder.UpdateData(
                table: "Participant",
                keyColumn: "ParticipantID",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Email", "FirstName", "LastName", "PasswordHash", "Phone" },
                values: new object[] { new DateTime(2005, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "amahle.zulu@gmail.com", "Amahle", "Zulu", "$2a$11$D8D/x0Avn1v7cYDjXLTdVeSWwM04.F9Z8pihZ5x07MDGsTNWGwaPC", "0846862214" });

            migrationBuilder.UpdateData(
                table: "Participant",
                keyColumn: "ParticipantID",
                keyValue: 4,
                columns: new[] { "Email", "FirstName", "LastName", "PasswordHash", "Phone" },
                values: new object[] { "bonga.m@gmail.com", "Bonga", "Mqandi", "$2a$11$D8D/x0Avn1v7cYDjXLTdVeSWwM04.F9Z8pihZ5x07MDGsTNWGwaPC", "0671806529" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Participant",
                keyColumn: "ParticipantID",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Email", "FirstName", "LastName", "PasswordHash", "Phone" },
                values: new object[] { new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@gmail.com", "John", "Doe", "$2a$11$5tT750jQIZzSFtaJT0khauPq8gZDeCFsohtGy/.Nlft7WmiZacoLW", "5550101" });

            migrationBuilder.UpdateData(
                table: "Participant",
                keyColumn: "ParticipantID",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Email", "FirstName", "LastName", "PasswordHash", "Phone" },
                values: new object[] { new DateTime(1985, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@gmail.com", "Jane", "Smith", "$2a$11$5tT750jQIZzSFtaJT0khauPq8gZDeCFsohtGy/.Nlft7WmiZacoLW", "5550102" });

            migrationBuilder.UpdateData(
                table: "Participant",
                keyColumn: "ParticipantID",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Email", "FirstName", "LastName", "PasswordHash", "Phone" },
                values: new object[] { new DateTime(1992, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown@gmail.com", "Michael", "Brown", "$2a$11$5tT750jQIZzSFtaJT0khauPq8gZDeCFsohtGy/.Nlft7WmiZacoLW", "5550103" });

            migrationBuilder.UpdateData(
                table: "Participant",
                keyColumn: "ParticipantID",
                keyValue: 4,
                columns: new[] { "Email", "FirstName", "LastName", "PasswordHash", "Phone" },
                values: new object[] { "emily.davis@gmail.com", "Emily", "Davis", "$2a$11$5tT750jQIZzSFtaJT0khauPq8gZDeCFsohtGy/.Nlft7WmiZacoLW", "5550104" });
        }
    }
}
