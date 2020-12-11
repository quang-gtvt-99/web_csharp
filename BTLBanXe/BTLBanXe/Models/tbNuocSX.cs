namespace BTLBanXe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbNuocSX")]
    public partial class tbNuocSX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbNuocSX()
        {
            tbHangSXes = new HashSet<tbHangSX>();
            tbSanPhams = new HashSet<tbSanPham>();
        }

        [Key]
        [StringLength(50)]
        public string MaNuocSX { get; set; }

        [StringLength(50)]
        public string TenNuocSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHangSX> tbHangSXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbSanPham> tbSanPhams { get; set; }
    }
}
