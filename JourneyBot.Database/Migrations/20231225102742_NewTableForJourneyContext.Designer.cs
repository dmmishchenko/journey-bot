﻿// <auto-generated />
using System;
using JourneyBot.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JourneyBot.Database.Migrations
{
    [DbContext(typeof(JourneyBotContext))]
    [Migration("20231225102742_NewTableForJourneyContext")]
    partial class NewTableForJourneyContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyActionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("InteractionId")
                        .HasColumnType("integer");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InteractionId");

                    b.HasIndex("SessionId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyBotMessageDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCommand")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BotMessages");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsStoped")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyInteractionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("StepId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyOptionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("InteractionId")
                        .HasColumnType("integer");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InteractionId");

                    b.HasIndex("SessionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionActionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("CompleteDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("InteractionId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("VoteDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("InteractionId");

                    b.ToTable("SessionActions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("CompleteDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPaused")
                        .HasColumnType("boolean");

                    b.Property<int>("JourneyId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("PauseDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("JourneyId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionInteractionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("InteractionId")
                        .HasColumnType("integer");

                    b.Property<int>("StepId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.ToTable("SessionStepInteractions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionOptionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("CompleteDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("InteractionId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("VoteDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("InteractionId");

                    b.ToTable("SessionOptions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionStepConditionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AwaitCount")
                        .HasColumnType("integer");

                    b.Property<int>("StepId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.ToTable("SessionStepConditions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionStepDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("CompleteDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ConditionId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("InteractionId")
                        .HasColumnType("integer");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.Property<int>("StepId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("InteractionId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionSteps");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionUsersMessageDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActionId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OptionId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("OptionId");

                    b.HasIndex("SessionId");

                    b.ToTable("UsersSessionMessages");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyStepConditionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("SecondsCount")
                        .HasColumnType("integer");

                    b.Property<int>("StepId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.ToTable("StepConditions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyStepDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConditionId")
                        .HasColumnType("integer");

                    b.Property<int>("InteractionId")
                        .HasColumnType("integer");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("InteractionId");

                    b.HasIndex("SessionId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyUserInteractionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActionId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OptionId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int>("UserMessageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("OptionId");

                    b.HasIndex("UserMessageId");

                    b.ToTable("UserInteractions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyUserMessageDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Option")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int?>("UsersMessageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsersMessageId");

                    b.ToTable("JourneyUserMessageDbModel");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyActionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyInteractionDbModel", "Interaction")
                        .WithMany("Actions")
                        .HasForeignKey("InteractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyDbModel", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interaction");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyInteractionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyStepDbModel", "Step")
                        .WithMany()
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Step");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyOptionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyInteractionDbModel", "Interaction")
                        .WithMany("Options")
                        .HasForeignKey("InteractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyDbModel", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interaction");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionActionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionInteractionDbModel", "Interaction")
                        .WithMany("Actions")
                        .HasForeignKey("InteractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interaction");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyDbModel", "Journey")
                        .WithMany()
                        .HasForeignKey("JourneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journey");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionInteractionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionStepDbModel", "Step")
                        .WithMany()
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Step");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionOptionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionInteractionDbModel", "Interaction")
                        .WithMany("Options")
                        .HasForeignKey("InteractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interaction");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionStepConditionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionStepDbModel", "Step")
                        .WithMany()
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Step");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionStepDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionStepConditionDbModel", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionInteractionDbModel", "Interaction")
                        .WithMany()
                        .HasForeignKey("InteractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionDbModel", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Interaction");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionUsersMessageDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionActionDbModel", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionOptionDbModel", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionDbModel", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Option");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyStepConditionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyStepDbModel", "Step")
                        .WithMany()
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Step");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyStepDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyStepConditionDbModel", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyInteractionDbModel", "Interaction")
                        .WithMany()
                        .HasForeignKey("InteractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyDbModel", "Session")
                        .WithMany("Steps")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Interaction");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyUserInteractionDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionActionDbModel", "Action")
                        .WithMany("UsersInteractions")
                        .HasForeignKey("ActionId");

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionOptionDbModel", "Option")
                        .WithMany("UsersInteractions")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneyUserMessageDbModel", "UserMessage")
                        .WithMany()
                        .HasForeignKey("UserMessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Option");

                    b.Navigation("UserMessage");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyUserMessageDbModel", b =>
                {
                    b.HasOne("JourneyBot.Datamodel.Database.Context.JourneySessionUsersMessageDbModel", "UsersMessage")
                        .WithMany("UserMessages")
                        .HasForeignKey("UsersMessageId");

                    b.Navigation("UsersMessage");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyDbModel", b =>
                {
                    b.Navigation("Steps");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneyInteractionDbModel", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionActionDbModel", b =>
                {
                    b.Navigation("UsersInteractions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionInteractionDbModel", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionOptionDbModel", b =>
                {
                    b.Navigation("UsersInteractions");
                });

            modelBuilder.Entity("JourneyBot.Datamodel.Database.Context.JourneySessionUsersMessageDbModel", b =>
                {
                    b.Navigation("UserMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
