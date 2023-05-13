using RecycleDevices.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using RecycleDevices.Models;


namespace RecycleDevices.Data
{
    public class ApointmentContext : DbContext
    {
        public ApointmentContext(DbContextOptions<ApointmentContext> options) : base(options) { }

        public DbSet<Apointment> Apointment { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Package> Package { get; set; }
        //public DbSet<User> User { get; set; }
        public DbSet<User> Client { get; set; }
        // public DbSet<Roll> rolls { get; set; }
        public DbSet<Models.Token> Tokens { get; set; }
        //   public DbSet<loggin> loggins { get; set; }

        public object Apointments { get; internal set; }

        public DbSet<Domiciliario> Domiciliarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Apointment>()
            //   .HasOne(p => p.user)
            //   .WithMany(p => p.Apointments)
            //   .HasForeignKey(p => p.UserID)
            //   .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Apointment>(entity =>
            {


                entity.Property(e => e.Country)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                entity.Property(e => e.Departament)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                entity.Property(e => e.Municipality)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                entity.Property(e => e.Address)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

            });
        }
    }
}