namespace BTLBanXe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbDacDiem")]
    public partial class tbDacDiem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaDD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string ChiTietDD { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        public virtual tbSanPham tbSanPham { get; set; }
    }
}
