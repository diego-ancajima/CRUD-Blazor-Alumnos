using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
		public DbSet<Alumno> Alumnos { get; set; }
		public DbSet<Departamento> Departamentos { get; set; }
		public DbSet<Provincia> Provincias { get; set; }
		public DbSet<Distrito> Distritos { get; set; }
	}
}
