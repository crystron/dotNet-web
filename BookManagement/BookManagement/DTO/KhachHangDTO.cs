using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.DTO
{
    public class KhachHangDTO
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public double? TongTien { get; set; }
        public string MaGH { get; set; }
    }
}