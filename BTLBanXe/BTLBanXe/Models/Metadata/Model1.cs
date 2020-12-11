namespace BTLBanXe.Models.Metadata
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbSanPham> tbSanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbSanPham>()
                .Property(e => e.MucTT)
                .IsUnicode(false);

            modelBuilder.Entity<tbSanPham>()
                .Property(e => e.HopSo)
                .IsUnicode(false);

            modelBuilder.Entity<tbSanPham>()
                .Property(e => e.HTKD)
                .IsUnicode(false);

            modelBuilder.Entity<tbSanPham>()
                .Property(e => e.DTXL)
                .IsUnicode(false);

            modelBuilder.Entity<tbSanPham>()
                .Property(e => e.TSNen)
                .IsUnicode(false);

            modelBuilder.Entity<tbSanPham>()
                .Property(e => e.Mota)
                .IsUnicode(false);

            modelBuilder.Entity<tbSanPham>()
                .Property(e => e.TocDoTD)
                .IsUnicode(false);
        }
    }
}
