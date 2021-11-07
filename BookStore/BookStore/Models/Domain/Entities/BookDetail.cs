namespace BookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookDetail
    {
        [Key]
        public int IdBookDetail { get; set; }

        public int BookId_forBookDetail { get; set; }

        public int AuthorId_forBookDetail { get; set; }

        public int PressId_forBookDetail { get; set; }

        public virtual Author Author { get; set; }

        public virtual Book Book { get; set; }

        public virtual Press Press { get; set; }
    }
}
