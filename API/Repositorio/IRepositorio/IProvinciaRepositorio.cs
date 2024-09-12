using API.Models;

namespace API.Repositorio.IRepositorio
{
    public interface IProvinciaRepositorio
    {
        ICollection<Provincia> GetProvincias();
    }
}
