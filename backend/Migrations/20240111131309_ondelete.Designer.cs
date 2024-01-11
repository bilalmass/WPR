﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20240111131309_ondelete")]
    partial class ondelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Beschikbaarheid", b =>
                {
                    b.Property<string>("BeschikbaarheidId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Begin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Eind")
                        .HasColumnType("datetime2");

                    b.HasKey("BeschikbaarheidId");

                    b.ToTable("Beschikbaarheden");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<string>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Models.Beperking", b =>
                {
                    b.Property<string>("BeperkingId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ErvaringsdeskundigeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BeperkingId");

                    b.HasIndex("ErvaringsdeskundigeId");

                    b.ToTable("Beperking");
                });

            modelBuilder.Entity("Models.Bericht", b =>
                {
                    b.Property<string>("BerichtId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BerichtId");

                    b.ToTable("Berichten");
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.Property<string>("ChatId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Models.ErvaringsdeskundigeOnderzoek", b =>
                {
                    b.Property<string>("ErvaringsdeskundigeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OnderzoekId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ErvaringsdeskundigeId", "OnderzoekId");

                    b.HasIndex("OnderzoekId");

                    b.ToTable("DeelnemersOnderzoek");
                });

            modelBuilder.Entity("Models.Onderzoek", b =>
                {
                    b.Property<string>("OnderzoekId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Beloning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categorie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locatie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OnderzoekId");

                    b.ToTable("Onderzoeken");
                });

            modelBuilder.Entity("Models.Gebruiker", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("GebruikerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Gebruiker");
                });

            modelBuilder.Entity("Models.GebruikerRol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<string>");

                    b.Property<string>("GebruikerRolId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("GebruikerRolId");

                    b.HasDiscriminator().HasValue("GebruikerRol");
                });

            modelBuilder.Entity("Models.Rol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("Rol");
                });

            modelBuilder.Entity("Models.Bedrijf", b =>
                {
                    b.HasBaseType("Models.Gebruiker");

                    b.Property<string>("BedrijfId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Bedrijf");
                });

            modelBuilder.Entity("Models.Ervaringsdeskundige", b =>
                {
                    b.HasBaseType("Models.Gebruiker");

                    b.Property<string>("Achternaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Data")
                        .HasColumnType("bit");

                    b.Property<string>("ErvaringsdeskundigeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Geboortedatum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Geslacht")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefoonnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ErvaringsdeskundigeId");

                    b.HasDiscriminator().HasValue("Ervaringsdeskundige");
                });

            modelBuilder.Entity("Models.Verzorger", b =>
                {
                    b.HasBaseType("Models.Gebruiker");

                    b.Property<string>("VerzorgerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Verzorger");
                });

            modelBuilder.Entity("Beschikbaarheid", b =>
                {
                    b.HasOne("Models.Ervaringsdeskundige", "Ervaringsdeskundige")
                        .WithMany("Beschikbaarheid")
                        .HasForeignKey("BeschikbaarheidId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ervaringsdeskundige");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Beperking", b =>
                {
                    b.HasOne("Models.Ervaringsdeskundige", null)
                        .WithMany("Beperkingen")
                        .HasForeignKey("ErvaringsdeskundigeId");
                });

            modelBuilder.Entity("Models.Bericht", b =>
                {
                    b.HasOne("Models.Chat", "Chat")
                        .WithMany("Berichten")
                        .HasForeignKey("BerichtId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.HasOne("Models.Gebruiker", "Verzender")
                        .WithMany("Chats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Verzender");
                });

            modelBuilder.Entity("Models.ErvaringsdeskundigeOnderzoek", b =>
                {
                    b.HasOne("Models.Ervaringsdeskundige", "Ervaringsdeskundige")
                        .WithMany("Deelnames")
                        .HasForeignKey("ErvaringsdeskundigeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Onderzoek", "Onderzoek")
                        .WithMany("Deelnemers")
                        .HasForeignKey("OnderzoekId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ervaringsdeskundige");

                    b.Navigation("Onderzoek");
                });

            modelBuilder.Entity("Models.Onderzoek", b =>
                {
                    b.HasOne("Models.Bedrijf", "Bedrijf")
                        .WithMany("Onderzoeken")
                        .HasForeignKey("OnderzoekId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bedrijf");
                });

            modelBuilder.Entity("Models.GebruikerRol", b =>
                {
                    b.HasOne("Models.Gebruiker", "Gebruiker")
                        .WithMany("GebruikerRollen")
                        .HasForeignKey("GebruikerRolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Rol", "Rol")
                        .WithMany("GebruikerRollen")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId1");

                    b.Navigation("Gebruiker");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Models.Ervaringsdeskundige", b =>
                {
                    b.HasOne("Models.Verzorger", "Verzorger")
                        .WithMany("Ervaringsdeskundige")
                        .HasForeignKey("ErvaringsdeskundigeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Verzorger");
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.Navigation("Berichten");
                });

            modelBuilder.Entity("Models.Onderzoek", b =>
                {
                    b.Navigation("Deelnemers");
                });

            modelBuilder.Entity("Models.Gebruiker", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("GebruikerRollen");
                });

            modelBuilder.Entity("Models.Rol", b =>
                {
                    b.Navigation("GebruikerRollen");
                });

            modelBuilder.Entity("Models.Bedrijf", b =>
                {
                    b.Navigation("Onderzoeken");
                });

            modelBuilder.Entity("Models.Ervaringsdeskundige", b =>
                {
                    b.Navigation("Beperkingen");

                    b.Navigation("Beschikbaarheid");

                    b.Navigation("Deelnames");
                });

            modelBuilder.Entity("Models.Verzorger", b =>
                {
                    b.Navigation("Ervaringsdeskundige");
                });
#pragma warning restore 612, 618
        }
    }
}
