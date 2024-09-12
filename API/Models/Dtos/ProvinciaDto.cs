namespace API.Models.Dtos
{
	public class ProvinciaDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public int DepartamentoId { get; set; } // Relación con Departamento
	}
}
