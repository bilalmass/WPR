﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(DbContext))]
    partial class DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ErvaringsdeskundigeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BeschikbaarheidId");

                    b.HasIndex("ErvaringsdeskundigeId");

                    b.ToTable("Beschikbaarheden");
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

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.Property<string>("ChatId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BerichtId");

                    b.HasIndex("ChatId");

                    b.ToTable("Berichten");
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.Property<string>("ChatId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VerzenderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChatId");

                    b.HasIndex("VerzenderId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Models.ErvaringsdeskundigeOnderzoek", b =>
                {
                    b.Property<int>("ErvaringsdeskundigeOnderzoekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ErvaringsdeskundigeOnderzoekId"), 1L, 1);

                    b.Property<string>("ErvaringsdeskundigeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OnderzoekId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ErvaringsdeskundigeOnderzoekId");

                    b.HasIndex("ErvaringsdeskundigeId");

                    b.HasIndex("OnderzoekId");

                    b.ToTable("DeelnemersOnderzoek");
                });

            modelBuilder.Entity("Models.Gebruiker", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("test");

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

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("UserType").HasValue("Gebruiker");
                });

            modelBuilder.Entity("Models.Onderzoek", b =>
                {
                    b.Property<string>("OnderzoekId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BedrijfId")
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

                    b.HasIndex("BedrijfId");

                    b.ToTable("Onderzoeken");
                });

            modelBuilder.Entity("Models.Rol", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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
                });

            modelBuilder.Entity("Models.Bedrijf", b =>
                {
                    b.HasBaseType("Models.Gebruiker");

                    b.Property<string>("Naam")
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

                    b.Property<string>("Geboortedatum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Geslacht")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefoonnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerzorgerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Voornaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("VerzorgerId");

                    b.HasDiscriminator().HasValue("Ervaringsdeskundige");
                });

            modelBuilder.Entity("Models.Verzorger", b =>
                {
                    b.HasBaseType("Models.Gebruiker");

                    b.HasDiscriminator().HasValue("Verzorger");
                });

            modelBuilder.Entity("Beschikbaarheid", b =>
                {
                    b.HasOne("Models.Ervaringsdeskundige", "Ervaringsdeskundige")
                        .WithMany("Beschikbaarheid")
                        .HasForeignKey("ErvaringsdeskundigeId");

                    b.Navigation("Ervaringsdeskundige");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Models.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Models.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Gebruiker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Models.Gebruiker", null)
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
                        .HasForeignKey("ChatId");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.HasOne("Models.Gebruiker", "Verzender")
                        .WithMany("Chats")
                        .HasForeignKey("VerzenderId");

                    b.Navigation("Verzender");
                });

            modelBuilder.Entity("Models.ErvaringsdeskundigeOnderzoek", b =>
                {
                    b.HasOne("Models.Ervaringsdeskundige", "Ervaringsdeskundige")
                        .WithMany("Deelnames")
                        .HasForeignKey("ErvaringsdeskundigeId");

                    b.HasOne("Models.Onderzoek", "Onderzoek")
                        .WithMany("Deelnemers")
                        .HasForeignKey("OnderzoekId");

                    b.Navigation("Ervaringsdeskundige");

                    b.Navigation("Onderzoek");
                });

            modelBuilder.Entity("Models.Onderzoek", b =>
                {
                    b.HasOne("Models.Bedrijf", "Bedrijf")
                        .WithMany("Onderzoeken")
                        .HasForeignKey("BedrijfId");

                    b.Navigation("Bedrijf");
                });


            modelBuilder.Entity("Models.Ervaringsdeskundige", b =>
                {
                    b.HasOne("Models.Verzorger", "Verzorger")
                        .WithMany("Ervaringsdeskundige")
                        .HasForeignKey("VerzorgerId");

                    b.Navigation("Verzorger");
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.Navigation("Berichten");
                });

            modelBuilder.Entity("Models.Gebruiker", b =>
                {
                    b.Navigation("Chats");
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

            modelBuilder.Entity("Models.Verzorger", b =>
                {
                    b.Navigation("Ervaringsdeskundige");
                });
#pragma warning restore 612, 618
        }
    }
}
