namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLVLDbContext : DbContext
    {
        public QLVLDbContext()
            : base("name=QLVLDbContext")
        {
        }

        public virtual DbSet<doithicong> doithicongs { get; set; }
        public virtual DbSet<nhacc> nhaccs { get; set; }
        public virtual DbSet<nhanvien> nhanviens { get; set; }
        public virtual DbSet<phieunhap> phieunhaps { get; set; }
        public virtual DbSet<phieuxuat> phieuxuats { get; set; }
        public virtual DbSet<quyen> quyens { get; set; }
        public virtual DbSet<vaitro> vaitroes { get; set; }
        public virtual DbSet<vatlieu> vatlieux { get; set; }
        public virtual DbSet<vtro_quyen> vtro_quyen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<doithicong>()
                .Property(e => e.Ten)
                .IsUnicode(false);

            modelBuilder.Entity<nhacc>()
                .Property(e => e.Ten)
                .IsUnicode(false);

            modelBuilder.Entity<nhacc>()
                .Property(e => e.DiaChi)
                .IsUnicode(false);

            modelBuilder.Entity<nhacc>()
                .Property(e => e.SoDT)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.Ten)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.DiaChi)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<quyen>()
                .Property(e => e.Ten)
                .IsUnicode(false);

            modelBuilder.Entity<vaitro>()
                .Property(e => e.Ten)
                .IsUnicode(false);

            modelBuilder.Entity<vatlieu>()
                .Property(e => e.Ten)
                .IsUnicode(false);

            modelBuilder.Entity<vatlieu>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}