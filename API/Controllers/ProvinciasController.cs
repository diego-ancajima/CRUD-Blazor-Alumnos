using API.Models;
using API.Models.Dtos;
using API.Repositorio;
using API.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/provincias")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly IProvinciaRepositorio _provinciaRepositorio;
        private readonly IMapper _mapper;

        public ProvinciasController(IProvinciaRepositorio provinciaRepositorio, IMapper mapper)
        {
            _provinciaRepositorio = provinciaRepositorio;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProvincias()
        {
            var listaProvincias = _provinciaRepositorio.GetProvincias();
            var listaProvinciasDto = new List<ProvinciaDto>();
            foreach (var provincia in listaProvincias)
            {
                listaProvinciasDto.Add(_mapper.Map<ProvinciaDto>(provincia));
            }
            return Ok(listaProvinciasDto);
        }
    }


}
