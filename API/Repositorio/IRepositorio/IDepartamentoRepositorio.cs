using API.Models;

namespace API.Repositorio.IRepositorio
{
    public interface IDepartamentoRepositorio
    {
        ICollection<Departamento> GetDepartamentos();
    }
}
