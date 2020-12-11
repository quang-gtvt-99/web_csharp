namespace ClassLibrary1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyBanXeEntities : DbContext
    {
        public QuanLyBanXeEntities()
            : base("name=QuanLyBanXeEntities")
        {
        }

        public virtual DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
