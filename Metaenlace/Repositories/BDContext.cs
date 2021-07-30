using Microsoft.EntityFrameworkCore;
using Metaenlace.Models;


namespace Metaenlace.Repositories
{
    public class BDContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Diagnostico> Diagnostico { get; set; }
        public BDContext( DbContextOptions<BDContext> options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<Cita>()
                .HasOne(a => a.diagnostico).WithOne(b => b.cita)
                .HasForeignKey<Diagnostico>(d => d.ID);
            modelBuilder.Entity<Cita>().ToTable("Cita");
            modelBuilder.Entity<Diagnostico>().ToTable("Diagnostico");
        }

        


       

    }
}
