namespace QuanLyLamNghiep.Models
{
    public class DieuKhoan
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Khungphat { get; set; }

        public string Mucphat { get; set; }

        public int ChuongMucId { get; set; }

        public ChuongMuc ChuongMuc { get; set; }

        public DieuKhoan()
        {

        }
    }

    public class DieuKhoanDto
    {
        public int? Id { get; set; }

        public string Content { get; set; }

        public string Khungphat { get; set; }

        public string Mucphat { get; set; }

        public int ChuongMucId { get; set; }

        public string ChuongMucContent { get; set; }

        public DieuKhoanDto()
        {

        }
    }
}
