using API.Data;
using API.Models;
using API.Repositorio.IRepositorio;

namespace API.Repositorio
{
    namespace API.Repositorio
    {
        public class DistritoRepositorio : IDistritoRepositorio
        {
            private readonly ApplicationDbContext _dbContext;

            public DistritoRepositorio(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public ICollection<Distrito> GetDistritos()
            {
                return _dbContext.Distritos.ToList();
            }
        }
    }
}
