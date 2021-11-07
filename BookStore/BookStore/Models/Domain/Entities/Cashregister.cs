namespace BookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cashregister
    {
        [Key]
        public int IdCashregister { get; set; }

        [Column(TypeName = "money")]
        public decimal? Profit { get; set; }

        public int CustomersId_for_Cashregister { get; set; }

        public int BookId_forCashregister { get; set; }

        public virtual Book Book { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
