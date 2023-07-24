﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyAuthServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class addBirthDayToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "AspNetUsers");
        }
    }
}
