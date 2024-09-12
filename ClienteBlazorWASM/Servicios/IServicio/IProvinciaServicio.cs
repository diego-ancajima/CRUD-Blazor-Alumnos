using ClienteBlazorWASM.Models;

namespace ClienteBlazorWASM.Servicios.IServicio
{
    public interface IProvinciaServicio
    {
        public Task<IEnumerable<Provincia>> GetProvincias();
    }
}
