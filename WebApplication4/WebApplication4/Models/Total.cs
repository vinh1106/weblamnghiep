using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace WebApplication4.Models
{
    public class Total
    {
        public IEnumerable<DieuKhoan> DieuKhoan1 { get; set; }
        public IEnumerable<ChuongMuc> ChuongMuc1 { get; set; }
    }
}