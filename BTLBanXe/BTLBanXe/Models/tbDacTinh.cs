namespace BTLBanXe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbDacTinh")]
    public partial class tbDacTinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbDacTinh()
        {
            tbSanPhams = new HashSet<tbSanPham>();
        }

        [Key]
        [StringLength(50)]
        public string MaDacTinh { get; set; }

        [StringLength(50)]
        public string TenDacTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbSanPham> tbSanPhams { get; set; }
    }
}
