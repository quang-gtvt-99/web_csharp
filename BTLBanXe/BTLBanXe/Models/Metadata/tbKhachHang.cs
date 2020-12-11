namespace BTLBanXe.Models.Metadata
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbKhachHang")]
    public partial class tbKhachHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50, ErrorMessage = "Vượt quá kí tự tối đa")]
        [Required(ErrorMessage = "Bạn chưa nhập dữ liệu")]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHenLay { get; set; }

        public int? SLmua { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string NhuCau { get; set; }
    }
}
