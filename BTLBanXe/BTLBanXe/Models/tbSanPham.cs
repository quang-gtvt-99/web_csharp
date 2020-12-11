namespace BTLBanXe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbSanPham")]
    public partial class tbSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbSanPham()
        {
            tbAnhSPs = new HashSet<tbAnhSP>();
            tbDacDiems = new HashSet<tbDacDiem>();
            tbKhachHangs = new HashSet<tbKhachHang>();
        }

        [Key]
        [StringLength(50)]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        [StringLength(50)]
        public string MaLoai { get; set; }

        [StringLength(50)]
        public string MaHangSX { get; set; }

        [StringLength(50)]
        public string MaNuocSX { get; set; }

        [StringLength(50)]
        public string MaPhanKhuc { get; set; }

        [StringLength(50)]
        public string MaDacTinh { get; set; }

        public int? GiaTien { get; set; }

        public string ChiTiet { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [StringLength(50)]
        public string DongXe { get; set; }

        public double? CD { get; set; }

        public double? CR { get; set; }

        public double? CC { get; set; }

        public int? SoCho { get; set; }

        public double? CanNang { get; set; }

        [StringLength(50)]
        public string MauSac { get; set; }

        public int? DungTichXang { get; set; }

        [StringLength(50)]
        public string LoaiDongCo { get; set; }

        public double? CongSuatToiDa { get; set; }

        [StringLength(50)]
        public string LoaiLop { get; set; }

        [StringLength(50)]
        public string LoaiKhung { get; set; }

        [StringLength(50)]
        public string MucTT { get; set; }

        [StringLength(50)]
        public string HopSo { get; set; }

        [StringLength(50)]
        public string HTKD { get; set; }

        [StringLength(50)]
        public string DTXL { get; set; }

        [StringLength(50)]
        public string TSNen { get; set; }

        [StringLength(300)]
        public string Mota { get; set; }

        [StringLength(50)]
        public string TocDoTD { get; set; }

        public int? NamSX { get; set; }

        public int? SLBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbAnhSP> tbAnhSPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbDacDiem> tbDacDiems { get; set; }

        public virtual tbDacTinh tbDacTinh { get; set; }

        public virtual tbHangSX tbHangSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbKhachHang> tbKhachHangs { get; set; }

        public virtual tbLoai tbLoai { get; set; }

        public virtual tbNuocSX tbNuocSX { get; set; }

        public virtual tbPhanKhuc tbPhanKhuc { get; set; }
    }
}
