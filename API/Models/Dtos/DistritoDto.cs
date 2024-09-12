namespace API.Models.Dtos
{
	public class DistritoDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public int ProvinciaId { get; set; } // Relación con Provincia
	}
}
