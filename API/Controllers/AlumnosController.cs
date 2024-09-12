using API.Models;
using API.Models.Dtos;
using API.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/alumnos")]
	[ApiController]
	public class AlumnosController : ControllerBase
	{
		private readonly IAlumnoRepositorio _alumnoRepositorio;
		private readonly IMapper _mapper;
		public AlumnosController(IAlumnoRepositorio alumnoRepositorio, IMapper mapper)
		{
			_alumnoRepositorio = alumnoRepositorio;
			_mapper = mapper;
        }

		[AllowAnonymous]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetAlumnos(int? dni = null, string nombres = null, string apellidos = null)
		{
			var listaAlumnos = _alumnoRepositorio.GetAlumnos(dni, nombres, apellidos);
			var listaAlumnosDto = new List<AlumnoDto>();
			foreach (var lista in listaAlumnos)
			{
				listaAlumnosDto.Add(_mapper.Map<AlumnoDto>(lista));
			}
			return Ok(listaAlumnosDto);
		}

        [AllowAnonymous]
        [HttpGet("{codigo:int}", Name = "GetAlumno")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAlumno(int codigo)
        {
            var itemPost = _alumnoRepositorio.GetAlumno(codigo);

            if (itemPost == null)
            {
                return NotFound();
            }

            var itemPostDto = _mapper.Map<AlumnoDto>(itemPost);
            return Ok(itemPostDto);
        }

        [HttpPost]
		[ProducesResponseType(201, Type = typeof(AlumnoDto))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult CrearAlumno([FromBody] AlumnoDto crearAlumnoDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (crearAlumnoDto == null)
			{
				return BadRequest(ModelState);
			}
			
			if(_alumnoRepositorio.ExisteAlumno(crearAlumnoDto.Codigo))
			{
				ModelState.AddModelError("", "El alumno ya existe");
				return StatusCode(404, ModelState);	
			}
			
			var alumno = _mapper.Map<Alumno>(crearAlumnoDto);
			if (!_alumnoRepositorio.CrearAlumno(alumno))
			{
				ModelState.AddModelError("", $"Alumno {alumno.Nombres} no se pudo crear");
				return StatusCode(500, ModelState);
			}
			return CreatedAtRoute("GetAlumno", new { codigo = alumno.Codigo }, alumno);
		}

        [HttpPatch("{codigo:int}", Name="ActualizarAlumno")]
		[ProducesResponseType(201, Type = typeof(AlumnoDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarAlumnoPost(int codigo, [FromBody] AlumnoDto actualizarAlumnoDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (actualizarAlumnoDto == null || codigo != actualizarAlumnoDto.Codigo)
			{
				return BadRequest(ModelState);
			}
			
			if(!_alumnoRepositorio.ExisteAlumno(actualizarAlumnoDto.Codigo))
			{
				ModelState.AddModelError("", "El alumno no existe");
				return StatusCode(404, ModelState);
			}
			
			var alumno = _mapper.Map<Alumno>(actualizarAlumnoDto);
			if (!_alumnoRepositorio.ActualizarAlumno(alumno))
			{
				ModelState.AddModelError("", $"Alumno {alumno.Nombres} no se pudo editar");
				return StatusCode(500, ModelState);
			}
			return NoContent();
		}

        [HttpDelete("{codigo:int}", Name = "BorrarAlumno")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]

		public IActionResult BorrarAlumnoPost(int codigo)
		{
			if(!_alumnoRepositorio.ExisteAlumno(codigo))
			{
				return NotFound();
			}
			var alumno = _alumnoRepositorio.GetAlumno(codigo);
			if (!_alumnoRepositorio.BorrarAlumno(alumno))
			{
				ModelState.AddModelError("", $"Alumno {alumno.Nombres} no se pudo borrar");
				return StatusCode(500, ModelState);
			}
			return NoContent();
		}
	}


}
