using System.ComponentModel.DataAnnotations;

namespace BookManagement.Areas.Admin.Models
{
    public class TaiKhoan
    {
        [Required(ErrorMessage = "Xin nhập tài khoản")]
        public string TenTK { get; set; }
        [Required(ErrorMessage = "Xin nhập mật khẩu")]
        public string MatKhau { get; set; }
        public byte? Quyen { get; set; }
        public string TenHienThi { get; set; }
        public string MaTK { get; set; }
        public bool GhiNhoTaiKhoan { get; set; }
        public string MaKH { get; set; }
    }
}