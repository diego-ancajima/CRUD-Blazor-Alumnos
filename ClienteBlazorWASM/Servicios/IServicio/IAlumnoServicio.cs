using ClienteBlazorWASM.Models;

namespace ClienteBlazorWASM.Servicios.IServicio
{
    public interface IAlumnoServicio
    {
        public Task<IEnumerable<Alumno>> GetAlumnos(int? dni = null, string nombres = null, string apellidos = null);
        public Task<Alumno> GetAlumno(int codigo);
        public Task<Alumno> CrearAlumno(Alumno alumno);
        public Task<Alumno> ActualizarAlumno(int codigo, Alumno alumno);
        public Task<bool> EliminarAlumno(int codigo);
    }
}
