using BookManagement.Models;
using System.Collections.Generic;

namespace BookManagement.Models
{
    public class ShoppingCart
    {
        public ShoppingCart() {}
        public List<ItemCart> dsItemCart = new List<ItemCart>();
        public void AddItem(Sach sach, int quantity =1 )
        {
            if (dsItemCart.Exists(item => item.sach.MaSach == sach.MaSach))
            {
                dsItemCart.Find(i => i.sach.MaSach == sach.MaSach).SoLuong += quantity;
            }
            else
            {
                dsItemCart.Add(new ItemCart() { sach = sach, SoLuong = quantity });
            }
        }
        public void UpdateAmount(Sach sach, int quantity)
        {
            dsItemCart.Find(i => i.sach.MaSach == sach.MaSach).SoLuong = quantity;
        }
        public void Remove(Sach sach)
        {
            dsItemCart.Remove(dsItemCart.Find(i => i.sach.MaSach == sach.MaSach));
        }
        public double? TotalMoney()
        {
            double? tongtien = 0;
            foreach (ItemCart item in dsItemCart)
            {
                tongtien += item.SoLuong * item.sach.GiaTien;
            }
            return tongtien.Value;
        }
        public int TotalAmount()
        {
            int soluong = 0;
            foreach (ItemCart item in dsItemCart)
            {
                soluong += item.SoLuong;
            }
            return soluong;
        }
    }
}