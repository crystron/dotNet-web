//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            this.ChiTietTKs = new HashSet<ChiTietTK>();
        }
    
        public string MaTK { get; set; }
        public string TenTK { get; set; }
        public string TenHienThi { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public Nullable<byte> Quyen { get; set; }
        public string MaKH { get; set; }
    
        public virtual TaiKhoan TaiKhoan1 { get; set; }
        public virtual TaiKhoan TaiKhoan2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTK> ChiTietTKs { get; set; }
    }
}