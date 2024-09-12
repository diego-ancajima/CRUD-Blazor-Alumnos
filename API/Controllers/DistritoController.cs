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
    [Route("api/distritos")]
    [ApiController]
    public class DistritosController : ControllerBase
    {
        private readonly IDistritoRepositorio _distritoRepositorio;
        private readonly IMapper _mapper;

        public DistritosController(IDistritoRepositorio distritoRepositorio, IMapper mapper)
        {
            _distritoRepositorio = distritoRepositorio;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetDistritos()
        {
            var listaDistritos = _distritoRepositorio.GetDistritos();
            var listaDistritosDto = new List<DistritoDto>();
            foreach (var distrito in listaDistritos)
            {
                listaDistritosDto.Add(_mapper.Map<DistritoDto>(distrito));
            }
            return Ok(listaDistritosDto);
        }
    }
}
