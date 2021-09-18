using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class LibraryDB : DbContext
    {
        public LibraryDB()
            : base("name=LibraryDB")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookIssueReturn> BookIssueReturns { get; set; }
        public virtual DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<BookIssueReturn>()
                .Property(e => e.OneDateFine)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BookIssueReturn>()
                .Property(e => e.TotalFine)
                .HasPrecision(19, 4);
        }
    }
}
