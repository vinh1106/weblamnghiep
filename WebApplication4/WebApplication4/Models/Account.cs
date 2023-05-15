namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        public int account_id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        [StringLength(20)]
        public string type { get; set; }
    }
}
