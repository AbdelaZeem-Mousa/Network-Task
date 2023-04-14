﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Network.API.Migrations
{
    /// <inheritdoc />
    public partial class spGetStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetStudents]
                    @Name varchar(250)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Students where Name like @Name +'%'
                END";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
