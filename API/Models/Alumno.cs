using System.ComponentModel.DataAnnotations;

namespace API.Models
{
	public class Alumno
	{
		[Key]
		public int Codigo { get; set; }
		public int DNI { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public char Sexo { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public int Edad { get; set; }
		public DateTime FechaIngreso { get; set; }
		public string Nacionalidad { get; set; }
		public int DepartamentoId { get; set; }
		public Departamento Departamento { get; set; }
		public int ProvinciaId { get; set; }
		public Provincia Provincia { get; set; }
		public int DistritoId { get; set; }
		public Distrito Distrito { get; set; }
		public string Domicilio { get; set; }

	}
}
