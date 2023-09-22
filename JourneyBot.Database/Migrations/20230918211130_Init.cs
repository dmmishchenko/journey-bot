using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JourneyBot.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BotMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IsCommand = table.Column<bool>(type: "boolean", nullable: false),
                    DateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsStoped = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JourneyId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PauseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CompleteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsPaused = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Journeys_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    InteractionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Journeys_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    StepId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    InteractionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Interactions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "Interactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Options_Journeys_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JourneyUserMessageDbModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Option = table.Column<int>(type: "integer", nullable: true),
                    UsersMessageId = table.Column<int>(type: "integer", nullable: true),
                    DateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyUserMessageDbModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
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
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionStepConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepId = table.Column<int>(type: "integer", nullable: false),
                    AwaitCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionStepConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionStepInteractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepId = table.Column<int>(type: "integer", nullable: false),
                    InteractionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionStepInteractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepId = table.Column<int>(type: "integer", nullable: false),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    ConditionId = table.Column<int>(type: "integer", nullable: false),
                    InteractionId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompleteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionSteps_SessionStepConditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "SessionStepConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSteps_SessionStepInteractions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "SessionStepInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSteps_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersActions",
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
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompleteDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
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
                name: "UserActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserMessageId = table.Column<int>(type: "integer", nullable: false),
                    ActionId = table.Column<int>(type: "integer", nullable: false),
                    OptionId = table.Column<int>(type: "integer", nullable: false),
                    DateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActions_JourneyUserMessageDbModel_UserMessageId",
                        column: x => x.UserMessageId,
                        principalTable: "JourneyUserMessageDbModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserActions_UsersActions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "UsersActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserActions_UsersOptions_OptionId",
                        column: x => x.OptionId,
                        principalTable: "UsersOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepId = table.Column<int>(type: "integer", nullable: false),
                    SecondsCount = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InteractionId = table.Column<int>(type: "integer", nullable: false),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    ConditionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Interactions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "Interactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Steps_Journeys_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Steps_StepConditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "StepConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_InteractionId",
                table: "Actions",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_SessionId",
                table: "Actions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_StepId",
                table: "Interactions",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyUserMessageDbModel_UsersMessageId",
                table: "JourneyUserMessageDbModel",
                column: "UsersMessageId");

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
                name: "IX_Options_InteractionId",
                table: "Options",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_SessionId",
                table: "Options",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_JourneyId",
                table: "Sessions",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionStepConditions_StepId",
                table: "SessionStepConditions",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionStepInteractions_StepId",
                table: "SessionStepInteractions",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSteps_ConditionId",
                table: "SessionSteps",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSteps_InteractionId",
                table: "SessionSteps",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSteps_SessionId",
                table: "SessionSteps",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_StepConditions_StepId",
                table: "StepConditions",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ConditionId",
                table: "Steps",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_InteractionId",
                table: "Steps",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_SessionId",
                table: "Steps",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_ActionId",
                table: "UserActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_OptionId",
                table: "UserActions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_UserMessageId",
                table: "UserActions",
                column: "UserMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersActions_InteractionId",
                table: "UsersActions",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOptions_InteractionId",
                table: "UsersOptions",
                column: "InteractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Interactions_InteractionId",
                table: "Actions",
                column: "InteractionId",
                principalTable: "Interactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Steps_StepId",
                table: "Interactions",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyUserMessageDbModel_Messages_UsersMessageId",
                table: "JourneyUserMessageDbModel",
                column: "UsersMessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UsersActions_ActionId",
                table: "Messages",
                column: "ActionId",
                principalTable: "UsersActions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UsersOptions_OptionId",
                table: "Messages",
                column: "OptionId",
                principalTable: "UsersOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionStepConditions_SessionSteps_StepId",
                table: "SessionStepConditions",
                column: "StepId",
                principalTable: "SessionSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionStepInteractions_SessionSteps_StepId",
                table: "SessionStepInteractions",
                column: "StepId",
                principalTable: "SessionSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StepConditions_Steps_StepId",
                table: "StepConditions",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Interactions_InteractionId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Journeys_JourneyId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Journeys_SessionId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_StepConditions_Steps_StepId",
                table: "StepConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionSteps_Sessions_SessionId",
                table: "SessionSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionStepConditions_SessionSteps_StepId",
                table: "SessionStepConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionStepInteractions_SessionSteps_StepId",
                table: "SessionStepInteractions");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "BotMessages");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "UserActions");

            migrationBuilder.DropTable(
                name: "JourneyUserMessageDbModel");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UsersActions");

            migrationBuilder.DropTable(
                name: "UsersOptions");

            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "Journeys");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "StepConditions");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "SessionSteps");

            migrationBuilder.DropTable(
                name: "SessionStepConditions");

            migrationBuilder.DropTable(
                name: "SessionStepInteractions");
        }
    }
}
