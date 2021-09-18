namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookIssueReturn")]
    public partial class BookIssueReturn
    {
        public int Id { get; set; }

        public int? MemberId { get; set; }

        public int? BookId { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime? ActualReturnDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? OneDateFine { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalFine { get; set; }

        public virtual Book Book { get; set; }

        public virtual Member Member { get; set; }
    }
}
