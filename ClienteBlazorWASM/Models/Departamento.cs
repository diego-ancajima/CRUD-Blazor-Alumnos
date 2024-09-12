using System.ComponentModel.DataAnnotations;

namespace ClienteBlazorWASM.Models
{
	public class Departamento
	{
		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public ICollection<Provincia> Provincias { get; set; }
	}
}
