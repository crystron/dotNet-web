
namespace BookManagement.Models
{
    public class ItemCart
    {
        public ItemCart() { }
        public Sach sach { get; set; }
        public int SoLuong { get; set; }
        public double? thanhtien()
        {
            return sach.GiaTien * SoLuong;
        }
    }
}