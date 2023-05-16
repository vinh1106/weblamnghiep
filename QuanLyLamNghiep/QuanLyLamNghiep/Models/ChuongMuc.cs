using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLamNghiep.Models
{
    public class ChuongMuc
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ChuongMuc()
        {

        }

        public ChuongMuc(int id, string content)
        {
            Id = id;
            Content = content;
        }
    }

}
