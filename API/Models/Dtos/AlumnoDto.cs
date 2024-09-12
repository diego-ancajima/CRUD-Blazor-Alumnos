namespace API.Models.Dtos
{
	public class AlumnoDto
	{
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
		public int ProvinciaId { get; set; }
		public int DistritoId { get; set; }
		public string Domicilio { get; set; }
	}
}
