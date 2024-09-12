using API.Models;

namespace API.Repositorio.IRepositorio
{
    public interface IDistritoRepositorio
    {
        ICollection<Distrito> GetDistritos();
    }
}
