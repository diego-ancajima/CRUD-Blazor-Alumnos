using API.Data;
using API.Models;
using API.Repositorio.IRepositorio;

namespace API.Repositorio
{
    namespace API.Repositorio
    {
        public class ProvinciaRepositorio : IProvinciaRepositorio
        {
            private readonly ApplicationDbContext _dbContext;

            public ProvinciaRepositorio(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public ICollection<Provincia> GetProvincias()
            {
                return _dbContext.Provincias.ToList();
            }
        }
    }
}
