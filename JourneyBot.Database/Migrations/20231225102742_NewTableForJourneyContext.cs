using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JourneyBot.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewTableForJourneyContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneyUserMessageDbModel_Messages_UsersMessageId",
                table: "JourneyUserMessageDbModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActions_JourneyUserMessageDbModel_UserMessageId",
                table: "UserActions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActions_UsersActions_ActionId",
                table: "UserActions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActions_UsersOptions_OptionId",
                table: "UserActions");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UsersActions");

            migrationBuilder.DropTable(
                name: "UsersOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActions",
                table: "UserActions");

            migrationBuilder.RenameTable(
                name: "UserActions",
                newName: "UserInteractions");

            migrationBuilder.RenameIndex(
                name: "IX_UserActions_UserMessageId",
                table: "UserInteractions",
                newName: "IX_UserInteractions_UserMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserActions_OptionId",
                table: "UserInteractions",
                newName: "IX_UserInteractions_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserActions_ActionId",
                table: "UserInteractions",
                newName: "IX_UserInteractions_ActionId");

            migrationBuilder.AlterColumn<int>(
                name: "ActionId",
                table: "UserInteractions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInteractions",
                table: "UserInteractions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SessionActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InteractionId = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompleteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VoteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionActions_SessionStepInteractions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "SessionStepInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InteractionId = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompleteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VoteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionOptions_SessionStepInteractions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "SessionStepInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersSessionMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    ActionId = table.Column<int>(type: "integer", nullable: false),
                    OptionId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSessionMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersSessionMessages_SessionActions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "SessionActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersSessionMessages_SessionOptions_OptionId",
                        column: x => x.OptionId,
                        principalTable: "SessionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersSessionMessages_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionActions_InteractionId",
                table: "SessionActions",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionOptions_InteractionId",
                table: "SessionOptions",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSessionMessages_ActionId",
                table: "UsersSessionMessages",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSessionMessages_OptionId",
                table: "UsersSessionMessages",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSessionMessages_SessionId",
                table: "UsersSessionMessages",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyUserMessageDbModel_UsersSessionMessages_UsersMessage~",
                table: "JourneyUserMessageDbModel",
                column: "UsersMessageId",
                principalTable: "UsersSessionMessages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInteractions_JourneyUserMessageDbModel_UserMessageId",
                table: "UserInteractions",
                column: "UserMessageId",
                principalTable: "JourneyUserMessageDbModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInteractions_SessionActions_ActionId",
                table: "UserInteractions",
                column: "ActionId",
                principalTable: "SessionActions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInteractions_SessionOptions_OptionId",
                table: "UserInteractions",
                column: "OptionId",
                principalTable: "SessionOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneyUserMessageDbModel_UsersSessionMessages_UsersMessage~",
                table: "JourneyUserMessageDbModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInteractions_JourneyUserMessageDbModel_UserMessageId",
                table: "UserInteractions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInteractions_SessionActions_ActionId",
                table: "UserInteractions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInteractions_SessionOptions_OptionId",
                table: "UserInteractions");

            migrationBuilder.DropTable(
                name: "UsersSessionMessages");

            migrationBuilder.DropTable(
                name: "SessionActions");

            migrationBuilder.DropTable(
                name: "SessionOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInteractions",
                table: "UserInteractions");

            migrationBuilder.RenameTable(
                name: "UserInteractions",
                newName: "UserActions");

            migrationBuilder.RenameIndex(
                name: "IX_UserInteractions_UserMessageId",
                table: "UserActions",
                newName: "IX_UserActions_UserMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInteractions_OptionId",
                table: "UserActions",
                newName: "IX_UserActions_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInteractions_ActionId",
                table: "UserActions",
                newName: "IX_UserActions_ActionId");

            migrationBuilder.AlterColumn<int>(
                name: "ActionId",
                table: "UserActions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActions",
                table: "UserActions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InteractionId = table.Column<int>(type: "integer", nullable: false),
                    CompleteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    VoteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersActions_SessionStepInteractions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "SessionStepInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InteractionId = table.Column<int>(type: "integer", nullable: false),
                    CompleteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    VoteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersOptions_SessionStepInteractions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "SessionStepInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActionId = table.Column<int>(type: "integer", nullable: false),
                    OptionId = table.Column<int>(type: "integer", nullable: false),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_UsersActions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "UsersActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_UsersOptions_OptionId",
                        column: x => x.OptionId,
                        principalTable: "UsersOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ActionId",
                table: "Messages",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_OptionId",
                table: "Messages",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SessionId",
                table: "Messages",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersActions_InteractionId",
                table: "UsersActions",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOptions_InteractionId",
                table: "UsersOptions",
                column: "InteractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyUserMessageDbModel_Messages_UsersMessageId",
                table: "JourneyUserMessageDbModel",
                column: "UsersMessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActions_JourneyUserMessageDbModel_UserMessageId",
                table: "UserActions",
                column: "UserMessageId",
                principalTable: "JourneyUserMessageDbModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActions_UsersActions_ActionId",
                table: "UserActions",
                column: "ActionId",
                principalTable: "UsersActions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActions_UsersOptions_OptionId",
                table: "UserActions",
                column: "OptionId",
                principalTable: "UsersOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
