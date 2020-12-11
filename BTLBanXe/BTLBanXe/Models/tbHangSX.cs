namespace BTLBanXe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbHangSX")]
    public partial class tbHangSX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbHangSX()
        {
            tbSanPhams = new HashSet<tbSanPham>();
        }

        [Key]
        [StringLength(50)]
        public string MaHangSX { get; set; }

        [StringLength(50)]
        public string TenHangSX { get; set; }

        [StringLength(50)]
        public string NuocSX { get; set; }

        public virtual tbNuocSX tbNuocSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbSanPham> tbSanPhams { get; set; }
    }
}
