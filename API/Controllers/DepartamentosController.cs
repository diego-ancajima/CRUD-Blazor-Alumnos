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
    [Route("api/departamentos")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoRepositorio _departamentoRepositorio;
        private readonly IMapper _mapper;
        public DepartamentosController(IDepartamentoRepositorio departamentoRepositorio, IMapper mapper)
        {
            _departamentoRepositorio = departamentoRepositorio;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetDepartamentos()
        {
            var listaDepartamentos = _departamentoRepositorio.GetDepartamentos();
            var listaDepartamentosDto = new List<DepartamentoDto>();
            foreach (var lista in listaDepartamentos)
            {
                listaDepartamentosDto.Add(_mapper.Map<DepartamentoDto>(lista));
            }
            return Ok(listaDepartamentosDto);
        }

    }

    
}
