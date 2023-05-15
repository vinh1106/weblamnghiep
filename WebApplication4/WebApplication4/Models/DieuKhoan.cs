namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DieuKhoan")]
    public partial class DieuKhoan
    {
        public int id { get; set; }

        public string content { get; set; }

        public string khungphat { get; set; }

        public string mucphat { get; set; }

        public int? id_chuong { get; set; }
    }
}
