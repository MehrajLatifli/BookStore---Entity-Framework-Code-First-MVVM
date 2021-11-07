using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookStore
{
    public partial class BookStoreModel : DbContext
    {
        public BookStoreModel()
            : base("name=BookStoreModel")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookDetail> BookDetails { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Cashregister> Cashregisters { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Press> Presses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.BookDetails)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.AuthorId_forBookDetail);

            modelBuilder.Entity<Book>()
                .Property(e => e.BookPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.BookDetails)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.BookId_forBookDetail);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Cashregisters)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.BookId_forCashregister);

            modelBuilder.Entity<Cashregister>()
                .Property(e => e.Profit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Cashregisters)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomersId_for_Cashregister);

            modelBuilder.Entity<Press>()
                .HasMany(e => e.BookDetails)
                .WithRequired(e => e.Press)
                .HasForeignKey(e => e.PressId_forBookDetail);
        }
    }
}
