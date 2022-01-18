﻿// <auto-generated />
using System;
using HTB_Updates_Discord_Bot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HTB_Updates_Discord_Bot.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210420184715_ChallCat")]
    partial class ChallCat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("HTB_Updates_Discord_Bot.Models.Database.DiscordGuild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("ChannelId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("HTBUpdates_DiscordGuilds");
                });

            modelBuilder.Entity("HTB_Updates_Discord_Bot.Models.Database.DiscordUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("DiscordId")
                        .HasColumnType("bigint unsigned");

                    b.Property<int?>("GuildId")
                        .HasColumnType("int");

                    b.Property<int?>("HTBUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("HTBUserId");

                    b.ToTable("HTBUpdates_DiscordUsers");
                });

            modelBuilder.Entity("HTB_Updates_Discord_Bot.Models.Database.HTBUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("HtbId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("HTBUpdates_HTBUsers");
                });

            modelBuilder.Entity("HTB_Updates_Discord_Bot.Models.Shared.Solve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ChallengeCategory")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DateDiff")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("FirstBlood")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("HTBUserId")
                        .HasColumnType("int");

                    b.Property<string>("MachineAvatar")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ObjectType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("SolveId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("HTBUserId");

                    b.ToTable("HTBUpdates_Solves");
                });

            modelBuilder.Entity("HTB_Updates_Discord_Bot.Models.Database.DiscordUser", b =>
                {
                    b.HasOne("HTB_Updates_Discord_Bot.Models.Database.DiscordGuild", "Guild")
                        .WithMany("DiscordUsers")
                        .HasForeignKey("GuildId");

                    b.HasOne("HTB_Updates_Discord_Bot.Models.Database.HTBUser", "HTBUser")
                        .WithMany("DiscordUsers")
                        .HasForeignKey("HTBUserId");

                    b.Navigation("Guild");

                    b.Navigation("HTBUser");
                });

            modelBuilder.Entity("HTB_Updates_Discord_Bot.Models.Shared.Solve", b =>
                {
                    b.HasOne("HTB_Updates_Discord_Bot.Models.Database.HTBUser", null)
                        .WithMany("Solves")
                        .HasForeignKey("HTBUserId");
                });

            modelBuilder.Entity("HTB_Updates_Discord_Bot.Models.Database.DiscordGuild", b =>
                {
                    b.Navigation("DiscordUsers");
                });

            modelBuilder.Entity("HTB_Updates_Discord_Bot.Models.Database.HTBUser", b =>
                {
                    b.Navigation("DiscordUsers");

                    b.Navigation("Solves");
                });
#pragma warning restore 612, 618
        }
    }
}
