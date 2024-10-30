using AutoMapper;
using LabSoft.Data;
using LabSoft.DTOs;

namespace LabSoft.AutoMapperPrf
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioRequestDTO, Usuario>(); //Saca los datos de UsuarioRequestDTO y los mapea a Usuario
            CreateMap<Usuario, UsuarioResponseDTO>(); //Saca los datos de Usuario y los mapea a UsuarioResponseDTO
            CreateMap<Direccion, DireccionResponseDTO>(); //Saca los datos de Direccion y los mapea a DireccionResponseDTO
            CreateMap<Preferencia, PreferenciaResponseDTO>(); //Saca los datos de Preferencia y los mapea a PreferenciaResponseDTO
        }
    }
}