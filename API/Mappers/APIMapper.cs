using AutoMapper;
using API.Models;
using API.Models.Dtos;

namespace API.Mappers
{
	public class APIMapper : Profile
	{
		public APIMapper()
		{
			CreateMap<Alumno, AlumnoDto>().ReverseMap();
			CreateMap<Departamento, DepartamentoDto>().ReverseMap();
			CreateMap<Provincia, ProvinciaDto>().ReverseMap();
			CreateMap<Distrito, DistritoDto>().ReverseMap();
		}
	}
}
