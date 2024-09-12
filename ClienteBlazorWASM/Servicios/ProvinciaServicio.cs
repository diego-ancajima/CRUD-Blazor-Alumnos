using System.Text;
using ClienteBlazorWASM.Helpers;
using ClienteBlazorWASM.Models;
using ClienteBlazorWASM.Servicios.IServicio;
using Newtonsoft.Json;

namespace ClienteBlazorWASM.Servicios
{
    public class ProvinciaServicio : IProvinciaServicio
    {
        private readonly HttpClient _cliente;

        public ProvinciaServicio(HttpClient cliente)
        {
            _cliente = cliente;
        }
        public async Task<IEnumerable<Provincia>> GetProvincias()
        {
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/provincias");
            var content = await response.Content.ReadAsStringAsync();
            var provincias = JsonConvert.DeserializeObject<IEnumerable<Provincia>>(content);
            return provincias;
        }
    }
}
