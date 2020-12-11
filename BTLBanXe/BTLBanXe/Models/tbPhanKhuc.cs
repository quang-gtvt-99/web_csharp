namespace BTLBanXe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbPhanKhuc")]
    public partial class tbPhanKhuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPhanKhuc()
        {
            tbSanPhams = new HashSet<tbSanPham>();
        }

        [Key]
        [StringLength(50)]
        public string MaPhanKhuc { get; set; }

        [StringLength(50)]
        public string TenPhanKhuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbSanPham> tbSanPhams { get; set; }
    }
}
