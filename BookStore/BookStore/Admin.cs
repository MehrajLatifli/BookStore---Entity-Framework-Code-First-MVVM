namespace BookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        [Key]
        public int IdAdmins { get; set; }

        [Column("Name of Admins")]
        [Required]
        [StringLength(100)]
        public string Name_of_Admins { get; set; }

        [Column("Passwords of Admins")]
        [Required]
        [StringLength(100)]
        public string Passwords_of_Admins { get; set; }
    }
}
