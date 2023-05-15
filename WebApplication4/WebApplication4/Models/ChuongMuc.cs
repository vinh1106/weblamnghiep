namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuongMuc")]
    public partial class ChuongMuc
    {
        public int id { get; set; }

        public string content { get; set; }
    }
}
