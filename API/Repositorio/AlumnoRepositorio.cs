using API.Data;
using API.Models;
using API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorio
{
    public class AlumnoRepositorio : IAlumnoRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public AlumnoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ExisteAlumno(int codigo)
        {
            bool valor = _dbContext.Alumnos.Any(a => a.Codigo == codigo);
            return valor;
        }

        public bool ActualizarAlumno(Alumno alumno)
        {
            _dbContext.Alumnos.Update(alumno);
            return Guardar();
        }

        public bool BorrarAlumno(Alumno alumno)
        {
            _dbContext.Alumnos.Remove(alumno);
            return Guardar();
        }

        public bool CrearAlumno(Alumno alumno)
        {
            _dbContext.Alumnos.Add(alumno);
            return Guardar();
        }

        public ICollection<Alumno> GetAlumnos(int ? dni = null, string nombres = null, string apellidos = null)
        {
            var query = _dbContext.Alumnos.AsQueryable();

            if (dni.HasValue)
            {
                query = query.Where(a => a.DNI == dni);
            }
            
            if(!string.IsNullOrEmpty(nombres))
            {
                query = query.Where(a => a.Nombres.Contains(nombres));
            }   

            if(!string.IsNullOrEmpty(apellidos))
            {
                query = query.Where(a => a.Apellidos.Contains(apellidos));
            }

            return query.ToList();
        }

        public bool Guardar()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public Alumno GetAlumno(int codigo)
        {
            return _dbContext.Alumnos.FirstOrDefault(a => a.Codigo == codigo);
        }
    }
}
