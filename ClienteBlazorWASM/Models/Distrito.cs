using System.ComponentModel.DataAnnotations;

namespace ClienteBlazorWASM.Models
{
	public class Distrito
	{
		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; }

		public int ProvinciaId { get; set; }
		public Provincia Provincia { get; set; }
	}
}
