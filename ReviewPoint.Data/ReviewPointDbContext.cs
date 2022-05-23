using System;
using ReviewPoint.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ReviewPoint.Data
{
    public class ReviewPointDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ReviewPointDbContext(DbContextOptions<ReviewPointDbContext> options)
            : base(options) { }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public override DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User);

            modelBuilder
                .Entity<Book>()
                .HasMany(b => b.Reviews);

            modelBuilder
                .Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);

            modelBuilder
                .Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            { 
                Name = "User", 
                NormalizedName = "User".ToUpper()
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "Administrator".ToUpper()
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
