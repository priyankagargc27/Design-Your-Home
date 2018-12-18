﻿// <auto-generated />
using System;
using DesignYourHome.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesignYourHome.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181218034315_start")]
    partial class start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesignYourHome.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3", AccessFailedCount = 0, ConcurrencyStamp = "dbad5dfb-956e-4bff-b1f9-a994cf56a4a8", Email = "admin@admin.com", EmailConfirmed = true, FirstName = "admin", LastName = "admin", LockoutEnabled = false, NormalizedEmail = "ADMIN@ADMIN.COM", NormalizedUserName = "ADMIN@ADMIN.COM", PasswordHash = "AQAAAAEAACcQAAAAEBuEyJgpAcxFZL7BR3wWdfAedAKstdOnBHS4G2C2DxYOKSaRjswbutzWvcclE+fVlA==", PhoneNumberConfirmed = false, SecurityStamp = "6c98d0dd-b5d5-4b3d-8d26-aa667a8c0b33", StreetAddress = "123 Infinity Way", TwoFactorEnabled = false, UserName = "admin@admin.com" }
                    );
                });

            modelBuilder.Entity("DesignYourHome.Models.Contractor", b =>
                {
                    b.Property<int>("ContractorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("CompanyName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<string>("Website");

                    b.HasKey("ContractorId");

                    b.HasIndex("UserId");

                    b.ToTable("Contractor");

                    b.HasData(
                        new { ContractorId = 1, City = "Franklin", CompanyName = "Fixhome", Name = "John Doe", PhoneNumber = "615-847-3636", State = "Tenneessee", UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3", Website = "www.fixhome.com" },
                        new { ContractorId = 2, City = "Spring Hill", CompanyName = "Pulte", Name = "Will Healy", PhoneNumber = "625-337-3326", State = "Tenneessee", UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3", Website = "www.Pulte.com" },
                        new { ContractorId = 3, City = "Brentwood ", CompanyName = "Ryan", Name = "Adam Sandler", PhoneNumber = "625-567-3326", State = "Tenneessee", UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3", Website = "www.Ryan.com" },
                        new { ContractorId = 4, City = "Nashville ", CompanyName = "SaraRayInteriorDesign", Name = "Sara Ray", PhoneNumber = "625-567-3426", State = "Tenneessee", UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3", Website = "www.SaraRayInteriorDesign.com" }
                    );
                });

            modelBuilder.Entity("DesignYourHome.Models.ContractorService", b =>
                {
                    b.Property<int>("ContractorServiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractorId");

                    b.Property<int>("ServiceId");

                    b.HasKey("ContractorServiceId");

                    b.HasIndex("ContractorId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ContractorServices");

                    b.HasData(
                        new { ContractorServiceId = 1, ContractorId = 1, ServiceId = 1 },
                        new { ContractorServiceId = 2, ContractorId = 2, ServiceId = 2 },
                        new { ContractorServiceId = 3, ContractorId = 3, ServiceId = 3 },
                        new { ContractorServiceId = 4, ContractorId = 3, ServiceId = 4 }
                    );
                });

            modelBuilder.Entity("DesignYourHome.Models.FixHome", b =>
                {
                    b.Property<int>("FixHomeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractorId");

                    b.Property<string>("Description");

                    b.Property<int>("RoomId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("FixHomeId");

                    b.HasIndex("ContractorId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("FixHome");

                    b.HasData(
                        new { FixHomeId = 1, ContractorId = 1, RoomId = 1, UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3" },
                        new { FixHomeId = 2, ContractorId = 4, RoomId = 2, UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3" },
                        new { FixHomeId = 3, ContractorId = 3, RoomId = 2, UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3" }
                    );
                });

            modelBuilder.Entity("DesignYourHome.Models.Ideaboard", b =>
                {
                    b.Property<int>("IdeaboardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("IdeaboardId");

                    b.HasIndex("UserId");

                    b.ToTable("Ideaboard");

                    b.HasData(
                        new { IdeaboardId = 1, Title = "Test", UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3" }
                    );
                });

            modelBuilder.Entity("DesignYourHome.Models.IdeaImage", b =>
                {
                    b.Property<int>("IdeaImageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdeaboardId");

                    b.Property<int>("ImageId");

                    b.HasKey("IdeaImageId");

                    b.HasIndex("IdeaboardId");

                    b.HasIndex("ImageId");

                    b.ToTable("IdeaImage");
                });

            modelBuilder.Entity("DesignYourHome.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomId");

                    b.Property<string>("Source")
                        .IsRequired();

                    b.Property<int>("StyleId");

                    b.HasKey("ImageId");

                    b.HasIndex("RoomId");

                    b.HasIndex("StyleId");

                    b.ToTable("Image");

                    b.HasData(
                        new { ImageId = 1, RoomId = 1, Source = "https://www.iheartnaptime.net/wp-content/uploads/2013/05/wood-floor-designs-2.jpg", StyleId = 1 },
                        new { ImageId = 2, RoomId = 2, Source = "https://i.pinimg.com/originals/6b/6c/8d/6b6c8d8a5c415fc8f72d16f439ce6eba.jpg", StyleId = 2 },
                        new { ImageId = 3, RoomId = 3, Source = "http://www.therunnerssoul.com/wp-content/uploads/2018/08/traditional-dining-room-decorating-photos-casual-dining-room-decorating-ideas-modern-dining-room-design-pictures.jpg", StyleId = 4 }
                    );
                });

            modelBuilder.Entity("DesignYourHome.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Design")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Room");

                    b.HasData(
                        new { RoomId = 1, Design = "Wooden Floor", Name = "Living Room", UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3" },
                        new { RoomId = 2, Design = "Decor", Name = "Dinnign Room", UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3" },
                        new { RoomId = 3, Design = "Tiles", Name = "BathRoom", UserId = "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3" }
                    );
                });

            modelBuilder.Entity("DesignYourHome.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ServiceCharge");

                    b.HasKey("ServiceId");

                    b.ToTable("Service");

                    b.HasData(
                        new { ServiceId = 1, Name = "Flooring", ServiceCharge = 2500 },
                        new { ServiceId = 2, Name = "Painter", ServiceCharge = 1500 },
                        new { ServiceId = 3, Name = "Electrician", ServiceCharge = 4500 },
                        new { ServiceId = 4, Name = "Plumber", ServiceCharge = 4500 },
                        new { ServiceId = 5, Name = "Interior Designer", ServiceCharge = 7300 }
                    );
                });

            modelBuilder.Entity("DesignYourHome.Models.Style", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("isSelected");

                    b.HasKey("StyleId");

                    b.ToTable("Style");

                    b.HasData(
                        new { StyleId = 1, Name = "Contemporary", isSelected = false },
                        new { StyleId = 2, Name = "Modern", isSelected = false },
                        new { StyleId = 3, Name = "Beach Style", isSelected = false },
                        new { StyleId = 4, Name = "Rustic", isSelected = false },
                        new { StyleId = 5, Name = "Farmhouse", isSelected = false }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DesignYourHome.Models.Contractor", b =>
                {
                    b.HasOne("DesignYourHome.Models.ApplicationUser", "User")
                        .WithMany("Contractors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesignYourHome.Models.ContractorService", b =>
                {
                    b.HasOne("DesignYourHome.Models.Contractor", "Contractor")
                        .WithMany("Services")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DesignYourHome.Models.Service", "Service")
                        .WithMany("Contractors")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesignYourHome.Models.FixHome", b =>
                {
                    b.HasOne("DesignYourHome.Models.Contractor", "Contractor")
                        .WithMany()
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DesignYourHome.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DesignYourHome.Models.ApplicationUser", "User")
                        .WithMany("FixHome")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesignYourHome.Models.Ideaboard", b =>
                {
                    b.HasOne("DesignYourHome.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesignYourHome.Models.IdeaImage", b =>
                {
                    b.HasOne("DesignYourHome.Models.Ideaboard", "Ideaboard")
                        .WithMany("Images")
                        .HasForeignKey("IdeaboardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DesignYourHome.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesignYourHome.Models.Image", b =>
                {
                    b.HasOne("DesignYourHome.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DesignYourHome.Models.Style", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesignYourHome.Models.Room", b =>
                {
                    b.HasOne("DesignYourHome.Models.ApplicationUser", "User")
                        .WithMany("Rooms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DesignYourHome.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DesignYourHome.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DesignYourHome.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DesignYourHome.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
