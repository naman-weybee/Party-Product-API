using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PartyProductUsingAPI.Models
{
    public partial class PartyProductMVCContext : DbContext
    {
        public PartyProductMVCContext()
        {
        }

        public PartyProductMVCContext(DbContextOptions<PartyProductMVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignParty> AssignParties { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductRate> ProductRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9J2CV47;DataBase=PartyProductMVC;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AssignParty>(entity =>
            {
                entity.ToTable("AssignParty");

                entity.HasIndex(e => e.PartyId, "IX_AssignParty_PartyId");

                entity.HasIndex(e => e.ProductId, "IX_AssignParty_ProductId");

                entity.HasOne(d => d.Party);

                entity.HasOne(d => d.Product);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.ToTable("Party");

                entity.HasIndex(e => e.PartyName, "IX_Party_PartyName")
                    .IsUnique()
                    .HasFilter("([PartyName] IS NOT NULL)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.ProductName, "IX_Product_ProductName")
                    .IsUnique()
                    .HasFilter("([ProductName] IS NOT NULL)");
            });

            modelBuilder.Entity<ProductRate>(entity =>
            {
                entity.ToTable("ProductRate");

                entity.HasIndex(e => e.ProductId, "IX_ProductRate_ProductId")
                    .IsUnique();

                entity.HasOne(d => d.Product);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
