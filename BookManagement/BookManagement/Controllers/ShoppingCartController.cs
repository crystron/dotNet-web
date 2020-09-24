using BookManagement.DAO;
using BookManagement.Models;
using System;
using System.Collections.Generic;
using BookManagement.DTO;
using System.Web.Mvc;

namespace BookManagement.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public const string shop = "Shopping";
        public ActionResult Index()
        {
            ShoppingCart cart = (ShoppingCart)Session[shop];
            if ( cart != null)
            {
                List<ItemCart> ds = new List<ItemCart>();
                ds = cart.dsItemCart;
                ViewBag.tongtien = cart.TotalMoney();
                ViewBag.soluong = cart.TotalAmount();
                return View("Index", ds);
            }
            return View("Error");
        }
        public ActionResult AddItem(string id, int soluong =1)
        {
            SachDAO sachDAO = new SachDAO();
            Sach sach = sachDAO.Details(id);
            ShoppingCart cart = (ShoppingCart)Session[shop];
            if ( cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.AddItem(sach, soluong);
            Session[shop] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Delete(string id)
        {
            SachDAO sachDAO = new SachDAO();
            Sach sach = sachDAO.Details(id);
            ShoppingCart cart = (ShoppingCart)Session[shop];
            cart.Remove(sach);
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult Update(string id, int soluong)
        {
            SachDAO sachDAO = new SachDAO();
            Sach sach = sachDAO.Details(id);
            ShoppingCart cart = (ShoppingCart)Session[shop];
            cart.UpdateAmount(sach, soluong);
            Session[shop] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
       
        public ActionResult ThanhToan()
        {
            ShoppingCart cart = (ShoppingCart)Session[shop];
            if (cart != null)
            {
                List<ItemCart> li = new List<ItemCart>();
                li = cart.dsItemCart;
                ViewBag.tongtien = cart.TotalMoney();
                ViewBag.soluong = cart.TotalAmount();
                return View("ThanhToan", li);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult ThanhToan1(KhachHangDTO khachHangDTO)
        {
            var sess = (Areas.Admin.Models.TaiKhoan)Session["UserLogin"];
            ShoppingCart cart = (ShoppingCart)Session[shop];
            List<ItemCart> li = new List<ItemCart>();
            li = cart.dsItemCart;
            ViewBag.tongtien = cart.TotalMoney();
            ViewBag.soluong = cart.TotalAmount();
            if (ModelState.IsValid)
            {
                if ( sess  == null)
                {
                    KhachHang kh = new KhachHang();
                    KhachHangDAO khachHangDAO = new KhachHangDAO();
                    kh.MaKH = khachHangDAO.GetMaxMKH();
                    kh.TenKh = khachHangDTO.TenKH;
                    kh.SoDT = khachHangDTO.SoDT;
                    kh.Email = khachHangDTO.Email;
                    kh.DiaChi = khachHangDTO.DiaChi;
                    string MaKH = khachHangDAO.ThemKhachHang(kh);

                    GioHang gioHang = new GioHang();
                    GioHangDAO gioHangDAO = new GioHangDAO();
                    gioHang.MaGH = gioHangDAO.getMaGH();
                    gioHang.MaKH = MaKH;
                    gioHang.NgayDatHang = DateTime.Today;
                    gioHang.TinhTrang = false;
                    gioHang.TongTien = cart.TotalMoney();
                    string MaGH = gioHangDAO.ThemGioHang(gioHang);
                    foreach (ItemCart item in li)
                    {
                        ChiTietGioHang chiTietGioHang = new ChiTietGioHang()
                        {
                            MaGH = MaGH,
                            MaSach = item.sach.MaSach,
                            SoLuong = item.SoLuong,
                            GiaTien = item.SoLuong * (item.sach.GiaTien)
                        };
                        ChiTietGioHangDAO chiTietGioHangDAO = new ChiTietGioHangDAO();
                        chiTietGioHangDAO.Them(chiTietGioHang);
                    }
                    Session[shop] = null;
                    return View("Success");
                }
                else
                {
                    GioHang gioHang = new GioHang();
                    GioHangDAO gioHangDAO = new GioHangDAO();
                    gioHang.MaGH = gioHangDAO.getMaGH();
                    gioHang.MaKH = sess.MaKH;
                    gioHang.NgayDatHang = DateTime.Today;
                    gioHang.TinhTrang = false;
                    gioHang.TongTien = cart.TotalMoney();
                    string MaGH = gioHangDAO.ThemGioHang(gioHang);
                    foreach (ItemCart item in li)
                    {
                        ChiTietGioHang chiTietGioHang = new ChiTietGioHang()
                        {
                            MaGH = MaGH,
                            MaSach = item.sach.MaSach,
                            SoLuong = item.SoLuong,
                            GiaTien = item.SoLuong * (item.sach.GiaTien)
                        };
                        ChiTietGioHangDAO chiTietGioHangDAO = new ChiTietGioHangDAO();
                        chiTietGioHangDAO.Them(chiTietGioHang);
                    }
                    Session[shop] = null;
                    return View("Success");
                }
            }
            else
            {
                return View("ThanhToan", li);
            }
        }
    }
}