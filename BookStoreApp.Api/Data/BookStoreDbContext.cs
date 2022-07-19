using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookStoreApp.Api.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=BookStoreDb;Trusted_Connection=True;MultipleActiveResultSets=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA03F13AE5")
                    .IsUnique();

                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            // Identity roles
            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Name = "User",
                        NormalizedName = "USER",
                        Id = "44b0c237-c427-48f4-93b6-5144cabd9a1f"
                    },
                    new IdentityRole
                    {
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                        Id = "46c9b085-f259-479d-8fe6-f754eae48d74"
                    }
                );

            // for ApiUser (two users with 2 roles in this case)
            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
                    new ApiUser
                    {
                        Id = "30e613d1-072e-4d99-9927-ef001984de46",
                        Email = "admi@bookstore.com",
                        NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                        UserName = "admin@bookstore.com",
                        NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                        FirstName = "System",
                        LastName = "Admin",
                        PasswordHash = hasher.HashPassword(null, "p@ssword1")
                    },
                    new ApiUser
                    {
                        Id = "366df5be-b4f8-4018-9f32-2ec5df2031b2",
                        Email = "user@bookstore.com",
                        NormalizedEmail = "USER@BOOKSTORE.COM",
                        UserName = "user@bookstore.com",
                        NormalizedUserName = "USER@BOOKSTORE.COM",
                        FirstName = "System",
                        LastName = "User",
                        PasswordHash = hasher.HashPassword(null, "p@ssword1")
                    }
                );
            // for IdentityUserRole<string>
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "44b0c237-c427-48f4-93b6-5144cabd9a1f",
                        UserId = "366df5be-b4f8-4018-9f32-2ec5df2031b2"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "46c9b085-f259-479d-8fe6-f754eae48d74",
                        UserId = "30e613d1-072e-4d99-9927-ef001984de46"
                    }
                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
