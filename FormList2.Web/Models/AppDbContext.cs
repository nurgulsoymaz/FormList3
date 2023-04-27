using Microsoft.EntityFrameworkCore;

namespace FormList2.Web.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Form> Forms { get; set; } //forms table info
        public DbSet<Field> Fields { get; set; } //Fields table info

        public DbSet<Admin> Admins { get; set; } // Admins table info
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-66BEJ8D\\SQLEXPRESS;Initial Catalog=FormModel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Form>()
        // .HasMany(f => f.Field)
        // .WithOne(fm => fm.Form)
        // .HasForeignKey(fm => fm.Id);

        //    modelBuilder.Entity<Field>()
        //        .HasOne(fm => fm.Form)
        //        .WithMany(f => f.Forms)
        //        .HasForeignKey(fm => fm.Id);
        //}

    }
}
