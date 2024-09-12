using System.Text;
using ClienteBlazorWASM.Helpers;
using ClienteBlazorWASM.Models;
using ClienteBlazorWASM.Servicios.IServicio;
using Newtonsoft.Json;

namespace ClienteBlazorWASM.Servicios
{
    public class DistritoServicio : IDistritoServicio
    {
        private readonly HttpClient _cliente;

        public DistritoServicio(HttpClient cliente)
        {
            _cliente = cliente;
        }
        public async Task<IEnumerable<Distrito>> GetDistritos()
        {
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/distritos");
            var content = await response.Content.ReadAsStringAsync();
            var distritos = JsonConvert.DeserializeObject<IEnumerable<Distrito>>(content);
            return distritos;
        }
    }
}
