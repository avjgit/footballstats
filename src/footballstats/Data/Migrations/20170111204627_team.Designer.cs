using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using footballstats.Data;

namespace footballstats.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170111204627_team")]
    partial class team
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("footballstats.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("footballstats.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("MainRefereeId");

                    b.Property<string>("Place");

                    b.Property<int>("Spectators");

                    b.HasKey("Id");

                    b.HasIndex("MainRefereeId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("footballstats.Models.MainCast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("MainCast");
                });

            modelBuilder.Entity("footballstats.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<int>("Number");

                    b.Property<int?>("PlayersListId");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.HasIndex("PlayersListId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("footballstats.Models.PlayersList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("PlayersList");
                });

            modelBuilder.Entity("footballstats.Models.PlayersNr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MainCastId");

                    b.Property<int>("Nr");

                    b.HasKey("Id");

                    b.HasIndex("MainCastId");

                    b.ToTable("PlayersNr");
                });

            modelBuilder.Entity("footballstats.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SpeleId");

                    b.HasKey("Id");

                    b.HasIndex("SpeleId");

                    b.ToTable("Record");
                });

            modelBuilder.Entity("footballstats.Models.Referee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Firstname");

                    b.Property<int?>("GameId");

                    b.Property<string>("Lastname");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Referee");
                });

            modelBuilder.Entity("footballstats.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameId");

                    b.Property<int?>("MainCastId");

                    b.Property<int?>("PlayersListId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("MainCastId");

                    b.HasIndex("PlayersListId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("footballstats.Models.Game", b =>
                {
                    b.HasOne("footballstats.Models.Referee", "MainReferee")
                        .WithMany()
                        .HasForeignKey("MainRefereeId");
                });

            modelBuilder.Entity("footballstats.Models.Player", b =>
                {
                    b.HasOne("footballstats.Models.PlayersList")
                        .WithMany("Players")
                        .HasForeignKey("PlayersListId");
                });

            modelBuilder.Entity("footballstats.Models.PlayersNr", b =>
                {
                    b.HasOne("footballstats.Models.MainCast")
                        .WithMany("PlayersNrs")
                        .HasForeignKey("MainCastId");
                });

            modelBuilder.Entity("footballstats.Models.Record", b =>
                {
                    b.HasOne("footballstats.Models.Game", "Spele")
                        .WithMany()
                        .HasForeignKey("SpeleId");
                });

            modelBuilder.Entity("footballstats.Models.Referee", b =>
                {
                    b.HasOne("footballstats.Models.Game")
                        .WithMany("LineReferees")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("footballstats.Models.Team", b =>
                {
                    b.HasOne("footballstats.Models.Game")
                        .WithMany("Teams")
                        .HasForeignKey("GameId");

                    b.HasOne("footballstats.Models.MainCast", "MainCast")
                        .WithMany()
                        .HasForeignKey("MainCastId");

                    b.HasOne("footballstats.Models.PlayersList", "PlayersList")
                        .WithMany()
                        .HasForeignKey("PlayersListId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("footballstats.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("footballstats.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("footballstats.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
