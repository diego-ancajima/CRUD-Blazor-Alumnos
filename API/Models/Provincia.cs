using System.ComponentModel.DataAnnotations;

namespace API.Models
{
	public class Provincia
	{
		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public int DepartamentoId { get; set; }
		public Departamento Departamento { get; set; }
		public ICollection<Distrito> Distritos { get; set; }
	}
}
