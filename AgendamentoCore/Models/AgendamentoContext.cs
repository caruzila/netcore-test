using Microsoft.EntityFrameworkCore;

namespace AgendamentoCore.Models
{
    public class AgendamentoContext : DbContext
    {
        public AgendamentoContext(DbContextOptions<AgendamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>().ToTable("Consulta");
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
        }
    }
}