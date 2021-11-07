namespace BookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Cashregisters = new HashSet<Cashregister>();
        }

        [Key]
        public int IdCustomers { get; set; }

        [Column("Name of Customers")]
        [Required]
        [StringLength(100)]
        public string Name_of_Customers { get; set; }

        [Column("Passwords of Customers")]
        [Required]
        [StringLength(100)]
        public string Passwords_of_Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cashregister> Cashregisters { get; set; }
    }
}
