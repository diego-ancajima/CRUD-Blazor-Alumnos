using ClienteBlazorWASM.Models;

namespace ClienteBlazorWASM.Servicios.IServicio
{
    public interface IDistritoServicio
    {
        public Task<IEnumerable<Distrito>> GetDistritos();
    }
}
