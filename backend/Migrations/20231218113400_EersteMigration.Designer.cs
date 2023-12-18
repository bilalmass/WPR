﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20231218113400_EersteMigration")]
    partial class EersteMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Beschikbaarheid", b =>
                {
                    b.Property<int>("BeschikbaarheidId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Begin")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Eind")
                        .HasColumnType("TEXT");

                    b.HasKey("BeschikbaarheidId");

                    b.ToTable("Beschikbaarheden");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<string>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Models.Beperking", b =>
                {
                    b.Property<int>("BeperkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ErvaringsdeskundigeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BeperkingId");

                    b.HasIndex("ErvaringsdeskundigeId");

                    b.ToTable("Beperking");
                });

            modelBuilder.Entity("Models.Bericht", b =>
                {
                    b.Property<int>("BerichtId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BerichtId");

                    b.ToTable("Berichten");
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Models.ErvaringsdeskundigeOnderzoek", b =>
                {
                    b.Property<int>("ErvaringsdeskundigeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OnderzoekId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ErvaringsdeskundigeId", "OnderzoekId");

                    b.HasIndex("OnderzoekId");

                    b.ToTable("DeelnemersOnderzoek");
                });

            modelBuilder.Entity("Models.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GebruikerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gebruikers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Gebruiker");
                });

            modelBuilder.Entity("Models.Onderzoek", b =>
                {
                    b.Property<int>("OnderzoekId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Beloning")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Locatie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OnderzoekId");

                    b.ToTable("Onderzoeken");
                });

            modelBuilder.Entity("Models.Bedrijf", b =>
                {
                    b.HasBaseType("Models.Gebruiker");

                    b.Property<int>("BedrijfId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Bedrijf");
                });

            modelBuilder.Entity("Models.Ervaringsdeskundige", b =>
                {
                    b.HasBaseType("Models.Gebruiker");

                    b.Property<bool>("Data")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ErvaringsdeskundigeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("ErvaringsdeskundigeId");

                    b.HasDiscriminator().HasValue("Ervaringsdeskundige");
                });

            modelBuilder.Entity("Models.GebruikerRol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<string>");

                    b.Property<int>("GebruikerRolId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("GebruikerRolId");

                    b.HasDiscriminator().HasValue("GebruikerRol");
                });

            modelBuilder.Entity("Models.Rol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("Rol");
                });

            modelBuilder.Entity("Models.Verzorger", b =>
                {
                    b.HasBaseType("Models.Gebruiker");

                    b.Property<int>("VerzorgerId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Verzorger");
                });

            modelBuilder.Entity("Beschikbaarheid", b =>
                {
                    b.HasOne("Models.Ervaringsdeskundige", "Ervaringsdeskundige")
                        .WithMany("Beschikbaarheid")
                        .HasForeignKey("BeschikbaarheidId")
                        .OnDelete(DeleteBehavior.Cascade)
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.HasOne("Models.Gebruiker", "Verzender")
                        .WithMany("Chats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Verzender");
                });

            modelBuilder.Entity("Models.ErvaringsdeskundigeOnderzoek", b =>
                {
                    b.HasOne("Models.Ervaringsdeskundige", "Ervaringsdeskundige")
                        .WithMany("Deelnames")
                        .HasForeignKey("ErvaringsdeskundigeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Onderzoek", "Onderzoek")
                        .WithMany("Deelnemers")
                        .HasForeignKey("OnderzoekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ervaringsdeskundige");

                    b.Navigation("Onderzoek");
                });

            modelBuilder.Entity("Models.Onderzoek", b =>
                {
                    b.HasOne("Models.Bedrijf", "Bedrijf")
                        .WithMany("Onderzoeken")
                        .HasForeignKey("OnderzoekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bedrijf");
                });

            modelBuilder.Entity("Models.Ervaringsdeskundige", b =>
                {
                    b.HasOne("Models.Verzorger", "Verzorger")
                        .WithMany("Ervaringsdeskundige")
                        .HasForeignKey("ErvaringsdeskundigeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Verzorger");
                });

            modelBuilder.Entity("Models.GebruikerRol", b =>
                {
                    b.HasOne("Models.Gebruiker", "Gebruiker")
                        .WithMany("GebruikerRollen")
                        .HasForeignKey("GebruikerRolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Rol", "Rol")
                        .WithMany("GebruikerRollen")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gebruiker");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.Navigation("Berichten");
                });

            modelBuilder.Entity("Models.Gebruiker", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("GebruikerRollen");
                });

            modelBuilder.Entity("Models.Onderzoek", b =>
                {
                    b.Navigation("Deelnemers");
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

            modelBuilder.Entity("Models.Rol", b =>
                {
                    b.Navigation("GebruikerRollen");
                });

            modelBuilder.Entity("Models.Verzorger", b =>
                {
                    b.Navigation("Ervaringsdeskundige");
                });
#pragma warning restore 612, 618
        }
    }
}
