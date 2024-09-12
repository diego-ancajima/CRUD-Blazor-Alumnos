using API.Models;

namespace API.Repositorio.IRepositorio
{
	public interface IAlumnoRepositorio
	{
		ICollection<Alumno> GetAlumnos(int ? dni, string nombres = null, string apellidos = null);
		Alumno GetAlumno(int codigo);
		bool ExisteAlumno(int codigo);
		bool CrearAlumno(Alumno alumno);
		bool BorrarAlumno(Alumno alumno);
		public bool ActualizarAlumno(Alumno alumno);

	}
}
