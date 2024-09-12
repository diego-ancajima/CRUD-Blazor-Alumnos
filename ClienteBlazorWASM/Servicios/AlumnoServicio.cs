using System.Text;
using ClienteBlazorWASM.Helpers;
using ClienteBlazorWASM.Models;
using ClienteBlazorWASM.Servicios.IServicio;
using Newtonsoft.Json;

namespace ClienteBlazorWASM.Servicios
{
	public class AlumnoServicio : IAlumnoServicio
	{
		private readonly HttpClient _cliente;

        public AlumnoServicio(HttpClient cliente)
        {
			_cliente = cliente;
        }
        public async Task<Alumno> ActualizarAlumno(int codigo, Alumno alumno)
		{
            var content = JsonConvert.SerializeObject(alumno);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _cliente.PatchAsync($"{Inicializar.UrlBaseApi}api/alumnos/{codigo}", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Alumno>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ModeloError>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }

        }

		public async Task<Alumno> CrearAlumno(Alumno alumno)
		{
			var content = JsonConvert.SerializeObject(alumno);
			var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _cliente.PostAsync($"{Inicializar.UrlBaseApi}api/alumnos", bodyContent);
            if (response.IsSuccessStatusCode)
			{
				var contentTemp = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<Alumno>(contentTemp);
				return result;
            }
			else
			{
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ModeloError>(contentTemp);
				throw new Exception(errorModel.ErrorMessage);
            }
        }

		public async Task<bool> EliminarAlumno(int codigo)
		{
			var response = await _cliente.DeleteAsync($"{Inicializar.UrlBaseApi}api/alumnos/{codigo}");
			if (response.IsSuccessStatusCode)
			{
				return true;
            }
			else
			{
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ModeloError>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<Alumno> GetAlumno(int codigo)
        {
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/alumnos/{codigo}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var alumno = JsonConvert.DeserializeObject<Alumno>(content);
                return alumno;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ModeloError>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<Alumno>> GetAlumnos(int ? dni = null, string nombres = null, string apellidos = null)
		{
            var baseUrl = $"{Inicializar.UrlBaseApi}api/alumnos";
            var queryParameters = new List<string>();

            if (dni.HasValue)
                queryParameters.Add($"dni={dni.Value}");
            if (!string.IsNullOrEmpty(nombres))
                queryParameters.Add($"nombres={Uri.EscapeDataString(nombres)}");
            if (!string.IsNullOrEmpty(apellidos))
                queryParameters.Add($"apellidos={Uri.EscapeDataString(apellidos)}");

            var url = queryParameters.Any() ? $"{baseUrl}?{string.Join("&", queryParameters)}" : baseUrl;

            var response = await _cliente.GetAsync(url);
			var content = await response.Content.ReadAsStringAsync();
			var alumnos = JsonConvert.DeserializeObject<IEnumerable<Alumno>>(content);
			return alumnos;
		}
	}
}
