using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignYourHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesignYourHome.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //private object modelBuilder;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Contractor> Contractor { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Style> Style { get; set; }


        public DbSet<Service> Service { get; set; }
        public DbSet<ContractorService> ContractorServices { get; set; }
        public DbSet<FixHome> FixHome { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                StreetAddress = "123 Infinity Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")

            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Room>().HasData(
               new Room()
               {
                   RoomId = 1,
                   UserId = user.Id,

                   Name = "Living Room",
                   Design = "Wooden Floor"
               },
               new Room()
               {
                   RoomId = 2,
                   UserId = user.Id,

                   Name = "Dinnign Room",
                   Design = "Decor"
               },

            new Room()
            {
                RoomId = 3,
                UserId = user.Id,

                Name = "BathRoom",
                Design = "Tiles"
            }
            );
            modelBuilder.Entity<Contractor>().HasData(
              new Contractor()
              {
                  ContractorId = 1,
                  UserId = user.Id,
                  Name = "John Doe",
                  City = "Franklin",
                  State = "Tenneessee",
                  PhoneNumber = "615-847-3636",
                  Website = "www.fixhome.com",
                  CompanyName = "Fixhome"
              },
              new Contractor()
              {
                  ContractorId = 2,
                  UserId = user.Id,

                  Name = "Will Healy",
                  City = "Spring Hill",
                  State = "Tenneessee",
                  PhoneNumber = "625-337-3326",
                  Website = "www.Pulte.com",
                  CompanyName = "Pulte"
              },
               new Contractor()
               {
                   ContractorId = 3,
                   UserId = user.Id,

                   Name = "Adam Sandler",
                   City = "Brentwood ",
                   State = "Tenneessee",
                   PhoneNumber = "625-567-3326",
                   Website = "www.Ryan.com",
                   CompanyName = "Ryan"
               },
                new Contractor()
                {
                    ContractorId = 4,
                    UserId = user.Id,

                    Name = "Sara Ray",
                    City = "Nashville ",
                    State = "Tenneessee",
                    PhoneNumber = "625-567-3426",
                    Website = "www.SaraRayInteriorDesign.com",
                    CompanyName = "SaraRayInteriorDesign"
                }
              );
            modelBuilder.Entity<Service>().HasData(
                new Service()
                {
                    ServiceId = 1,
                    Name = "Flooring",
                    ServiceCharge = 2500
                },
                 new Service()
                 {
                     ServiceId = 2,
                     Name = "Painter",
                     ServiceCharge = 1500
                 },
                  new Service()
                  {
                      ServiceId = 3,
                      Name = "Electrician",
                      ServiceCharge = 4500
                  },
                   new Service()
                   {
                       ServiceId = 4,
                       Name = "Plumber",
                       ServiceCharge = 4500
                   },
                   new Service()
                   {
                       ServiceId=5,
                       Name = "Interior Designer",
                       ServiceCharge = 7300
                   }
                 );
            modelBuilder.Entity<ContractorService>().HasData(
                new ContractorService()
                {
                    ContractorServiceId = 1,
                    ContractorId = 1,
                    ServiceId = 1
                },
                new ContractorService()
                {
                    ContractorServiceId = 2,
                    ContractorId = 2,
                    ServiceId = 2
                },
                 new ContractorService()
                 {
                     ContractorServiceId = 3,
                     ContractorId = 3,
                     ServiceId = 3
                 },
                  new ContractorService()
                  {
                      ContractorServiceId = 4,
                      ContractorId = 3,
                      ServiceId = 4
                  },
                  new ContractorService()
                  {
                      ContractorServiceId=5,
                      ContractorId = 4,
                      ServiceId = 5
                  }
                 );

            modelBuilder.Entity<FixHome>().HasData(
                new FixHome()
                {
                    FixHomeId = 1,
                    UserId = user.Id,

                    RoomId = 1,
                    ContractorId = 1
                },
                new FixHome()
                {
                    FixHomeId = 2,
                    UserId = user.Id,

                    RoomId = 2,
                    ContractorId = 4
                },
                 new FixHome()
                 {
                     FixHomeId = 3,
                     UserId = user.Id,

                     RoomId = 2,
                     ContractorId = 3
                 }

                 );
            modelBuilder.Entity<Style>().HasData(
               new Style()
               {
                   StyleId = 1,
                   Name = "Contemporary"
               },
                new Style()
                {
                    StyleId = 2,
                    Name = "Modern"
                },
                 new Style()
                 {
                     StyleId = 3,
                     Name = "Beach Style"
                 },
                  new Style()
                  {
                      StyleId = 4,
                      Name = "Rustic"
                  },
                  new Style()
                  {
                      StyleId = 5,
                      Name = "Farmhouse"
                  }
                  );
            modelBuilder.Entity<Image>().HasData(
                new Image()
                {
                    ImageId = 1,
                    Source = "https://www.iheartnaptime.net/wp-content/uploads/2013/05/wood-floor-designs-2.jpg",
                    RoomId = 1,
                    StyleId = 1

                },
                 new Image()
                 {
                     ImageId = 2,
                     Source = "https://i.pinimg.com/originals/6b/6c/8d/6b6c8d8a5c415fc8f72d16f439ce6eba.jpg",
                     RoomId = 2,
                     StyleId = 2
                 },
                 new Image()
                 {
                     ImageId = 3,
                     Source = "http://www.therunnerssoul.com/wp-content/uploads/2018/08/traditional-dining-room-decorating-photos-casual-dining-room-decorating-ideas-modern-dining-room-design-pictures.jpg",
                     RoomId = 3,
                     StyleId = 4

                 }
                 );

        }
    }
}

