using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.DTO
{
    public class ChiTietGioHangDTO
    {
        public string MaSach { get; set; }
        public string Hinh { get; set; }
        public string TenSach { get; set; }
        public int? Soluong { get; set; }
        public double? GiaTien { get; set; }
    }
}