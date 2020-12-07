using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiWithWebToken.Domain
{
    public partial class ApiWithWebTokenDatabaseContext : DbContext
    {
        public ApiWithWebTokenDatabaseContext()
        {
        }

        public ApiWithWebTokenDatabaseContext(DbContextOptions<ApiWithWebTokenDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }


        //Startup üzerine aktardık.

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=DESKTOP-ROO01MF;Initial Catalog=ApiWithWebTokenDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //her projeyi çalıştırdığımda ilgili tablolar oluşmuşmu oluşmamışsa
            //bunları yapsın anlamında olan aşağıdaki kodları yorum satırı yapacağım.

            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.ToTable("Product");

            //    entity.Property(e => e.Category).HasMaxLength(50);

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Price).HasColumnType("money");
            //});

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("User");

            //    entity.Property(e => e.Email).HasMaxLength(100);

            //    entity.Property(e => e.Name).HasMaxLength(50);

            //    entity.Property(e => e.Password).HasMaxLength(8);

            //    entity.Property(e => e.RefreshToken).HasMaxLength(500);

            //    entity.Property(e => e.RefreshTokenEndDate).HasColumnType("datetime");

            //    entity.Property(e => e.Surname).HasMaxLength(50);
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
