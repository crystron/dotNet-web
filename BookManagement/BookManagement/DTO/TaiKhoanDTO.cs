using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTO
{
    public class TaiKhoanDTO
    {
        [Required(ErrorMessage = "Xin nhập tài khoản")]
        public string TenTK { get; set; }
        [Required(ErrorMessage = "Xin nhập mật khẩu")]
        public string MatKhau { get; set; }
        public int Quyen { get; set; }
        public string Email { get; set; }
        public bool GhiNhoTaiKhoan { get; set; }
    }
}