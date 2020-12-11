namespace BTLBanXe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbLoai")]
    public partial class tbLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbLoai()
        {
            tbSanPhams = new HashSet<tbSanPham>();
        }

        [Key]
        [StringLength(50)]
        public string MaLoai { get; set; }

        [StringLength(50)]
        public string TenLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbSanPham> tbSanPhams { get; set; }
    }
}
