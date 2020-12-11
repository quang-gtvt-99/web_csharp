namespace BTLBanXe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbAnhSP")]
    public partial class tbAnhSP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TenFileAnh { get; set; }

        [StringLength(50)]
        public string chitiet { get; set; }

        public virtual tbSanPham tbSanPham { get; set; }
    }
}
