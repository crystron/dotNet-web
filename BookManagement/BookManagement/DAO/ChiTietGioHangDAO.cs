using BookManagement.Models;

namespace BookManagement.DAO
{
    public class ChiTietGioHangDAO
    {
        BookDb db = null;
        public ChiTietGioHangDAO()
        {
            db = new BookDb();
        }
        public void Them(ChiTietGioHang ct)
        {
            db.ChiTietGioHangs.Add(ct);
            db.SaveChanges();
        }
    }
}