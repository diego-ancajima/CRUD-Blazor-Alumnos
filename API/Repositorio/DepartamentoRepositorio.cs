using API.Data;
using API.Models;
using API.Repositorio.IRepositorio;

namespace API.Repositorio
{
    public class DepartamentoRepositorio : IDepartamentoRepositorio
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartamentoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Departamento> GetDepartamentos()
        {
            return _dbContext.Departamentos.ToList();
        }
    }
}
