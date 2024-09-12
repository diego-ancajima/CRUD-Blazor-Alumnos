using ClienteBlazorWASM.Models;

namespace ClienteBlazorWASM.Servicios.IServicio
{
    public interface IDepartamentoServicio
    {
        public Task<IEnumerable<Departamento>> GetDepartamentos();
    }
}
