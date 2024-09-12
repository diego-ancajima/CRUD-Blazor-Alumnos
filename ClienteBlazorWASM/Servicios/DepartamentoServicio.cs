using System.Text;
using ClienteBlazorWASM.Helpers;
using ClienteBlazorWASM.Models;
using ClienteBlazorWASM.Servicios.IServicio;
using Newtonsoft.Json;

namespace ClienteBlazorWASM.Servicios
{
    public class DepartamentoServicio : IDepartamentoServicio
    {
        private readonly HttpClient _cliente;

        public DepartamentoServicio(HttpClient cliente)
        {
            _cliente = cliente;
        }
        public async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/departamentos");
            var content = await response.Content.ReadAsStringAsync();
            var departamentos = JsonConvert.DeserializeObject<IEnumerable<Departamento>>(content);
            return departamentos;
        }
    }
}
