﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TauManager;

namespace TauManager.Migrations.TauDb
{
    [DbContext(typeof(TauDbContext))]
    [Migration("20210404220911_AddedPersonalRequests")]
    partial class AddedPersonalRequests
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TauManager.Models.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<byte?>("Difficulty")
                        .HasColumnType("smallint");

                    b.Property<bool>("ExcludeFromLeaderboards")
                        .HasColumnType("boolean");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Station")
                        .HasColumnType("text");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<int?>("SyndicateId")
                        .HasColumnType("integer");

                    b.Property<int?>("Tiers")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UTCDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("SyndicateId");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("TauManager.Models.CampaignAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("PlayerId");

                    b.ToTable("CampaignAttendance");
                });

            modelBuilder.Entity("TauManager.Models.CampaignLoot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool?>("AvailableToOtherSyndicates")
                        .HasColumnType("boolean");

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<int?>("HolderId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("HolderId");

                    b.HasIndex("ItemId");

                    b.ToTable("CampaignLoot");
                });

            modelBuilder.Entity("TauManager.Models.CampaignSignup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool?>("Attending")
                        .HasColumnType("boolean");

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("PlayerId");

                    b.ToTable("CampaignSignup");
                });

            modelBuilder.Entity("TauManager.Models.DiscordOfficer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("LoginName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DiscordOfficer");
                });

            modelBuilder.Entity("TauManager.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<decimal?>("Accuracy")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal?>("Energy")
                        .HasColumnType("numeric");

                    b.Property<bool?>("HandToHand")
                        .HasColumnType("boolean");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<decimal?>("Impact")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Piercing")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<byte>("Rarity")
                        .HasColumnType("smallint");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<int>("Tier")
                        .HasColumnType("integer");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.Property<byte?>("WeaponRange")
                        .HasColumnType("smallint");

                    b.Property<byte?>("WeaponType")
                        .HasColumnType("smallint");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("TauManager.Models.LootRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("IsCollectorRequest")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPersonalRequest")
                        .HasColumnType("boolean");

                    b.Property<int>("LootId")
                        .HasColumnType("integer");

                    b.Property<int>("RequestedById")
                        .HasColumnType("integer");

                    b.Property<int>("RequestedForId")
                        .HasColumnType("integer");

                    b.Property<string>("SpecialOfferDescription")
                        .HasColumnType("text");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("LootId");

                    b.HasIndex("RequestedById");

                    b.HasIndex("RequestedForId");

                    b.ToTable("LootRequest");
                });

            modelBuilder.Entity("TauManager.Models.MarketAd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte>("OfferType")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("PlacementDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte>("RequestType")
                        .HasColumnType("smallint");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("MarketAd");
                });

            modelBuilder.Entity("TauManager.Models.MarketAdBundle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("AdId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Credits")
                        .HasColumnType("numeric");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("MarketAdBundle");
                });

            modelBuilder.Entity("TauManager.Models.MarketAdBundleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("BundleId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BundleId");

                    b.HasIndex("ItemId");

                    b.ToTable("MarketAdBundleItem");
                });

            modelBuilder.Entity("TauManager.Models.MarketAdReaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("AdId")
                        .HasColumnType("integer");

                    b.Property<int>("InterestedId")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<DateTime>("ReactionDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("InterestedId");

                    b.ToTable("MarketAdReaction");
                });

            modelBuilder.Entity("TauManager.Models.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Audit")
                        .HasColumnType("text");

                    b.Property<byte>("Kind")
                        .HasColumnType("smallint");

                    b.Property<string>("MessagePayloadJson")
                        .HasColumnType("text");

                    b.Property<int>("RecipientId")
                        .HasColumnType("integer");

                    b.Property<long?>("RelatedId")
                        .HasColumnType("bigint");

                    b.Property<byte>("RetryCount")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("SendAfter")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("TauManager.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Agility")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Bank")
                        .HasColumnType("numeric");

                    b.Property<int>("Bonds")
                        .HasColumnType("integer");

                    b.Property<string>("DiscordAuthCode")
                        .HasColumnType("text");

                    b.Property<bool>("DiscordAuthConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("DiscordLogin")
                        .HasColumnType("text");

                    b.Property<DateTime?>("GauleVisaExpiry")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Intelligence")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Level")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NotificationSettings")
                        .HasColumnType("integer");

                    b.Property<decimal>("Social")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Stamina")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Strength")
                        .HasColumnType("numeric");

                    b.Property<int?>("SyndicateId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UniCourseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Wallet")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("SyndicateId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("TauManager.Models.PlayerHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<decimal>("Agility")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Bank")
                        .HasColumnType("numeric");

                    b.Property<int>("Bonds")
                        .HasColumnType("integer");

                    b.Property<decimal>("Intelligence")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Level")
                        .HasColumnType("numeric");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RecordedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Social")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Stamina")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Strength")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Wallet")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerHistory");
                });

            modelBuilder.Entity("TauManager.Models.PlayerListPositionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("LootRequestId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LootRequestId")
                        .IsUnique();

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerListPositionHistory");
                });

            modelBuilder.Entity("TauManager.Models.PlayerSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SkillId");

                    b.ToTable("PlayerSkill");
                });

            modelBuilder.Entity("TauManager.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("TauManager.Models.SkillGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SkillId")
                        .IsUnique();

                    b.ToTable("SkillGroup");
                });

            modelBuilder.Entity("TauManager.Models.Syndicate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Tag")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Syndicate");
                });

            modelBuilder.Entity("TauManager.Models.SyndicateHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("Bonds")
                        .HasColumnType("integer");

                    b.Property<decimal>("Credits")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Level")
                        .HasColumnType("numeric");

                    b.Property<int>("MembersCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RecordedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SyndicateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SyndicateId");

                    b.ToTable("SyndicateHistory");
                });

            modelBuilder.Entity("TauManager.Models.Campaign", b =>
                {
                    b.HasOne("TauManager.Models.Player", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("TauManager.Models.Syndicate", "Syndicate")
                        .WithMany()
                        .HasForeignKey("SyndicateId");
                });

            modelBuilder.Entity("TauManager.Models.CampaignAttendance", b =>
                {
                    b.HasOne("TauManager.Models.Campaign", "Campaign")
                        .WithMany("Attendance")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TauManager.Models.Player", "Player")
                        .WithMany("Attendance")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.CampaignLoot", b =>
                {
                    b.HasOne("TauManager.Models.Campaign", "Campaign")
                        .WithMany("Loot")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TauManager.Models.Player", "Holder")
                        .WithMany("HeldCampaignLoot")
                        .HasForeignKey("HolderId");

                    b.HasOne("TauManager.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.CampaignSignup", b =>
                {
                    b.HasOne("TauManager.Models.Campaign", "Campaign")
                        .WithMany("Signups")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TauManager.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.LootRequest", b =>
                {
                    b.HasOne("TauManager.Models.CampaignLoot", "Loot")
                        .WithMany("Requests")
                        .HasForeignKey("LootId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TauManager.Models.Player", "RequestedBy")
                        .WithMany()
                        .HasForeignKey("RequestedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TauManager.Models.Player", "RequestedFor")
                        .WithMany("LootRequests")
                        .HasForeignKey("RequestedForId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.MarketAd", b =>
                {
                    b.HasOne("TauManager.Models.Player", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.MarketAdBundle", b =>
                {
                    b.HasOne("TauManager.Models.MarketAd", "Ad")
                        .WithMany("Bundles")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.MarketAdBundleItem", b =>
                {
                    b.HasOne("TauManager.Models.MarketAdBundle", "Bundle")
                        .WithMany("Items")
                        .HasForeignKey("BundleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TauManager.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.MarketAdReaction", b =>
                {
                    b.HasOne("TauManager.Models.MarketAd", "Ad")
                        .WithMany("Reactions")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TauManager.Models.Player", "Interested")
                        .WithMany()
                        .HasForeignKey("InterestedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.Notification", b =>
                {
                    b.HasOne("TauManager.Models.Player", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.Player", b =>
                {
                    b.HasOne("TauManager.Models.Syndicate", "Syndicate")
                        .WithMany()
                        .HasForeignKey("SyndicateId");
                });

            modelBuilder.Entity("TauManager.Models.PlayerHistory", b =>
                {
                    b.HasOne("TauManager.Models.Player", "Player")
                        .WithMany("History")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.PlayerListPositionHistory", b =>
                {
                    b.HasOne("TauManager.Models.LootRequest", "LootRequest")
                        .WithOne("HistoryEntry")
                        .HasForeignKey("TauManager.Models.PlayerListPositionHistory", "LootRequestId");

                    b.HasOne("TauManager.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.PlayerSkill", b =>
                {
                    b.HasOne("TauManager.Models.Player", "Player")
                        .WithMany("PlayerSkills")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TauManager.Models.Skill", "Skill")
                        .WithMany("PlayerRelations")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.SkillGroup", b =>
                {
                    b.HasOne("TauManager.Models.Skill", "Skill")
                        .WithOne("Groups")
                        .HasForeignKey("TauManager.Models.SkillGroup", "SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TauManager.Models.SyndicateHistory", b =>
                {
                    b.HasOne("TauManager.Models.Syndicate", "Syndicate")
                        .WithMany("History")
                        .HasForeignKey("SyndicateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
