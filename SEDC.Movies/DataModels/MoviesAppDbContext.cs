using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataModels
{
    public class MoviesAppDbContext : DbContext
    {
        public MoviesAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserDto> Users { get; set; }
        public DbSet<MovieDto> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDto>()
                .HasOne(x => x.User)
                .WithMany(x => x.MoviesList)
                .HasForeignKey(x => x.UserId);

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            modelBuilder.Entity<UserDto>()
                .HasData(
                new UserDto()
                {
                    Id = 1,
                    FirstName = "Andrea",
                    LastName = "Markovski",
                    Username = "andrea123",
                    Password = hashedPassword
                });

            modelBuilder.Entity<MovieDto>()
                .HasData(
                new MovieDto()
                {
                    Id = 1,
                    Title = "FirstMovie",
                    Description = "FirstDesc",
                    Year = 1990,
                    Genre = (int)Genre.action,
                    UserId = 1
                },
                new MovieDto()
                {
                    Id = 2,
                    Title = "SecondMovie",
                    Description = "SecondDesc",
                    Year = 1995,
                    Genre = (int)Genre.comedy,
                    UserId = 1
                },
                new MovieDto()
                {
                    Id = 3,
                    Title = "ThirdMovie",
                    Description = "ThirdDesc",
                    Year = 2000,
                    Genre = (int)Genre.horror,
                    UserId = 1
                }
                );
        }
    }
}
